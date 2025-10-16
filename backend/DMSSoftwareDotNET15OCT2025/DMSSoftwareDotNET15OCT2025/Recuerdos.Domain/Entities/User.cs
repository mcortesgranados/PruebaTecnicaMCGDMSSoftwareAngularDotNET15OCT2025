namespace DMSSoftwareDotNET15OCT2025.Recuerdos.Domain.Entities
{
    using System;
    public class User
    {
        public int UsuarioId { get; set; }           // corresponde a UsuarioId en BD
        public string Nombre { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public DateTime FechaRegistro { get; set; }
        public bool EsActivo { get; set; } = true;
    }
}
