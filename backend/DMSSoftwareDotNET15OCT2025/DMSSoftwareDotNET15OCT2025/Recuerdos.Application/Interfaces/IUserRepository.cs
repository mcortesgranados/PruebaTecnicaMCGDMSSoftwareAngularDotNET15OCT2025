using DMSSoftwareDotNET15OCT2025.Recuerdos.Domain.Entities;

namespace DMSSoftwareDotNET15OCT2025.Recuerdos.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync(string email);
        Task<User?> GetByIdAsync(int id);
        Task<User> CreateAsync(User user);
        Task SaveChangesAsync();
    }
}
