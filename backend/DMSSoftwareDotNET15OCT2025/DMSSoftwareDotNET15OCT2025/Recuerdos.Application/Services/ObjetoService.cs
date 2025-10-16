using DMSSoftwareDotNET15OCT2025.Recuerdos.Application.DTOs;
using DMSSoftwareDotNET15OCT2025.Recuerdos.Domain.Entities;
using DMSSoftwareDotNET15OCT2025.Recuerdos.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DMSSoftwareDotNET15OCT2025.Recuerdos.Application.Services
{
    public class ObjetoService
    {
        private readonly ApplicationDbContext _db;

        public ObjetoService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<Objeto>> AsociarObjetosRecuerdoAsync(AsociarObjetosRecuerdoRequest request)
        {
            var resultado = new List<Objeto>();

            foreach (var dto in request.Objetos)
            {
                Objeto objeto;

                if (dto.ObjetoId.HasValue)
                {
                    objeto = await _db.Objetos.FindAsync(dto.ObjetoId.Value)
                             ?? throw new Exception($"Objeto con Id {dto.ObjetoId.Value} no encontrado.");
                }
                else
                {
                    objeto = new Objeto
                    {
                        Nombre = dto.Nombre,
                        Descripcion = dto.Descripcion,
                        CreadorId = dto.CreadorId ?? request.AsociadoPorId,
                        FechaCreacion = DateTime.UtcNow
                    };
                    _db.Objetos.Add(objeto);
                    await _db.SaveChangesAsync();
                }

                var rl = new RecuerdoObjeto
                {
                    RecuerdoId = request.RecuerdoId,
                    ObjetoId = objeto.Id,
                    AsociadoPorId = request.AsociadoPorId,
                    FechaAsociacion = DateTime.UtcNow
                };
                _db.Recuerdos_Objetos.Add(rl);

                resultado.Add(objeto);
            }

            await _db.SaveChangesAsync();
            return resultado;
        }
    }
}
