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

            // Verificar que el recuerdo exista
            var recuerdo = await _db.Recuerdos.FindAsync(request.RecuerdoId);
            if (recuerdo == null)
                throw new Exception($"Recuerdo con Id {request.RecuerdoId} no encontrado.");

            // Verificar que el usuario asociado exista
            var asociadoPor = await _db.Usuarios.FindAsync(request.AsociadoPorId);
            if (asociadoPor == null)
                throw new Exception($"Usuario asociado con Id {request.AsociadoPorId} no encontrado.");

            foreach (var dto in request.Objetos)
            {
                Objeto objeto;

                if (dto.ObjetoId.HasValue)
                {
                    // Buscar el objeto existente
                    objeto = await _db.Objetos.FindAsync(dto.ObjetoId.Value);
                    if (objeto == null)
                        throw new Exception($"Objeto con Id {dto.ObjetoId.Value} no encontrado.");
                }
                else
                {
                    // Crear un nuevo objeto si no existe
                    objeto = new Objeto
                    {
                        Nombre = dto.Nombre,
                        Descripcion = dto.Descripcion,
                        CreadorId = dto.CreadorId ?? request.AsociadoPorId,
                        FechaCreacion = DateTime.UtcNow
                    };
                    _db.Objetos.Add(objeto);
                    await _db.SaveChangesAsync(); // Guardar para obtener el Id
                }

                // Verificar si la asociación ya existe
                bool yaAsociado = await _db.Recuerdos_Objetos
                    .AnyAsync(rl => rl.RecuerdoId == request.RecuerdoId && rl.ObjetoId == objeto.Id);

                if (!yaAsociado)
                {
                    // Crear la asociación
                    var rl = new RecuerdoObjeto
                    {
                        RecuerdoId = request.RecuerdoId,
                        ObjetoId = objeto.Id,
                        AsociadoPorId = request.AsociadoPorId,
                        FechaAsociacion = DateTime.UtcNow
                    };
                    _db.Recuerdos_Objetos.Add(rl);
                }

                resultado.Add(objeto);
            }

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception($"Error al asociar objetos: {ex.InnerException?.Message ?? ex.Message}");
            }

            return resultado;
        }


    }
}
