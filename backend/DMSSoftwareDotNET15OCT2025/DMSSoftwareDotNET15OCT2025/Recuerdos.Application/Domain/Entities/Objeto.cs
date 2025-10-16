using DMSSoftwareDotNET15OCT2025.Recuerdos.Application.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DMSSoftwareDotNET15OCT2025.Recuerdos.Domain.Entities
{
    /// <summary>
    /// Representa un Objeto que puede estar asociado a recuerdos.
    /// Parte del dominio, persistencia independiente (hexagonal).
    /// </summary>
    public class Objeto
    {
        [Column("ObjetoId")]
        public int Id { get; set; }  // EF ahora sabe que Id corresponde a ObjetoId

        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public int CreadorId { get; set; }
        public User Creador { get; set; } = null!;
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
    }

}
