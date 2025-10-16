using DMSSoftwareDotNET15OCT2025.Recuerdos.Domain.Entities;

namespace DMSSoftwareDotNET15OCT2025.Recuerdos.Infrastructure.Security
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
