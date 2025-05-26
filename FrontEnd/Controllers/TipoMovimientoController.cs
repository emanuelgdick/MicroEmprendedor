using Frontend.Models;
using FrontEnd.Models;
using FrontEnd.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft;

namespace FrontEnd.Controllers
{
    public class TipoMovimientoController : Controller
    {
        private readonly ApiService _apiService;
        private readonly IConfiguration _config;
        public TipoMovimientoController(IConfiguration config)
        {
            _apiService = new ApiService();
            _config = config;
        }

        [Authorize(Roles = "Admin")]
        [ResponseCache(Duration = 30)]
        public async Task<IActionResult> Index()
        {
            int pagesize = _config.GetValue<int>("PageSettings:PageSize");
            List<TipoMovimiento> lstTipoMovimiento = new List<TipoMovimiento>();
            lstTipoMovimiento = await _apiService.GetAllTipoMovimientos(HttpContext.Session.GetString("APIToken"));
            return View();
        }

        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> GetAllTipoMovimientos()
        {
            List<TipoMovimiento> oLista = new List<TipoMovimiento>();
            oLista = await _apiService.GetAllTipoMovimientos(HttpContext.Session.GetString("APIToken"));
            return Json(new { data = oLista });
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> CreateTipoMovimiento([FromBody] TipoMovimiento tipoMovimiento)
        {
            object resultado;
            string mensaje = String.Empty;
            try
            {
                if (tipoMovimiento.Id == 0)
                {
                    if (tipoMovimiento.Descripcion != "")
                    {
                        tipoMovimiento = await _apiService.AddTipoMovimiento(tipoMovimiento, HttpContext.Session.GetString("APIToken"));
                        resultado = tipoMovimiento.Id;
                        mensaje = "Tipo de Movimiento ingresado correctamente";
                    }
                    else
                    {
                        resultado = false;
                        mensaje = "Por favor ingrese la Descripción";
                    }
                }
                else
                {
                    if (tipoMovimiento.Descripcion != "")
                    {
                        await _apiService.UpdateTipoMovimiento(tipoMovimiento.Id, tipoMovimiento, HttpContext.Session.GetString("APIToken"));
                        resultado = true;
                        mensaje = "Tipo de Movimiento Modificado correctamente";
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
            TipoMovimiento TipoMovimiento = new TipoMovimiento();
            TipoMovimiento = await _apiService.GetTipoMovimientoById(id, HttpContext.Session.GetString("APIToken"));
            return View(TipoMovimiento);
        }


        [Authorize(Roles = "Admin,Student")]
        public async Task<IActionResult> Delete(int id)
        {
            TipoMovimiento TipoMovimiento = new TipoMovimiento();
            TipoMovimiento = await _apiService.GetTipoMovimientoById(id, HttpContext.Session.GetString("APIToken"));
            return View(TipoMovimiento);
        }

        [Authorize(Roles = "Admin,Student")]

        public async Task<JsonResult> DeleteTipoMovimiento([FromBody] TipoMovimiento tipoMovimiento)
        {
            bool resultado = false;
            string mensaje = string.Empty;
            try
            {
                await _apiService.DeleteTipoMovimiento(tipoMovimiento.Id, HttpContext.Session.GetString("APIToken"));
                resultado = true;
                mensaje = "Tipo de Movimiento eliminado correctante";
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
