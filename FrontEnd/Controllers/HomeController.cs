using Frontend.Models;
using FrontEnd.Models;
using FrontEnd.Models.DTOs;
using FrontEnd.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft;
using System.Security.Claims;



namespace Frontend.Controllers
{
    public class HomeController : Controller
    {

        private readonly ApiService _apiService;
        private readonly ApiUserService _apiUserService;


        public HomeController()
        {
            _apiService = new ApiService();
            _apiUserService = new ApiUserService();
        }

        


        // [Authorize(Roles = "Admin")]
        // [ResponseCache(Duration = 30)]
        public async Task<IActionResult> Index()
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            string userId = string.Empty;
            if (userIdClaim != null)
            {
                 userId=userIdClaim.Value;
                TotalesDTO totales = new TotalesDTO();
                totales = await _apiService.GetTotales(int.Parse(userId), HttpContext.Session.GetString("APIToken"));
                return View(totales);
            }

            return View();
        }


        public async Task<IActionResult> Default([FromBody] LoginRequestDTO obj=null)
        {
            LoginResponseDTO objResponse = new LoginResponseDTO();
            
            Usuario usuario = new Usuario();
            if (obj != null)
            {
                objResponse = await _apiUserService.AuthenticateUser(obj);



                usuario.User = objResponse.Usuario.User;
                usuario.Password = objResponse.Usuario.Password;
                usuario.ApeyNom = objResponse.Usuario.ApeyNom;
                usuario.IdLocalidad = objResponse.Usuario.IdLocalidad;
                ViewData["Message"] = usuario.ApeyNom;
            }
            
            return View(usuario);
            //return View();
        }

        //public async ActionResult SessionIniciada(LoginResponseDTO obj)
        //{
        //    LoginResponseDTO objResponse = new LoginResponseDTO();
        //    Usuario usuario = new Usuario();
        //    if (obj != null)
        //    {
        //        objResponse = await _apiUserService.AuthenticateUser(obj);

        //        usuario.User = objResponse.Usuario.User;
        //        usuario.Password = objResponse.Usuario.Password;
        //        usuario.ApeyNom = objResponse.Usuario.ApeyNom;
        //        usuario.IdLocalidad = objResponse.Usuario.IdLocalidad;
        //        return View(usuario);
        //    }
        //    return View(usuario);
        //}


    }
}