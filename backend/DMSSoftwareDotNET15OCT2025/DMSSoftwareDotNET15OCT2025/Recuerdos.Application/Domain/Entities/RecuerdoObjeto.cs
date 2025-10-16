using DMSSoftwareDotNET15OCT2025.Recuerdos.Application.Domain.Entities;
using System;

namespace DMSSoftwareDotNET15OCT2025.Recuerdos.Domain.Entities
{
    /// <summary>
    /// Entidad intermedia que representa la asociación entre Recuerdo y Objeto.
    /// Guarda quién realizó la asociación y cuándo.
    /// </summary>
    public class RecuerdoObjeto
    {
        public int RecuerdoId { get; set; }
        public Recuerdo Recuerdo { get; set; } = null!;

        public int ObjetoId { get; set; }
        public Objeto Objeto { get; set; } = null!;

        public int AsociadoPorId { get; set; }
        public User AsociadoPor { get; set; } = null!;

        public DateTime FechaAsociacion { get; set; } = DateTime.UtcNow;
    }
}
