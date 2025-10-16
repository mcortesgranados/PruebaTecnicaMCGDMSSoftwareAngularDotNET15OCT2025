using DMSSoftwareDotNET15OCT2025.Recuerdos.Application.DTOs;
using DMSSoftwareDotNET15OCT2025.Recuerdos.Domain.Entities;
using DMSSoftwareDotNET15OCT2025.Recuerdos.Infrastructure.Repositories;
using System.Threading.Tasks;

namespace DMSSoftwareDotNET15OCT2025.Recuerdos.Application.Services
{
    /// <summary>
    /// Servicio de aplicación para manejar personas y su asociación con recuerdos.
    /// Implementa la lógica de negocio y coordina los repositorios de infraestructura.
    /// </summary>
    public class PersonaService
    {
        private readonly PersonaRepository _personaRepo;
        private readonly RecuerdoPersonaRepository _recuerdoPersonaRepo;

        public PersonaService(PersonaRepository personaRepo, RecuerdoPersonaRepository recuerdoPersonaRepo)
        {
            _personaRepo = personaRepo;
            _recuerdoPersonaRepo = recuerdoPersonaRepo;
        }

        /// <summary>
        /// Crea una persona y la asocia a un recuerdo.
        /// </summary>
        public async Task<RecuerdoPersona> CrearYAsociarAsync(AsociarPersonaRecuerdoRequest request)
        {
            // Crear Persona
            var persona = new Persona
            {
                Nombre = request.NombrePersona,
                Descripcion = request.Descripcion,
                CreadorId = request.CreadorId
            };

            var personaCreada = await _personaRepo.AddAsync(persona);

            // Crear asociación Recuerdo-Persona
            var rp = new RecuerdoPersona
            {
                RecuerdoId = request.RecuerdoId,
                PersonaId = personaCreada.PersonaId,
                AsociadoPorId = request.AsociadoPorId
            };

            return await _recuerdoPersonaRepo.AddAsync(rp);
        }
    }
}
