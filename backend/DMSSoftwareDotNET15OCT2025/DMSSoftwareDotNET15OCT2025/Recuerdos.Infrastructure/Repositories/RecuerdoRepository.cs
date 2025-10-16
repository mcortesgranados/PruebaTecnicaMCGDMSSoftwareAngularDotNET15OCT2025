using DMSSoftwareDotNET15OCT2025.Recuerdos.Application.Domain.Entities;
using DMSSoftwareDotNET15OCT2025.Recuerdos.Application.Domain.Ports;
using DMSSoftwareDotNET15OCT2025.Recuerdos.Application.Domain.Ports;
using DMSSoftwareDotNET15OCT2025.Recuerdos.Application.DTOs;
using DMSSoftwareDotNET15OCT2025.Recuerdos.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMSSoftwareDotNET15OCT2025.Recuerdos.Infrastructure.Repositories
{
    public class RecuerdoRepository : IRecuerdoRepository
    {
        private readonly ApplicationDbContext _context; // <-- CAMBIO

        public RecuerdoRepository(ApplicationDbContext context) // <-- CAMBIO
        {
            _context = context;
        }

        public async Task<Recuerdo> AddAsync(Recuerdo recuerdo)
        {
            _context.Recuerdos.Add(recuerdo);
            await _context.SaveChangesAsync();
            return recuerdo;
        }
        public async Task<Recuerdo?> GetByIdAsync(int id)
        {
            return await _context.Recuerdos
                .Include(r => r.Creador)
                .FirstOrDefaultAsync(r => r.Id == id); // <-- Usar Id, no RecuerdoId
        }

        public async Task<List<Recuerdo>> GetByUserIdAsync(int userId)
        {
            return await _context.Recuerdos
                .Where(r => r.CreadorId == userId)
                .ToListAsync();
        }

        public async Task UpdateAsync(Recuerdo recuerdo)
        {
            _context.Recuerdos.Update(recuerdo);
            await _context.SaveChangesAsync();
        }


        // -------------------- NUEVO MÉTODO --------------------
        /// <summary>
        /// (REQ-07) Busca recuerdos cuyo campo Situacion contenga la palabra clave (case-insensitive)
        /// </summary>
        public async Task<List<Recuerdo>> BuscarRecuerdosAsync(string palabraClave)
        {
            if (string.IsNullOrWhiteSpace(palabraClave))
                return new List<Recuerdo>();

            return await _context.Recuerdos
                .Include(r => r.Creador)
                .Where(r => EF.Functions.Like(r.Situacion, $"%{palabraClave}%"))
                .ToListAsync();
        }

        public async Task<List<RecuerdoAmigoDto>> GetRecuerdosByAmigoIdAsync(int amigoId)
        {
            return await _context.Recuerdos
                .Where(r => r.CreadorId == amigoId)
                .Select(r => new RecuerdoAmigoDto
                {
                    Id = r.Id,
                    Titulo = r.Titulo,
                    Situacion = r.Situacion,
                    FechaOcurrencia = r.FechaOcurrencia,
                    Estado = r.Estado.HasValue ? r.Estado.Value.ToString() : "Sospecha",
                    CreadorNombre = r.Creador.Nombre
                })
                .ToListAsync();
        }

        public async Task<List<ObjetoRecuerdoDto>> GetObjetosByRecuerdoIdAsync(int recuerdoId)
        {
            return await _context.Recuerdos_Objetos
                .Where(ro => ro.RecuerdoId == recuerdoId)
                .Include(ro => ro.Objeto)
                    .ThenInclude(o => o.Creador)
                .Select(ro => new ObjetoRecuerdoDto
                {
                    ObjetoId = ro.ObjetoId,
                    Nombre = ro.Objeto.Nombre,
                    Descripcion = ro.Objeto.Descripcion,
                    CreadorNombre = ro.Objeto.Creador.Nombre,
                    FechaAsociacion = ro.FechaAsociacion
                })
                .ToListAsync();
        }

    }
}
