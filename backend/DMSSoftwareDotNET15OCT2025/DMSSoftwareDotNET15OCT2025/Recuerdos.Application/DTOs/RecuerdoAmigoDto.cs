namespace DMSSoftwareDotNET15OCT2025.Recuerdos.Application.DTOs
{
    public class RecuerdoAmigoDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string? Situacion { get; set; }
        public DateTime FechaOcurrencia { get; set; }
        public string Estado { get; set; } = string.Empty;
        public string CreadorNombre { get; set; } = string.Empty;
    }
}
