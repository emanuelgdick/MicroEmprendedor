using Frontend.Models;
using FrontEnd.Models;
using FrontEnd.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft;

namespace FrontEnd.Controllers
{
    public class IlustradorController : Controller
    {
        private readonly ApiService _apiService;
        private readonly IConfiguration _config;
        public IlustradorController(IConfiguration config)
        {
            _apiService = new ApiService();
            _config = config;
        }

        [Authorize(Roles = "Admin")]
        [ResponseCache(Duration = 30)]
        public async Task<IActionResult> Index()
        {
            int pagesize = _config.GetValue<int>("PageSettings:PageSize");
            List<Ilustrador> lstIlustrador = new List<Ilustrador>();
            lstIlustrador = await _apiService.GetAllIlustradores(HttpContext.Session.GetString("APIToken"));
            return View();
        }

        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> GetAllIlustradores()
        {
            List<Ilustrador> oLista = new List<Ilustrador>();
            oLista = await _apiService.GetAllIlustradores(HttpContext.Session.GetString("APIToken"));
            return Json(new { data = oLista });
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> CreateIlustrador([FromBody] Ilustrador ilustrador)
        {
            object resultado;
            string mensaje = String.Empty;
            try
            {
                if (ilustrador.Id == 0)
                {
                    if (ilustrador.ApeyNom != "")
                    {
                        ilustrador = await _apiService.AddIlustrador(ilustrador, HttpContext.Session.GetString("APIToken"));
                        resultado = ilustrador.Id;
                        mensaje = "Ilustrador ingresado correctamente";
                    }
                    else
                    {
                        resultado = false;
                        mensaje = "Por favor ingrese el Apellido y Nombre";
                    }
                }
                else
                {
                    if (ilustrador.ApeyNom != "")
                    {
                        await _apiService.UpdateIlustrador(ilustrador.Id, ilustrador, HttpContext.Session.GetString("APIToken"));
                        resultado = true;
                        mensaje = "Ilustrador Modificado correctamente";
                    }
                    else
                    {
                        resultado = false;
                        mensaje = "Por favor ingrese el Apellido y Nombre";
                    }
                }
            }
            catch (Exception ex)
            {
                resultado = false;
                mensaje += ex.Message;
            }
            return Json(new { resultado = resultado, mensaje = mensaje });
        }

        [Authorize(Roles = "Admin,Student")]
        public async Task<IActionResult> Details(int id)
        {
            Ilustrador ilustrador = new Ilustrador();
            ilustrador = await _apiService.GetIlustradorById(id, HttpContext.Session.GetString("APIToken"));
            return View(ilustrador);
        }

        [Authorize(Roles = "Admin,Student")]
        public async Task<IActionResult> Delete(int id)
        {
            Ilustrador ilustrador = new Ilustrador();
            ilustrador = await _apiService.GetIlustradorById(id, HttpContext.Session.GetString("APIToken"));
            return View(ilustrador);
        }

        [Authorize(Roles = "Admin,Student")]
        public async Task<JsonResult> DeleteIlustrador([FromBody] Ilustrador ilustrador)
        {
            bool resultado = false;
            string mensaje = string.Empty;
            try
            {
                await _apiService.DeleteIlustrador(ilustrador.Id, HttpContext.Session.GetString("APIToken"));
                resultado = true;
                mensaje = "Ilustrador eliminado correctante";
            }
            catch (Exception ex)
            {
                resultado = false;
                mensaje += ex.Message;
            }
            return Json(new { resultado = resultado, mensaje = mensaje });
        }

        public IActionResult ErrorPage()
        {
            return View();
        }
    }
}
