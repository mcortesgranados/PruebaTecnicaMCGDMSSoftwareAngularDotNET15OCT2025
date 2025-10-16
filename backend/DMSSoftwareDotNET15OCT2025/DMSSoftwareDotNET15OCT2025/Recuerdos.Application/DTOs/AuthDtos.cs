namespace DMSSoftwareDotNET15OCT2025.Recuerdos.Application.DTOs
{
    public record RegisterRequest(string Nombre, string Email, string Password);
    public record LoginRequest(string Email, string Password);
    public record AuthResponse(string Token, int UsuarioId, string Nombre, string Email);
}
