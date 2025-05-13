using Frontend.Models;
using FrontEnd.Models;
using FrontEnd.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft;

namespace FrontEnd.Controllers
{
    public class TipoSocioController : Controller
    {
        private readonly ApiService _apiService;
        private readonly IConfiguration _config;
        public TipoSocioController(IConfiguration config)
        {
            _apiService = new ApiService();
            _config = config;
        }

        [Authorize(Roles = "Admin")]
        [ResponseCache(Duration = 30)]
        public async Task<IActionResult> Index()
        {
            int pagesize = _config.GetValue<int>("PageSettings:PageSize");
            List<TipoSocio> lstTipoSocio = new List<TipoSocio>();
            lstTipoSocio = await _apiService.GetAllTipoSocios(HttpContext.Session.GetString("APIToken"));
            return View();
        }

        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> GetAllTipoSocios()
        {
            List<TipoSocio> oLista = new List<TipoSocio>();
            oLista = await _apiService.GetAllTipoSocios(HttpContext.Session.GetString("APIToken"));
            return Json(new { data = oLista });
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> CreateTipoSocio([FromBody] TipoSocio tipoSocio)
        {
            object resultado;
            string mensaje = String.Empty;
            try
            {
                if (tipoSocio.Id == 0)
                {
                    if (tipoSocio.Descripcion != "")
                    {
                        tipoSocio = await _apiService.AddTipoSocio(tipoSocio, HttpContext.Session.GetString("APIToken"));
                        resultado = tipoSocio.Id;
                        mensaje = "Tipo de Socio ingresado correctamente";
                    }
                    else
                    {
                        resultado = false;
                        mensaje = "Por favor ingrese la Descripción";
                    }
                }
                else
                {
                    if (tipoSocio.Descripcion != "")
                    {
                        await _apiService.UpdateTipoSocio(tipoSocio.Id, tipoSocio, HttpContext.Session.GetString("APIToken"));
                        resultado = true;
                        mensaje = "Tipo de Socio modificado correctamente";
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
            TipoSocio tipoSocio = new TipoSocio();
            tipoSocio = await _apiService.GetTipoSocioById(id, HttpContext.Session.GetString("APIToken"));
            return View(tipoSocio);
        }


        [Authorize(Roles = "Admin,Student")]
        public async Task<IActionResult> Delete(int id)
        {
            TipoSocio tipoSocio = new TipoSocio();
            tipoSocio = await _apiService.GetTipoSocioById(id, HttpContext.Session.GetString("APIToken"));
            return View(tipoSocio);
        }

        [Authorize(Roles = "Admin,Student")]

        public async Task<JsonResult> DeleteTipoSocio([FromBody] TipoSocio tipoSocio)
        {
            bool resultado = false;
            string mensaje = string.Empty;
            try
            {
                await _apiService.DeleteTipoSocio(tipoSocio.Id, HttpContext.Session.GetString("APIToken"));
                resultado = true;
                mensaje = "Tipo de Socio eliminado correctante";
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
