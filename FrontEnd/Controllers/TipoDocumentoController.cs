using Frontend.Models;
using FrontEnd.Models;
using FrontEnd.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft;

namespace FrontEnd.Controllers
{
    public class TipoDocumentoController : Controller
    {
        private readonly ApiService _apiService;
        private readonly IConfiguration _config;
        public TipoDocumentoController(IConfiguration config)
        {
            _apiService = new ApiService();
            _config = config;
        }

        [Authorize(Roles = "Admin")]
        [ResponseCache(Duration = 30)]
        public async Task<IActionResult> Index()
        {
            int pagesize = _config.GetValue<int>("PageSettings:PageSize");
            List<TipoDocumento> lstTipoDocumento = new List<TipoDocumento>();
            lstTipoDocumento = await _apiService.GetAllTipoDocumentos(HttpContext.Session.GetString("APIToken"));
            return View();
        }

        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> GetAllTipoDocumentos()
        {
            List<TipoDocumento> oLista = new List<TipoDocumento>();
            oLista = await _apiService.GetAllTipoDocumentos(HttpContext.Session.GetString("APIToken"));
            return Json(new { data = oLista });
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> CreateTipoDocumento([FromBody] TipoDocumento tipoDocumento)
        {
            object resultado;
            string mensaje = String.Empty;
            try
            {
                if (tipoDocumento.Id == 0)
                {
                    if (tipoDocumento.DescA != "")
                    {
                        tipoDocumento = await _apiService.AddTipoDocumento(tipoDocumento, HttpContext.Session.GetString("APIToken"));
                        resultado = tipoDocumento.Id;
                        mensaje = "Tipo de Documento ingresado correctamente";
                    }
                    else
                    {
                        resultado = false;
                        mensaje = "Por favor ingrese la Descripción";
                    }
                }
                else
                {
                    if (tipoDocumento.DescA != "")
                    {
                        await _apiService.UpdateTipoDocumento(tipoDocumento.Id, tipoDocumento, HttpContext.Session.GetString("APIToken"));
                        resultado = true;
                        mensaje = "Tipo de Documento modificado correctamente";
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
            TipoDocumento tipoDocumento = new TipoDocumento();
            tipoDocumento = await _apiService.GetTipoDocumentoById(id, HttpContext.Session.GetString("APIToken"));
            return View(tipoDocumento);
        }


        [Authorize(Roles = "Admin,Student")]
        public async Task<IActionResult> Delete(int id)
        {
            TipoDocumento tipoDocumento = new TipoDocumento();
            tipoDocumento = await _apiService.GetTipoDocumentoById(id, HttpContext.Session.GetString("APIToken"));
            return View(tipoDocumento);
        }

        [Authorize(Roles = "Admin,Student")]

        public async Task<JsonResult> DeleteTipoDocumento([FromBody] TipoDocumento tipoDocumento)
        {
            bool resultado = false;
            string mensaje = string.Empty;
            try
            {
                await _apiService.DeleteTipoDocumento(tipoDocumento.Id, HttpContext.Session.GetString("APIToken"));
                resultado = true;
                mensaje = "Tipo de Documento eliminado correctante";
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
