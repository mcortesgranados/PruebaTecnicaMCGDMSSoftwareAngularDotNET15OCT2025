using System;

namespace DMSSoftwareDotNET15OCT2025.Recuerdos.Application.DTOs
{
    /// <summary>
    /// DTO para crear un nuevo lugar.
    /// 
    /// Rol en la arquitectura hexagonal:
    /// - Forma parte de la capa Application (Application Services).
    /// - Su responsabilidad es transferir datos desde la capa externa (API, UI) hacia la capa de dominio.
    /// - Permite separar la lógica de negocio (Domain) de la entrada de datos, cumpliendo SRP (Single Responsibility Principle).
    /// 
    /// Autor: Manuela Cortés Granados (manuelacortesgranados@gmail.com)
    /// Versión: 1.0
    /// Since: 16/10/2025
    /// </summary>
    public class CreateLugarRequest
    {
        /// <summary>
        /// Nombre del lugar. Campo obligatorio.
        /// </summary>
        public string Nombre { get; set; } = string.Empty;

        /// <summary>
        /// Descripción opcional del lugar.
        /// </summary>
        public string? Descripcion { get; set; }

        /// <summary>
        /// Dirección opcional del lugar.
        /// </summary>
        public string? Direccion { get; set; }

        /// <summary>
        /// Identificador del usuario creador. Necesario para mantener trazabilidad.
        /// </summary>
        public int CreadorId { get; set; }
    }

    /// <summary>
    /// DTO para asociar un lugar a un recuerdo.
    /// 
    /// Rol en la arquitectura hexagonal:
    /// - Permite que la capa externa (controlador API) envíe datos necesarios para la asociación.
    /// - Separa la estructura de datos de la lógica de negocio del dominio.
    /// - Facilita validación y transformación de datos antes de llegar al dominio.
    /// </summary>
    public class AsociarLugarRecuerdoRequest
    {
        /// <summary>
        /// Identificador del recuerdo.
        /// </summary>
        public int RecuerdoId { get; set; }

        /// <summary>
        /// Identificador del lugar.
        /// </summary>
        public int LugarId { get; set; }

        /// <summary>
        /// Identificador del usuario que realiza la asociación.
        /// Mantiene trazabilidad de acciones.
        /// </summary>
        public int AsociadoPorId { get; set; }
    }
}
