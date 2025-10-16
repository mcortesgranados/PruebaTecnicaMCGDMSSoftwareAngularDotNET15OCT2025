using DMSSoftwareDotNET15OCT2025.Recuerdos.Application.DTOs;
using DMSSoftwareDotNET15OCT2025.Recuerdos.Domain.Entities;
using DMSSoftwareDotNET15OCT2025.Recuerdos.Infrastructure.Repositories;
using System.Threading.Tasks;

namespace DMSSoftwareDotNET15OCT2025.Recuerdos.Application.Services
{
    /// <summary>
    /// Servicio de aplicación para gestionar Notas.
    /// Rol en arquitectura hexagonal:
    /// - Parte de la capa de aplicación (Application Layer).
    /// - Contiene la lógica de negocio específica para crear y asociar notas a recuerdos.
    /// - Usa repositorios de infraestructura para persistir datos.
    /// </summary>
    public class NotaService
    {
        private readonly NotaRepository _notaRepository;

        public NotaService(NotaRepository notaRepository)
        {
            _notaRepository = notaRepository;
        }

        public async Task<Nota> CrearYAsociarNotaAsync(CreateNotaRequest request)
        {
            var nota = new Nota
            {
                RecuerdoId = request.RecuerdoId,
                Texto = request.Texto,
                CreadorId = request.CreadorId,
                AsociadoPorId = request.AsociadoPorId
            };

            return await _notaRepository.AddAsync(nota);
        }
    }
}
