using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Custom;
using Backend.Models;
using Backend.Models.DTOs;
using Microsoft.AspNetCore.Authorization;


namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class AccesoController : ControllerBase
    {
        private readonly BibliotecaContext _BibliotecaContext;
        private readonly Utilidades _utilidades;
        public AccesoController(BibliotecaContext BibliotecaContext, Utilidades utilidades)
        {
            _BibliotecaContext = BibliotecaContext;
            _utilidades = utilidades;
        }

        [HttpPost]
        [Route("Registrarse")]
        public async Task<IActionResult> Registrarse(UsuarioDTO objeto)
        {

            var modeloUsuario = new Usuario
            {
               ApeyNom = objeto.Nombre,
               Correo = objeto.Correo,
               Clave = _utilidades.encriptarSHA256(objeto.Clave)
            };

            await _BibliotecaContext.Usuarios.AddAsync(modeloUsuario);
            await _BibliotecaContext.SaveChangesAsync();

            if(modeloUsuario.Id != 0) 
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = true });
            else
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = false });
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginDTO objeto)
        {
            var usuarioEncontrado = await _BibliotecaContext.Usuarios
                                                    .Where(u => 
                                                        u.Correo == objeto.Correo &&
                                                        u.Clave == _utilidades.encriptarSHA256(objeto.Clave)
                                                      ).FirstOrDefaultAsync();

            if (usuarioEncontrado == null)
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = false, token = "" });
            else
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = true, token = _utilidades.generarJWT(usuarioEncontrado)});
        }
    }
}
