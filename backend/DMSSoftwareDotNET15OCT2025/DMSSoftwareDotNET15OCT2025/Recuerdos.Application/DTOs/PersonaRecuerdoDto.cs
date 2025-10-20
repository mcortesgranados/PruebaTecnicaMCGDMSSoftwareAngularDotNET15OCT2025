namespace DMSSoftwareDotNET15OCT2025.Recuerdos.Application.DTOs
{
    public class PersonaRecuerdoDto
    {
        public int PersonaId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
        public DateTime FechaAsociacion { get; set; }
        public string AsociadoPorNombre { get; set; } = string.Empty;
    }
}
