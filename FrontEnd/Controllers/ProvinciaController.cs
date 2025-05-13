using Frontend.Models;
using FrontEnd.Models;
using FrontEnd.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft;

namespace FrontEnd.Controllers
{
    public class ProvinciaController : Controller
    {
        private readonly ApiService _apiService;
        private readonly IConfiguration _config;

        public ProvinciaController(IConfiguration config)
        {
            _apiService = new ApiService();
            _config = config;
        }

        [Authorize(Roles = "Admin")]
        [ResponseCache(Duration = 30)]
        public async Task<IActionResult> Index()
        {
            int pagesize = _config.GetValue<int>("PageSettings:PageSize");
            List<Provincia> lstProvincia = new List<Provincia>();
            lstProvincia = await _apiService.GetAllProvincias(HttpContext.Session.GetString("APIToken"));
            return View();
        }


        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> GetAllProvincias()
        {
            List<Provincia> oLista = new List<Provincia>();
            oLista = await _apiService.GetAllProvincias(HttpContext.Session.GetString("APIToken"));
            return Json(new { data = oLista });
        }


        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            return View();
        }



        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> CreateProvincia([FromBody] Provincia provincia)
        {
            object resultado;
            string mensaje = String.Empty;
            try
            {
                if (provincia.Id == 0)
                {
                    if (provincia.Descripcion != "")
                    {
                        provincia = await _apiService.AddProvincia(provincia, HttpContext.Session.GetString("APIToken"));
                        resultado = provincia.Id;
                        mensaje = "Provincia ingresada correctamente";
                    }
                    else
                    {
                        resultado = false;
                        mensaje = "Por favor ingrese la Descripción";
                    }
                }
                else
                {
                    if (provincia.Descripcion != "")
                    {
                        await _apiService.UpdateProvincia(provincia.Id, provincia, HttpContext.Session.GetString("APIToken"));
                        resultado = true;
                        mensaje = "Provincia modificada correctamente";
                    }
                    else
                    {
                        resultado = false;
                        mensaje = "Por favor ingrese la Descripción";
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

            Provincia provincia = new Provincia();
            provincia = await _apiService.GetProvinciaById(id, HttpContext.Session.GetString("APIToken"));
            return View(provincia);
        }


        [Authorize(Roles = "Admin,Student")]
        public async Task<IActionResult> Delete(int id)
        {
            Provincia provincia = new Provincia();
            provincia = await _apiService.GetProvinciaById(id, HttpContext.Session.GetString("APIToken"));
            return View(provincia);
        }

        [Authorize(Roles = "Admin,Student")]

        public async Task<JsonResult> DeleteProvincia([FromBody] Provincia provincia)
        {
            bool resultado = false;
            string mensaje = string.Empty;
            try
            {
                await _apiService.DeleteProvincia(provincia.Id, HttpContext.Session.GetString("APIToken"));
                resultado = true;
                mensaje = "Provincia eliminada correctante";
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
