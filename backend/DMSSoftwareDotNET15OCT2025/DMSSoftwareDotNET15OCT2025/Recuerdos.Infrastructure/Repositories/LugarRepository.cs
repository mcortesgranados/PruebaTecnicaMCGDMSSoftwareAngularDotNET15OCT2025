using DMSSoftwareDotNET15OCT2025.Recuerdos.Domain.Entities;
using DMSSoftwareDotNET15OCT2025.Recuerdos.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DMSSoftwareDotNET15OCT2025.Recuerdos.Infrastructure.Repositories
{
    /// <summary>
    /// Repositorio para CRUD de Lugar.
    /// 
    /// Rol en arquitectura hexagonal:
    /// - Parte de la capa de infraestructura (Infrastructure).
    /// - Se encarga de la persistencia de la entidad Lugar hacia la base de datos.
    /// - Implementa la abstracción de persistencia requerida por la capa de dominio.
    /// - Cumple DIP (Dependency Inversion Principle) ya que el dominio depende de interfaces, no de implementaciones concretas.
    /// </summary>
    public class LugarRepository
    {
        private readonly ApplicationDbContext _db;

        public LugarRepository(ApplicationDbContext db) => _db = db;

        public async Task<Lugar> AddAsync(Lugar lugar)
        {
            _db.Lugares.Add(lugar);
            await _db.SaveChangesAsync();
            return lugar;
        }
    }

    /// <summary>
    /// Repositorio para manejar la asociación Recuerdo-Lugar.
    /// </summary>
    public class RecuerdoLugarRepository
    {
        private readonly ApplicationDbContext _db;

        public RecuerdoLugarRepository(ApplicationDbContext db) => _db = db;

        public async Task<RecuerdoLugar> AddAsync(RecuerdoLugar rl)
        {
            _db.Recuerdos_Lugares.Add(rl);
            await _db.SaveChangesAsync();
            return rl;
        }
    }
}
