using Frontend.Models;
using FrontEnd.Models;
using FrontEnd.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft;

namespace FrontEnd.Controllers
{
    public class PaisController : Controller
    {
        private readonly ApiService _apiService;
        private readonly IConfiguration _config;

        public PaisController(IConfiguration config)
        {
            _apiService = new ApiService();
            _config = config;
        }

        [Authorize(Roles = "Admin")]
        [ResponseCache(Duration = 30)]
        public async Task<IActionResult> Index()
        {
            int pagesize = _config.GetValue<int>("PageSettings:PageSize");
            List<Pais> lstPais = new List<Pais>();
            lstPais = await _apiService.GetAllPaises(HttpContext.Session.GetString("APIToken"));
            return View();

        }

        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> GetAllPaises()
        {
            List<Pais> oLista = new List<Pais>();
            oLista = await _apiService.GetAllPaises(HttpContext.Session.GetString("APIToken"));
            return Json(new { data = oLista });
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> CreatePais([FromBody] Pais pais)
        {
            object resultado;
            string mensaje = String.Empty;
            try
            {
                if (pais.Id == 0)
                {
                    if (pais.Descripcion != "")
                    {
                        pais = await _apiService.AddPais(pais, HttpContext.Session.GetString("APIToken"));
                        resultado = pais.Id;
                        mensaje = "Pais ingresado correctamente";
                    }
                    else
                    {
                        resultado = false;
                        mensaje = "Por favor ingrese la Descripción";
                    }

                }


                else
                {
                    if (pais.Descripcion != "")
                    {
                        await _apiService.UpdatePais(pais.Id, pais, HttpContext.Session.GetString("APIToken"));

                        resultado = true;
                        mensaje = "Pais modificado correctamente";

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

            Pais pais = new Pais();
            pais = await _apiService.GetPaisById(id, HttpContext.Session.GetString("APIToken"));
            return View(pais);
        }

        [Authorize(Roles = "Admin,Student")]
        public async Task<IActionResult> Delete(int id)
        {

            Pais pais = new Pais();
            pais = await _apiService.GetPaisById(id, HttpContext.Session.GetString("APIToken"));
            return View(pais);
        }

        [Authorize(Roles = "Admin,Student")]

        public async Task<JsonResult> DeletePais([FromBody] Pais pais)
        {
            bool resultado = false;
            string mensaje = string.Empty;
            try
            {
                await _apiService.DeletePais(pais.Id, HttpContext.Session.GetString("APIToken"));
                resultado = true;
                mensaje = "Pais eliminado correctante";
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
