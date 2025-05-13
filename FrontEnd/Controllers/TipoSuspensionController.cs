using Frontend.Models;
using FrontEnd.Models;
using FrontEnd.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft;

namespace FrontEnd.Controllers
{
    public class TipoSuspensionController : Controller
    {
        private readonly ApiService _apiService;
        private readonly IConfiguration _config;
        public TipoSuspensionController(IConfiguration config)
        {
            _apiService = new ApiService();
            _config = config;
        }

        [Authorize(Roles = "Admin")]
        [ResponseCache(Duration = 30)]
        public async Task<IActionResult> Index()
        {
            int pagesize = _config.GetValue<int>("PageSettings:PageSize");
            List<TipoSuspension> lstTipoSuspension = new List<TipoSuspension>();
            lstTipoSuspension = await _apiService.GetAllTipoSuspensiones(HttpContext.Session.GetString("APIToken"));
            return View();
        }

        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> GetAllTipoSuspensiones()
        {
            List<TipoSuspension> oLista = new List<TipoSuspension>();
            oLista = await _apiService.GetAllTipoSuspensiones(HttpContext.Session.GetString("APIToken"));
            return Json(new { data = oLista });
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> CreateTipoSuspension([FromBody] TipoSuspension tipoSuspension)
        {
            object resultado;
            string mensaje = String.Empty;
            try
            {
                if (tipoSuspension.Id == 0)
                {
                    if (tipoSuspension.Descripcion != "")
                    {
                        tipoSuspension = await _apiService.AddTipoSuspension(tipoSuspension, HttpContext.Session.GetString("APIToken"));
                        resultado = tipoSuspension.Id;
                        mensaje = "Tipo de Suspensión ingresado correctamente";
                    }
                    else
                    {
                        resultado = false;
                        mensaje = "Por favor ingrese la Descripción";
                    }
                }
                else
                {
                    if (tipoSuspension.Descripcion != "")
                    {
                        await _apiService.UpdateTipoSuspension(tipoSuspension.Id, tipoSuspension, HttpContext.Session.GetString("APIToken"));
                        resultado = true;
                        mensaje = "Tipo de Suspensión modificado correctamente";
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
            TipoSuspension tipoSuspension = new TipoSuspension();
            tipoSuspension = await _apiService.GetTipoSuspensionById(id, HttpContext.Session.GetString("APIToken"));
            return View(tipoSuspension);
        }

        [Authorize(Roles = "Admin,Student")]
        public async Task<IActionResult> Delete(int id)
        {
            TipoSuspension tipoSuspension = new TipoSuspension();
            tipoSuspension = await _apiService.GetTipoSuspensionById(id, HttpContext.Session.GetString("APIToken"));
            return View(tipoSuspension);
        }

        [Authorize(Roles = "Admin,Student")]
        public async Task<JsonResult> DeleteTipoSuspension([FromBody] TipoSuspension tipoSuspension)
        {
            bool resultado = false;
            string mensaje = string.Empty;
            try
            {
                await _apiService.DeleteTipoSuspension(tipoSuspension.Id, HttpContext.Session.GetString("APIToken"));
                resultado = true;
                mensaje = "Tipo de Suspensión eliminado correctante";
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
