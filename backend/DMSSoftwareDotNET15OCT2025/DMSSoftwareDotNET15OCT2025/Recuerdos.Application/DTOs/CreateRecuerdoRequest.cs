using DMSSoftwareDotNET15OCT2025.Recuerdos.Application.Domain.Entities;

namespace DMSSoftwareDotNET15OCT2025.Recuerdos.Application.DTOs
{
    public class CreateRecuerdoRequest
    {
        // Obligatorio: debe coincidir con la columna NOT NULL en la DB
        public string Titulo { get; set; } = string.Empty;

        // Opcional: corresponde a la columna Descripcion en la DB
        public string Situacion { get; set; } = string.Empty;

        // Obligatorio: fecha del evento
        public DateTime FechaOcurrencia { get; set; }

        // Obligatorio: creador del recuerdo
        public int CreadorId { get; set; }

        // Opcionales para confirmación
        public int? ConfirmadoPorId { get; set; }
        public DateTime? FechaConfirmacion { get; set; }

        // Estado inicial, por defecto Sospecha
        public EstadoRecuerdo Estado { get; set; } = EstadoRecuerdo.Sospecha;
    }
}
