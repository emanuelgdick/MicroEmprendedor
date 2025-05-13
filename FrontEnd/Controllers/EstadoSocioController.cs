using Frontend.Models;
using FrontEnd.Models;
using FrontEnd.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft;

namespace FrontEnd.Controllers
{
    public class EstadoSocioController : Controller
    {
        private readonly ApiService _apiService;
        private readonly IConfiguration _config;

        public EstadoSocioController(IConfiguration config)
        {
            _apiService = new ApiService();
            _config = config;
        }

        [Authorize(Roles = "Admin")]
        [ResponseCache(Duration = 30)]
        public async Task<IActionResult> Index()
        {
            int pagesize = _config.GetValue<int>("PageSettings:PageSize");
            List<EstadoSocio> lstEstadoSocio = new List<EstadoSocio>();
            lstEstadoSocio = await _apiService.GetAllEstadoSocios(HttpContext.Session.GetString("APIToken"));
            return View();

        }


        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> GetAllEstadoSocios()
        {
            List<EstadoSocio> oLista = new List<EstadoSocio>();
            oLista = await _apiService.GetAllEstadoSocios(HttpContext.Session.GetString("APIToken"));
            return Json(new { data = oLista });
        }


        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            return View();
        }



        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> CreateEstadoSocio([FromBody] EstadoSocio estadoSocio)
        {
            object resultado;
            string mensaje = String.Empty;
            try
            {
                if (estadoSocio.Id == 0)
                {
                    if (estadoSocio.Descripcion != "")
                    {
                        estadoSocio = await _apiService.AddEstadoSocio(estadoSocio, HttpContext.Session.GetString("APIToken"));
                        resultado = estadoSocio.Id;
                        mensaje = "Estado de Socio ingresado correctamente";
                    }
                    else
                    {
                        resultado = false;
                        mensaje = "Por favor ingrese la Descripción";
                    }
                }

                else
                {
                    if (estadoSocio.Descripcion != "")
                    {
                        await _apiService.UpdateEstadoSocio(estadoSocio.Id, estadoSocio, HttpContext.Session.GetString("APIToken"));

                        resultado = true;
                        mensaje = "Estado de Socio modificado correctamente";
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

            EstadoSocio estadoSocio = new EstadoSocio();
            estadoSocio = await _apiService.GetEstadoSocioById(id, HttpContext.Session.GetString("APIToken"));
            return View(estadoSocio);
        }


        [Authorize(Roles = "Admin,Student")]
        public async Task<IActionResult> Delete(int id)
        {

            EstadoSocio estadoSocio = new EstadoSocio();
            estadoSocio = await _apiService.GetEstadoSocioById(id, HttpContext.Session.GetString("APIToken"));
            return View(estadoSocio);
        }

        [Authorize(Roles = "Admin,Student")]

        public async Task<JsonResult> DeleteEstadoSocio([FromBody] EstadoSocio estadoSocio)
        {
            bool resultado = false;
            string mensaje = string.Empty;
            try
            {
                await _apiService.DeleteEstadoSocio(estadoSocio.Id, HttpContext.Session.GetString("APIToken"));
                resultado = true;
                mensaje = "Estado de Socio eliminado correctante";
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
