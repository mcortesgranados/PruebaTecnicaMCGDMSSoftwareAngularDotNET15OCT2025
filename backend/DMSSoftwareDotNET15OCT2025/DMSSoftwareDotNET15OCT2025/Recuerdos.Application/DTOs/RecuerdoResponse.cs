namespace DMSSoftwareDotNET15OCT2025.Recuerdos.Application.DTOs
{
    public class RecuerdoResponse
    {
        public int Id { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaOcurrencia { get; set; }
        public string Situacion { get; set; } = string.Empty;
        public int CreadorId { get; set; }
        public string Estado { get; set; } = string.Empty;
    }
}
