namespace Api.Models.DTOs
{
    public class TotalesDTO
    {

        public int TotalUsuarios { get; set; }
        public int TotalSocios { get; set; }
        public int TotalSociosActivos { get; set; }
        public int TotalSociosDadosDeBaja { get; set; }
        public int TotalSociosSuspendidos { get; set; }
        public int TotalSociosVitalicios { get; set; }
        public int TotalMateriales { get; set; }
        public int TotalVideos { get; set; }
        public int TotalLibros { get; set; }
        public int TotalNovelas { get; set; }
        public int TotalMovimientos { get; set; }
        public int TotalPrestamos { get; set; }
        public int TotalReservas { get; set; }
        public int TotalCobradores { get; set; }
        public decimal TotalDeuda { get; set; }

    }
}
