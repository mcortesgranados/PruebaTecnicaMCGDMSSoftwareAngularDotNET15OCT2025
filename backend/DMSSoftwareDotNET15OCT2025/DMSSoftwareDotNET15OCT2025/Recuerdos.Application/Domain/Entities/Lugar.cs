using DMSSoftwareDotNET15OCT2025.Recuerdos.Application.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DMSSoftwareDotNET15OCT2025.Recuerdos.Domain.Entities
{
    /// <summary>
    /// Entidad Lugar.
    /// 
    /// Rol en arquitectura hexagonal:
    /// - Representa un objeto de negocio (Domain Entity) dentro del núcleo de dominio.
    /// - Contiene propiedades que modelan el dominio de manera independiente de la capa de infraestructura o UI.
    /// - Cumple SRP (Single Responsibility Principle) porque solo define datos y relaciones del dominio.
    /// - Cualquier lógica adicional del dominio relacionada con el lugar se implementaría aquí.
    /// </summary>
    public class Lugar
    {
        [Column("LugarId")]
        public int Id { get; set; }

        [Column("Nombre")]
        public string Nombre { get; set; } = string.Empty;

        [Column("Descripcion")]
        public string? Descripcion { get; set; }

        [Column("Direccion")]
        public string? Direccion { get; set; }

        [Column("CreadorId")]
        public int CreadorId { get; set; }

        /// <summary>
        /// Usuario que creó el lugar. Relación con la entidad User.
        /// Parte de la modelación de dominio para mantener integridad referencial.
        /// </summary>
        public User Creador { get; set; } = null!;

        /// <summary>
        /// Fecha de creación del lugar.
        /// </summary>
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
    }

    /// <summary>
    /// Entidad intermedia para asociar Recuerdo y Lugar.
    /// 
    /// Rol en arquitectura hexagonal:
    /// - Modela la relación muchos a muchos entre Recuerdos y Lugares.
    /// - Permite mantener trazabilidad de quién asoció qué lugar a qué recuerdo.
    /// - Se coloca en la capa Domain porque es un concepto del negocio.
    /// </summary>
    public class RecuerdoLugar
    {
        public int RecuerdoId { get; set; }
        public Recuerdo Recuerdo { get; set; } = null!;

        public int LugarId { get; set; }
        public Lugar Lugar { get; set; } = null!;

        public int AsociadoPorId { get; set; }
        public User AsociadoPor { get; set; } = null!;

        public DateTime FechaAsociacion { get; set; } = DateTime.UtcNow;
    }
}
