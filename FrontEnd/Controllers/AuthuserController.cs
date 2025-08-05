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
                identity.AddClaim(new Claim(ClaimTypes.UserData, objResponse.Usuario.User));
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, objResponse.Usuario.Id.ToString()));
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                HttpContext.Session.SetString("APIToken", objResponse.Token);
                //Usuario usuario = new Usuario();
                //usuario.User = objResponse.Usuario.User;
                //usuario.Password = objResponse.Usuario.Password;
                //usuario.ApeyNom = objResponse.Usuario.ApeyNom;
                //usuario.IdLocalidad = objResponse.Usuario.IdLocalidad;

        
                return Json(new { success = true, token = objResponse.Token});
                
               

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
            return RedirectToAction("default", "Home");

        }
        public IActionResult AccessDenied()
        {

            return View();
        }


        public ActionResult SessionIniciada()
        {
            if (User.Identity.IsAuthenticated)
            {
                string nombreUsuario = User.Identity.Name;
                bool sesionIniciada = User.Identity.IsAuthenticated==null?false:true;
                ViewBag.SesionIniciada = sesionIniciada;
                //Usuario u = new Usuario();
                //u.ApeyNom = User.Identity.Name;


                return View((object)nombreUsuario);
            }
            else
            {
                // El usuario no está autenticado, redirigir a la página de inicio de sesión
                return RedirectToAction("Login", "Cuenta"); // Reemplaza "Login" y "Cuenta" con tus acciones y controlador de inicio de sesión
            }
        }

        //[HttpPost]
        //public ActionResult Reestablecer(string correo)
        //{
        //    Usuario oUsuario = new Usuario();
        //    oUsuario = new UsuarioBiz().Listar().Where(item => item.Correo == correo).FirstOrDefault();
        //    if (oUsuario == null)
        //    {
        //        ViewBag.Error = "No se encontró un usuario relacionado a ese correo";
        //        return View();
        //    }
        //    string mensaje = string.Empty;
        //    bool respuesta = new UsuarioBiz().ReestablecerClave(oUsuario.Id, correo, out mensaje);
        //    if (respuesta)
        //    {
        //        ViewBag.Error = null;
        //        return RedirectToAction("Index", "Acceso");
        //    }
        //    else
        //    {
        //        ViewBag.Error = mensaje;
        //        return View();
        //    }
        //}

    }
}
