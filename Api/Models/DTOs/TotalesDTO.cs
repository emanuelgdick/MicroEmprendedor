namespace Api.Models.DTOs
{
    public class TotalesDTO
    {

        public int TotalUsuarios { get; set; }
        public int TotalPacientes { get; set; }
        public int TotalMutuales { get; set; }
        public int TotalMedicos { get; set; }
        public int TotalConsultas { get; set; }
        public Usuario Usuario { get; set; }

    }
}
