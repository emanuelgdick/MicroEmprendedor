using Api.Models;

namespace Api.Models
{
    public class LoginResponseDTO
    {

        public Usuario Usuario { get; set; }
        public string Token { get; set; }
    }
}
