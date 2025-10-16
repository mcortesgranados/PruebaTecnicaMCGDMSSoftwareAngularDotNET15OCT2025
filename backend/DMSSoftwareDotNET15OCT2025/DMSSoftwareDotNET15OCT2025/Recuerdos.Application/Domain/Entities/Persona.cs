using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DMSSoftwareDotNET15OCT2025.Recuerdos.Domain.Entities
{
    /// <summary>
    /// Entidad que representa a una persona dentro del sistema de recuerdos.
    /// 
    /// Rol en arquitectura hexagonal:
    /// - Parte de la capa de dominio.
    /// - Representa un agregado de negocio con identidad propia (PersonaId).
    /// - Mantiene información relevante del creador y la fecha de creación.
    /// - Permite asociar la persona con múltiples recuerdos a través de RecuerdoPersona.
    /// Cumple principios SOLID, especialmente SRP y OCP.
    /// </summary>
    public class Persona
    {
        [Column("PersonaId")]
        public int PersonaId { get; set; }

        [Column("Nombre")]
        public string Nombre { get; set; } = string.Empty;

        [Column("Descripcion")]
        public string? Descripcion { get; set; }

        [Column("CreadorId")]
        public int CreadorId { get; set; }

        public User Creador { get; set; } = null!;

        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;

        public ICollection<RecuerdoPersona> RecuerdosPersonas { get; set; } = new List<RecuerdoPersona>();
    }
}
