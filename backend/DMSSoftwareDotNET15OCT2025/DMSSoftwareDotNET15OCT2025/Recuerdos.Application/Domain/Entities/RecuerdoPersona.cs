using DMSSoftwareDotNET15OCT2025.Recuerdos.Application.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DMSSoftwareDotNET15OCT2025.Recuerdos.Domain.Entities
{
    /// <summary>
    /// Entidad intermedia que representa la asociación entre un Recuerdo y una Persona.
    /// 
    /// Rol en arquitectura hexagonal:
    /// - Parte de la capa de dominio, modelando una relación N:M.
    /// - Permite registrar quién asoció la persona al recuerdo (AsociadoPorId).
    /// - Facilita la persistencia en la capa de infraestructura mediante un repositorio.
    /// - Cumple SRP y DIP: la lógica de asociación puede evolucionar sin afectar otras entidades.
    /// </summary>
    public class RecuerdoPersona
    {
        [Column("RecuerdoId")]
        public int RecuerdoId { get; set; }

        public Recuerdo Recuerdo { get; set; } = null!;

        [Column("PersonaId")]
        public int PersonaId { get; set; }

        public Persona Persona { get; set; } = null!;

        [Column("AsociadoPorId")]
        public int AsociadoPorId { get; set; }

        public User AsociadoPor { get; set; } = null!;

        public DateTime FechaAsociacion { get; set; } = DateTime.UtcNow;
    }
}
