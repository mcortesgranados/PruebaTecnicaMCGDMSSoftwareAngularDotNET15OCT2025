using Microsoft.EntityFrameworkCore;

using DMSSoftwareDotNET15OCT2025.Recuerdos.Application.Interfaces;
using DMSSoftwareDotNET15OCT2025.Recuerdos.Domain.Entities;
using DMSSoftwareDotNET15OCT2025.Recuerdos.Infrastructure.Persistence;
using System.Threading.Tasks;


namespace DMSSoftwareDotNET15OCT2025.Recuerdos.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _ctx;
        public UserRepository(ApplicationDbContext ctx) => _ctx = ctx;

        public async Task<User?> GetByEmailAsync(string email) =>
            await _ctx.Usuarios.AsNoTracking().FirstOrDefaultAsync(u => u.Email == email);

        public async Task<User?> GetByIdAsync(int id) =>
            await _ctx.Usuarios.FindAsync(id);

        public async Task<User> CreateAsync(User user)
        {
            var ent = (await _ctx.Usuarios.AddAsync(user)).Entity;
            return ent;
        }

        public async Task SaveChangesAsync() => await _ctx.SaveChangesAsync();
    }
}
