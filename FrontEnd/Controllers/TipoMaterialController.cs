using Frontend.Models;
using FrontEnd.Models;
using FrontEnd.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft;

namespace FrontEnd.Controllers
{
    public class TipoMaterialController : Controller
    {
        private readonly ApiService _apiService;
        private readonly IConfiguration _config;
        public TipoMaterialController(IConfiguration config)
        {
            _apiService = new ApiService();
            _config = config;
        }

        [Authorize(Roles = "Admin")]
        [ResponseCache(Duration = 30)]
        public async Task<IActionResult> Index()
        {
            int pagesize = _config.GetValue<int>("PageSettings:PageSize");
            List<TipoMaterial> lstTipoMaterial = new List<TipoMaterial>();
            lstTipoMaterial = await _apiService.GetAllTipoMateriales(HttpContext.Session.GetString("APIToken"));
            return View();
        }

        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> GetAllTipoMateriales()
        {
            List<TipoMaterial> oLista = new List<TipoMaterial>();
            oLista = await _apiService.GetAllTipoMateriales(HttpContext.Session.GetString("APIToken"));
            return Json(new { data = oLista });
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> CreateTipoMaterial([FromBody] TipoMaterial tipoMaterial)
        {
            object resultado;
            string mensaje = String.Empty;
            try
            {
                if (tipoMaterial.Id == 0)
                {
                    if (tipoMaterial.Descripcion != "")
                    {
                        tipoMaterial = await _apiService.AddTipoMaterial(tipoMaterial, HttpContext.Session.GetString("APIToken"));
                        resultado = tipoMaterial.Id;
                        mensaje = "Tipo de Material ingresado correctamente";
                    }
                    else
                    {
                        resultado = false;
                        mensaje = "Por favor ingrese la Descripción";
                    }
                }
                else
                {
                    if (tipoMaterial.Descripcion != "")
                    {
                        await _apiService.UpdateTipoMaterial(tipoMaterial.Id, tipoMaterial, HttpContext.Session.GetString("APIToken"));
                        resultado = true;
                        mensaje = "Tipo de Material Modificado correctamente";
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
            TipoMaterial tipoMaterial = new TipoMaterial();
            tipoMaterial = await _apiService.GetTipoMaterialById(id, HttpContext.Session.GetString("APIToken"));
            return View(tipoMaterial);
        }


        [Authorize(Roles = "Admin,Student")]
        public async Task<IActionResult> Delete(int id)
        {
            TipoMaterial tipoMaterial = new TipoMaterial();
            tipoMaterial = await _apiService.GetTipoMaterialById(id, HttpContext.Session.GetString("APIToken"));
            return View(tipoMaterial);
        }

        [Authorize(Roles = "Admin,Student")]

        public async Task<JsonResult> DeleteTipoMaterial([FromBody] TipoMaterial tipoMaterial)
        {
            bool resultado = false;
            string mensaje = string.Empty;
            try
            {
                await _apiService.DeleteTipoMaterial(tipoMaterial.Id, HttpContext.Session.GetString("APIToken"));
                resultado = true;
                mensaje = "Tipo de Material eliminado correctante";
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
