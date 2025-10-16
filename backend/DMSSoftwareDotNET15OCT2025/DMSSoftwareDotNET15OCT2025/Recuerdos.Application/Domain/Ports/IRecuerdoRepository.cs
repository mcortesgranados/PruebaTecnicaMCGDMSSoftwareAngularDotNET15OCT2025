using DMSSoftwareDotNET15OCT2025.Recuerdos.Application.Domain.Models;

namespace DMSSoftwareDotNET15OCT2025.Recuerdos.Application.Domain.Ports
{
    public interface IRecuerdoRepository
    {
        Task<Recuerdo> AddAsync(Recuerdo recuerdo);
        Task<Recuerdo?> GetByIdAsync(int id);
        Task<List<Recuerdo>> GetByUserIdAsync(int userId);
        Task UpdateAsync(Recuerdo recuerdo);
    }
}
