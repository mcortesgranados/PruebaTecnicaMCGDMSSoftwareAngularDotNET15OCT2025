using DMSSoftwareDotNET15OCT2025.Recuerdos.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace DMSSoftwareDotNET15OCT2025.Recuerdos.Application.Domain.Models
{
    public enum EstadoRecuerdo
    {
        Sospecha,
        Confirmado
    }

    public class Recuerdo
    {
        [Column("RecuerdoId")]
        public int Id { get; set; } // PK, identity

        [Column("Titulo")]
        public string Titulo { get; set; } = string.Empty; // NOT NULL

        [Column("Descripcion")]
        public string? Situacion { get; set; } // NULL permitido en DB

        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow; // default GETDATE()

        [Column("FechaEvento")]
        public DateTime FechaOcurrencia { get; set; } // NOT NULL

        [Column("Estado")]
        public EstadoRecuerdo? Estado { get; set; } = EstadoRecuerdo.Sospecha; // NULL permitido en DB, default Sospecha

        [Column("CreadorId")]
        public int CreadorId { get; set; } // FK NOT NULL

        public User Creador { get; set; } = null!;

        [Column("ConfirmadoPorId")]
        public int? ConfirmadoPorId { get; set; } // FK NULL permitido

        public User? ConfirmadoPor { get; set; }

        [Column("FechaConfirmacion")]
        public DateTime? FechaConfirmacion { get; set; } // NULL permitido
    }
}
