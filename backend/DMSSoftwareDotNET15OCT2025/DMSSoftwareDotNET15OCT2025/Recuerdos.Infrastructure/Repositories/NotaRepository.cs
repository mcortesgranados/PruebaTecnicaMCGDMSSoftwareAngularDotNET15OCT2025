using DMSSoftwareDotNET15OCT2025.Recuerdos.Domain.Entities;
using DMSSoftwareDotNET15OCT2025.Recuerdos.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DMSSoftwareDotNET15OCT2025.Recuerdos.Infrastructure.Repositories
{
    /// <summary>
    /// Repositorio para CRUD de Notas.
    /// Rol en arquitectura hexagonal:
    /// - Parte de la capa de infraestructura.
    /// - Responsable de persistir las Notas en la base de datos.
    /// - Cumple DIP, permitiendo que la capa de dominio dependa de interfaces y no de implementaciones concretas.
    /// </summary>
    public class NotaRepository
    {
        private readonly ApplicationDbContext _db;

        public NotaRepository(ApplicationDbContext db) => _db = db;

        public async Task<Nota> AddAsync(Nota nota)
        {
            _db.Notas.Add(nota);
            await _db.SaveChangesAsync();
            return nota;
        }
    }
}
