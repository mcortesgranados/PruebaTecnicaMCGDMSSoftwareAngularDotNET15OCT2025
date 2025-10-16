using System.ComponentModel.DataAnnotations;

namespace DMSSoftwareDotNET15OCT2025.Recuerdos.Application.DTOs
{
    /// <summary>
    /// DTO para asociar una persona a un recuerdo.
    /// Contiene la información necesaria para registrar la persona y la asociación.
    /// </summary>
    public class AsociarPersonaRecuerdoRequest
    {
        [Required]
        public int RecuerdoId { get; set; }

        [Required]
        public string NombrePersona { get; set; } = string.Empty;

        public string? Descripcion { get; set; }

        [Required]
        public int CreadorId { get; set; }

        [Required]
        public int AsociadoPorId { get; set; }
    }
}
