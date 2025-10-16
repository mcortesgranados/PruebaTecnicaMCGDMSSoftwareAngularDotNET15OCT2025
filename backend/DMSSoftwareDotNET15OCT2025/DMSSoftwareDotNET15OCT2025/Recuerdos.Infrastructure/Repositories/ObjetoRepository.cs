using DMSSoftwareDotNET15OCT2025.Recuerdos.Domain.Entities;
using DMSSoftwareDotNET15OCT2025.Recuerdos.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DMSSoftwareDotNET15OCT2025.Recuerdos.Infrastructure.Repositories
{
    /// <summary>
    /// Repositorio para manejar persistencia de Objetos.
    /// Rol: Infraestructura en arquitectura hexagonal.
    /// </summary>
    public class ObjetoRepository
    {
        private readonly ApplicationDbContext _db;

        public ObjetoRepository(ApplicationDbContext db) => _db = db;

        public async Task<List<Objeto>> AddRangeAsync(List<Objeto> objetos)
        {
            _db.Objetos.AddRange(objetos);
            await _db.SaveChangesAsync();
            return objetos;
        }
    }

    /// <summary>
    /// Repositorio para manejar la asociación Recuerdo-Objeto.
    /// </summary>
    public class RecuerdoObjetoRepository
    {
        private readonly ApplicationDbContext _db;

        public RecuerdoObjetoRepository(ApplicationDbContext db) => _db = db;

        public async Task<List<RecuerdoObjeto>> AddRangeAsync(List<RecuerdoObjeto> asociaciones)
        {
            _db.Recuerdos_Objetos.AddRange(asociaciones);
            await _db.SaveChangesAsync();
            return asociaciones;
        }
    }
}
