using BCrypt.Net;
using DMSSoftwareDotNET15OCT2025.Recuerdos.Application.DTOs;
using DMSSoftwareDotNET15OCT2025.Recuerdos.Application.Interfaces;
using DMSSoftwareDotNET15OCT2025.Recuerdos.Domain.Entities;
using DMSSoftwareDotNET15OCT2025.Recuerdos.Infrastructure.Security;
using System;
using System.Threading.Tasks;

namespace DMSSoftwareDotNET15OCT2025.Recuerdos.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepo;
        private readonly ITokenService _tokenService;

        public AuthService(IUserRepository userRepo, ITokenService tokenService)
        {
            _userRepo = userRepo;
            _tokenService = tokenService;
        }

        public async Task<AuthResponse> RegisterAsync(RegisterRequest request)
        {
            var existing = await _userRepo.GetByEmailAsync(request.Email);
            if (existing != null)
                throw new InvalidOperationException("Email already in use.");

            var hashed = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var user = new User
            {
                Nombre = request.Nombre,
                Email = request.Email,
                PasswordHash = hashed,
                FechaRegistro = DateTime.UtcNow,
                EsActivo = true
            };

            await _userRepo.CreateAsync(user);
            await _userRepo.SaveChangesAsync();

            // after save, user.UsuarioId populated by EF
            var token = _tokenService.GenerateToken(user);
            return new AuthResponse(token, user.UsuarioId, user.Nombre, user.Email);
        }

        public async Task<AuthResponse?> LoginAsync(LoginRequest request)
        {
            var user = await _userRepo.GetByEmailAsync(request.Email);
            if (user == null) return null;

            var valid = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);
            if (!valid) return null;

            var token = _tokenService.GenerateToken(user);
            return new AuthResponse(token, user.UsuarioId, user.Nombre, user.Email);
        }
    }
}
