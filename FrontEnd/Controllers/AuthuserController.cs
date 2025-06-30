using Frontend.Models;
using FrontEnd.Models;
using FrontEnd.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FrontEnd.Controllers
{
    public class AuthuserController : Controller
    {
        private readonly ApiUserService _apiService;

        public AuthuserController()
        {
            _apiService = new ApiUserService();
        }

        public IActionResult Login()
        {

            //LoginRequestDTO obj = new LoginRequestDTO();
          
            return View(/*obj*/);
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO obj)
        {

            LoginResponseDTO objResponse = new LoginResponseDTO();
            objResponse = await _apiService.AuthenticateUser(obj);
            if (objResponse != null && objResponse.Token.ToString() != "")
            {
                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                identity.AddClaim(new Claim(ClaimTypes.Name, objResponse.Usuario.ApeyNom));
                identity.AddClaim(new Claim(ClaimTypes.Role, objResponse.Usuario.Rol));
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, objResponse.Usuario.Id.ToString()));
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                HttpContext.Session.SetString("APIToken", objResponse.Token);
                //Usuario usuario = new Usuario();
                //usuario.User = objResponse.Usuario.User;
                //usuario.Password = objResponse.Usuario.Password;
                //usuario.ApeyNom = objResponse.Usuario.ApeyNom;
                //usuario.Rol = objResponse.Usuario.Rol;
                //ViewData["ApeyNom"] = usuario.ApeyNom;
                return Json(new { success = true, token = objResponse.Token});
                
                //return usuario;

            }
            else
            {
                HttpContext.Session.SetString("APIToken", "");
                return Json(new { success = false, message = "Credenciales inválidas" });
            }
        }

        //[HttpPost]
        //// [ValidateAntiForgeryToken]
        //public async Task<IActionResult> AddUser([FromBody] LoginRequestDTO obj)
        //{

        //    Usuario objResponse = new Usuario();
        //    objResponse = await _apiService.AddUser(obj);
        //    if (objResponse != null && objResponse.Token.ToString() != "")
        //    {
        //        var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
        //        identity.AddClaim(new Claim(ClaimTypes.Name, objResponse.Usuario.ApeyNom));
        //        identity.AddClaim(new Claim(ClaimTypes.Role, objResponse.Usuario.Rol));
        //        var principal = new ClaimsPrincipal(identity);
        //        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        //        HttpContext.Session.SetString("APIToken", objResponse.Token);
        //        return Json(new { success = true, token = objResponse.Token });
        //    }
        //    else
        //    {
        //        HttpContext.Session.SetString("APIToken", "");
        //        return Json(new { success = false, message = "Credenciales inválidas" });
        //    }
        //}




        [HttpPost]
        public async Task<JsonResult> CreateUser([FromBody] LoginRequestDTO obj)
        {
            object resultado;
            string mensaje = String.Empty;
            try
            {
                //if (obj.ApeyNom != "")
                //{
                    if (obj.User != "")
                    {
                        Usuario usuario = new Usuario();
                        usuario = await _apiService.AddUser(obj);
                        resultado = usuario.Id;
                        mensaje = "Usuario ingresado correctamente";
                    }
                    else
                    {
                        resultado = false;
                        mensaje = "Por favor ingrese el Email";
                    }
                //}
                //else
                //{
                //    resultado = false;
                //    mensaje = "Por favor ingrese el Apellido y Nombre";
                //}
            }
            catch (Exception ex)
            {
                resultado = false;
                mensaje += ex.Message;

            }
            return Json(new { resultado = resultado, mensaje = mensaje });
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            HttpContext.Session.SetString("APIToken", "");
            return RedirectToAction("Login", "Authuser");

        }
        public IActionResult AccessDenied()
        {

            return View();
        }

      


    }
}
