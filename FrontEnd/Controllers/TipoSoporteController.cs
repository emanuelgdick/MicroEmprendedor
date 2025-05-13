using Frontend.Models;
using FrontEnd.Models;
using FrontEnd.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft;

namespace FrontEnd.Controllers
{
    public class TipoSoporteController : Controller
    {
        private readonly ApiService _apiService;
        private readonly IConfiguration _config;
        public TipoSoporteController(IConfiguration config)
        {
            _apiService = new ApiService();
            _config = config;
        }

        [Authorize(Roles = "Admin")]
        [ResponseCache(Duration = 30)]
        public async Task<IActionResult> Index()
        {
            int pagesize = _config.GetValue<int>("PageSettings:PageSize");
            List<TipoSoporte> lstTipoSoporte = new List<TipoSoporte>();
            lstTipoSoporte = await _apiService.GetAllTipoSoportes(HttpContext.Session.GetString("APIToken"));
            return View();
        }

        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> GetAllTipoSoportes()
        {
            List<TipoSoporte> oLista = new List<TipoSoporte>();
            oLista = await _apiService.GetAllTipoSoportes(HttpContext.Session.GetString("APIToken"));
            return Json(new { data = oLista });
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> CreateTipoSoporte([FromBody] TipoSoporte tipoSoporte)
        {
            object resultado;
            string mensaje = String.Empty;
            try
            {
                if (tipoSoporte.Id == 0)
                {
                    if (tipoSoporte.Descripcion != "")
                    {
                        tipoSoporte = await _apiService.AddTipoSoporte(tipoSoporte, HttpContext.Session.GetString("APIToken"));
                        resultado = tipoSoporte.Id;
                        mensaje = "Tipo de Soporte ingresado correctamente";
                    }
                    else
                    {
                        resultado = false;
                        mensaje = "Por favor ingrese la Descripción";
                    }
                }
                else
                {
                    if (tipoSoporte.Descripcion != "")
                    {
                        await _apiService.UpdateTipoSoporte(tipoSoporte.Id, tipoSoporte, HttpContext.Session.GetString("APIToken"));
                        resultado = true;
                        mensaje = "Tipo de Soporte modificado correctamente";
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
            TipoSoporte tipoSoporte = new TipoSoporte();
            tipoSoporte = await _apiService.GetTipoSoporteById(id, HttpContext.Session.GetString("APIToken"));
            return View(tipoSoporte);
        }

        [Authorize(Roles = "Admin,Student")]
        public async Task<IActionResult> Delete(int id)
        {
            TipoSoporte tipoSoporte = new TipoSoporte();
            tipoSoporte = await _apiService.GetTipoSoporteById(id, HttpContext.Session.GetString("APIToken"));
            return View(tipoSoporte);
        }

        [Authorize(Roles = "Admin,Student")]

        public async Task<JsonResult> DeleteTipoSoporte([FromBody] TipoSoporte tipoSoporte)
        {
            bool resultado = false;
            string mensaje = string.Empty;
            try
            {
                await _apiService.DeleteTipoSoporte(tipoSoporte.Id, HttpContext.Session.GetString("APIToken"));
                resultado = true;
                mensaje = "Tipo de Soporte eliminado correctante";
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
