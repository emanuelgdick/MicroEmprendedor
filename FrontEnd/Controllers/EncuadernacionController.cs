using Frontend.Models;
using FrontEnd.Models;
using FrontEnd.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft;

namespace FrontEnd.Controllers
{
    public class EncuadernacionController : Controller
    {
        private readonly ApiService _apiService;
        private readonly IConfiguration _config;

        public EncuadernacionController(IConfiguration config)
        {
            _apiService = new ApiService();
            _config = config;
        }

        [Authorize(Roles = "Admin")]
        [ResponseCache(Duration = 30)]
        public async Task<IActionResult> Index()
        {
            int pagesize = _config.GetValue<int>("PageSettings:PageSize");
            List<Encuadernacion> lstEncuadernacion = new List<Encuadernacion>();
            lstEncuadernacion = await _apiService.GetAllEncuadernaciones(HttpContext.Session.GetString("APIToken"));
            return View();

        }


        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> GetAllEncuadernaciones()
        {
            List<Encuadernacion> oLista = new List<Encuadernacion>();
            oLista = await _apiService.GetAllEncuadernaciones(HttpContext.Session.GetString("APIToken"));

            return Json(new { data = oLista });
        }


        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            return View();
        }



        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> CreateEncuadernacion([FromBody] Encuadernacion Encuadernacion)
        {
            object resultado;
            string mensaje = String.Empty;
            try
            {
                if (Encuadernacion.Id == 0)
                {
                    if (Encuadernacion.Descripcion != "")
                    {
                        Encuadernacion = await _apiService.AddEncuadernacion(Encuadernacion, HttpContext.Session.GetString("APIToken"));
                        resultado = Encuadernacion.Id;
                        mensaje = "Encuadernación ingresada correctamente";
                    }
                    else
                    {
                        resultado = false;
                        mensaje = "Por favor ingrese la Descripción";
                    }
                }
                else
                {
                    if (Encuadernacion.Descripcion != "")
                    {
                        await _apiService.UpdateEncuadernacion(Encuadernacion.Id, Encuadernacion, HttpContext.Session.GetString("APIToken"));

                        resultado = true;
                        mensaje = "Encuadernación modificada correctamente";

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

            Encuadernacion Encuadernacion = new Encuadernacion();
            Encuadernacion = await _apiService.GetEncuadernacionById(id, HttpContext.Session.GetString("APIToken"));
            return View(Encuadernacion);
        }


        [Authorize(Roles = "Admin,Student")]
        public async Task<IActionResult> Delete(int id)
        {

            Encuadernacion Encuadernacion = new Encuadernacion();
            Encuadernacion = await _apiService.GetEncuadernacionById(id, HttpContext.Session.GetString("APIToken"));
            return View(Encuadernacion);
        }

        [Authorize(Roles = "Admin,Student")]

        public async Task<JsonResult> DeleteEncuadernacion([FromBody] Encuadernacion Encuadernacion)
        {
            bool resultado = false;
            string mensaje = string.Empty;
            try
            {
                await _apiService.DeleteEncuadernacion(Encuadernacion.Id, HttpContext.Session.GetString("APIToken"));
                resultado = true;
                mensaje = "Encuadernación eliminada correctante";
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
