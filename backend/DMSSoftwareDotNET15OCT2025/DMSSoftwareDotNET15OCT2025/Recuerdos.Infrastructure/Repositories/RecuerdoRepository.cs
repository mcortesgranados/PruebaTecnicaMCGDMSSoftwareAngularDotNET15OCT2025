using DMSSoftwareDotNET15OCT2025.Recuerdos.Application.Domain.Ports;
using DMSSoftwareDotNET15OCT2025.Recuerdos.Application.Domain.Ports;
using DMSSoftwareDotNET15OCT2025.Recuerdos.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DMSSoftwareDotNET15OCT2025.Recuerdos.Application.Domain.Entities;

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
    }
}
