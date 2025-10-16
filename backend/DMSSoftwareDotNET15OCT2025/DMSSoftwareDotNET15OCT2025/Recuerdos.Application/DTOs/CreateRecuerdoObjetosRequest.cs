using System.Collections.Generic;

namespace DMSSoftwareDotNET15OCT2025.Recuerdos.Application.DTOs
{
    /// <summary>
    /// DTO para crear y asociar un listado de objetos a un recuerdo.
    /// Contiene la información mínima requerida para crear los objetos
    /// y la asociación con el recuerdo.
    /// </summary>
    public class CreateRecuerdoObjetosRequest
    {
        /// <summary>
        /// Id del recuerdo al que se asociarán los objetos.
        /// </summary>
        public int RecuerdoId { get; set; }

        /// <summary>
        /// Lista de objetos a crear y asociar.
        /// </summary>
        public List<ObjetoDto> Objetos { get; set; } = new();

        /// <summary>
        /// Id del usuario que realiza la asociación.
        /// </summary>
        public int AsociadoPorId { get; set; }
    }

    public class ObjetoDto
    {
        public string Nombre { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
        public int? CreadorId { get; set; } // Si se crea nuevo, se indica el creador
        public int? ObjetoId { get; set; } // Si ya existe, se indica el id
    }
}
