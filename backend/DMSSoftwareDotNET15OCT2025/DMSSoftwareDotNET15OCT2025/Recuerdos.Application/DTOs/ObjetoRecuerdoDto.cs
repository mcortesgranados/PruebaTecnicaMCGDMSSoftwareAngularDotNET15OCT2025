namespace DMSSoftwareDotNET15OCT2025.Recuerdos.Application.DTOs
{
    public class ObjetoRecuerdoDto
    {
        public int ObjetoId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
        public string CreadorNombre { get; set; } = string.Empty;
        public DateTime FechaAsociacion { get; set; }
    }
}
