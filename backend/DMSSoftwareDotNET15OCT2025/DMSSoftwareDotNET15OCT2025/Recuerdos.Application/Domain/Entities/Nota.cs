using DMSSoftwareDotNET15OCT2025.Recuerdos.Application.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DMSSoftwareDotNET15OCT2025.Recuerdos.Domain.Entities
{
    /// <summary>
    /// Representa una Nota asociada a un Recuerdo.
    /// Rol en arquitectura hexagonal:
    /// - Entidad del dominio (Domain Layer).
    /// - Contiene la información esencial del negocio: texto, creador y quién la asoció al recuerdo.
    /// - Cumple SOLID: la entidad es responsable únicamente de sus datos y relaciones.
    /// </summary>
    public class Nota
    {
        [Column("NotaId")]
        public int Id { get; set; }

        [Column("RecuerdoId")]
        public int RecuerdoId { get; set; }
        public Recuerdo Recuerdo { get; set; } = null!;

        [Column("Texto")]
        public string Texto { get; set; } = string.Empty;

        [Column("CreadorId")]
        public int CreadorId { get; set; }
        public User Creador { get; set; } = null!;

        [Column("AsociadoPorId")]
        public int AsociadoPorId { get; set; }
        public User AsociadoPor { get; set; } = null!;

        [Column("FechaCreacion")]
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
    }
}
