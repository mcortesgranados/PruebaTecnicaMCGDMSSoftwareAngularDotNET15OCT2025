using DMSSoftwareDotNET15OCT2025.Recuerdos.Domain.Entities;
using DMSSoftwareDotNET15OCT2025.Recuerdos.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DMSSoftwareDotNET15OCT2025.Recuerdos.Infrastructure.Repositories
{
    /// <summary>
    /// Repositorio para CRUD de Persona.
    /// Parte de la capa de infraestructura, encargado de persistir la entidad Persona.
    /// </summary>
    public class PersonaRepository
    {
        private readonly ApplicationDbContext _db;

        public PersonaRepository(ApplicationDbContext db) => _db = db;

        public async Task<Persona> AddAsync(Persona persona)
        {
            _db.Personas.Add(persona);
            await _db.SaveChangesAsync();
            return persona;
        }
    }

    /// <summary>
    /// Repositorio para manejar la asociación Recuerdo-Persona.
    /// </summary>
    public class RecuerdoPersonaRepository
    {
        private readonly ApplicationDbContext _db;

        public RecuerdoPersonaRepository(ApplicationDbContext db) => _db = db;

        public async Task<RecuerdoPersona> AddAsync(RecuerdoPersona rp)
        {
            _db.Recuerdos_Personas.Add(rp);
            await _db.SaveChangesAsync();
            return rp;
        }
    }
}
