using Api.Models;
//using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Numerics;
using Microsoft.AspNetCore.Authorization;
namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private MicroEmprendedorContext _db;
        private string _SecretKey;

        public UsuarioController(MicroEmprendedorContext db, IConfiguration configuration)
        {
            _db = db;
            _SecretKey = configuration.GetValue<string>("ApiSettings:Secret");
        }

        [HttpPost("UserLogin")]
        public async Task<LoginResponseDTO> Login( LoginRequestDTO logindetails)
        {
            var user = _db.Usuario.FirstOrDefault(u => u.User.ToLower() == logindetails.User.ToLower()
            && u.Password.ToLower() == RecursosBiz.ConvertirSha256(logindetails.Password.ToLower()));


            if (user == null)
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_SecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Rol),
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            LoginResponseDTO loginResponse = new LoginResponseDTO()
            {
                Token = tokenHandler.WriteToken(token),
                Usuario = user,
            };

            return loginResponse;
        }


        [HttpPost("AddUser")]
        public async Task<Usuario> AddUser([FromBody] LoginRequestDTO usuario)
        {
            if (!ModelState.IsValid)
            {
                return null;//BadRequest(ModelState);
            }
            Usuario u = new Usuario();
            u.Rol = usuario.Rol;
            u.ApeyNom = usuario.ApeyNom;
            u.User = usuario.User;
            u.Password = RecursosBiz.ConvertirSha256(usuario.Password);
            _db.Usuario.Add(u);
            _db.SaveChanges();
            return u;//Ok(u);

        }

    }
}
