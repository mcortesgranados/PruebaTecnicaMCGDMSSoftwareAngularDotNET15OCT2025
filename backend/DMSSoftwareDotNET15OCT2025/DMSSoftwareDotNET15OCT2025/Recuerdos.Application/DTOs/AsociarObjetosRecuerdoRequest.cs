namespace DMSSoftwareDotNET15OCT2025.Recuerdos.Application.DTOs
{
    /// <summary>
    /// DTO para asociar un listado de objetos a un recuerdo.
    /// </summary>
    public class AsociarObjetosRecuerdoRequest
    {
        /// <summary>
        /// Id del recuerdo al que se asociarán los objetos.
        /// </summary>
        public int RecuerdoId { get; set; }

        /// <summary>
        /// Lista de objetos a asociar (solo nombre y descripción si se crean nuevos).
        /// </summary>
        public List<ObjetoDto> Objetos { get; set; } = new();

        /// <summary>
        /// Id del usuario que realiza la asociación (puede ser distinto al creador del objeto).
        /// </summary>
        public int AsociadoPorId { get; set; }
    }

}
