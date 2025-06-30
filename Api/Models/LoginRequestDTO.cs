namespace Api.Models
{
    public class LoginRequestDTO
    {
        public string User { get; set; }
        public string Password { get; set; }
        public string? ApeyNom { get; set; }
        public string? Rol { get; set; }

    }
}
