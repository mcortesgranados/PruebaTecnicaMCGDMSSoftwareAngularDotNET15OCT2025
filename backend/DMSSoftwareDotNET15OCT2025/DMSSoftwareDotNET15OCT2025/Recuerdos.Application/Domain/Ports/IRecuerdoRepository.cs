using DMSSoftwareDotNET15OCT2025.Recuerdos.Application.Domain.Entities;

namespace DMSSoftwareDotNET15OCT2025.Recuerdos.Application.Domain.Ports
{
    public interface IRecuerdoRepository
    {
        Task<Recuerdo> AddAsync(Recuerdo recuerdo);
        Task<Recuerdo?> GetByIdAsync(int id);
        Task<List<Recuerdo>> GetByUserIdAsync(int userId);
        Task UpdateAsync(Recuerdo recuerdo);
        public Task<List<Recuerdo>> BuscarRecuerdosAsync(string palabraClave);
    }
}
