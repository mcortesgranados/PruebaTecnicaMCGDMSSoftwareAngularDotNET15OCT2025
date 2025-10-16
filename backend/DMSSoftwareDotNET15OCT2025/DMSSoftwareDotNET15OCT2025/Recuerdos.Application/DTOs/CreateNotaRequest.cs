using System;

namespace DMSSoftwareDotNET15OCT2025.Recuerdos.Application.DTOs
{
    /// <summary>
    /// DTO para la creación de una Nota y asociación a un Recuerdo.
    /// Rol en arquitectura hexagonal:
    /// - Parte de la capa de aplicación (Application Layer).
    /// - Transporta los datos entre la capa de presentación y la capa de dominio.
    /// </summary>
    public class CreateNotaRequest
    {
        public int RecuerdoId { get; set; }
        public string Texto { get; set; } = string.Empty;
        public int CreadorId { get; set; }
        public int AsociadoPorId { get; set; }
    }
}
