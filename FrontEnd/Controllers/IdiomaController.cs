using Frontend.Models;
using FrontEnd.Models;
using FrontEnd.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft;

namespace FrontEnd.Controllers
{
    public class IdiomaController : Controller
    {
        private readonly ApiService _apiService;
        private readonly IConfiguration _config;

        public IdiomaController(IConfiguration config)
        {
            _apiService = new ApiService();
            _config = config;
        }

        [Authorize(Roles = "Admin")]
        [ResponseCache(Duration = 30)]
        public async Task<IActionResult> Index()
        {
            int pagesize = _config.GetValue<int>("PageSettings:PageSize");
            List<Idioma> lstIdioma = new List<Idioma>();
            lstIdioma = await _apiService.GetAllIdiomas(HttpContext.Session.GetString("APIToken"));
            return View();

        }


        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> GetAllIdiomas()
        {
            List<Idioma> oLista = new List<Idioma>();
            oLista = await _apiService.GetAllIdiomas(HttpContext.Session.GetString("APIToken"));

            return Json(new { data = oLista });
        }


        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            return View();
        }



        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> CreateIdioma([FromBody] Idioma idioma)
        {
            object resultado;
            string mensaje = String.Empty;
            try
            {
                if (idioma.Id == 0)
                {
                    if (idioma.Descripcion != "")
                    {
                        idioma = await _apiService.AddIdioma(idioma, HttpContext.Session.GetString("APIToken"));
                        resultado = idioma.Id;
                        mensaje = "Idioma ingresado correctamente";
                    }
                    else
                    {
                        resultado = false;
                        mensaje = "Por favor ingrese la Descripción";
                    }
                }

                else
                {
                    if (idioma.Descripcion != "")
                    {
                        await _apiService.UpdateIdioma(idioma.Id, idioma, HttpContext.Session.GetString("APIToken"));

                        resultado = true;
                        mensaje = "Idioma modificado correctamente";

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

            Idioma idioma = new Idioma();
            idioma = await _apiService.GetIdiomaById(id, HttpContext.Session.GetString("APIToken"));
            return View(idioma);
        }


        [Authorize(Roles = "Admin,Student")]
        public async Task<IActionResult> Delete(int id)
        {

            Idioma idioma = new Idioma();
            idioma = await _apiService.GetIdiomaById(id, HttpContext.Session.GetString("APIToken"));
            return View(idioma);
        }

        [Authorize(Roles = "Admin,Student")]

        public async Task<JsonResult> DeleteIdioma([FromBody] Idioma idioma)
        {
            bool resultado = false;
            string mensaje = string.Empty;
            try
            {
                await _apiService.DeleteIdioma(idioma.Id, HttpContext.Session.GetString("APIToken"));
                resultado = true;
                mensaje = "Idioma eliminado correctante";
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
