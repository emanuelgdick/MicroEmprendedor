using Frontend.Models;
using FrontEnd.Models;
using FrontEnd.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft;

namespace FrontEnd.Controllers
{
    public class CategoriaSocioController : Controller
    {
        private readonly ApiService _apiService;
        private readonly IConfiguration _config;

        public CategoriaSocioController(IConfiguration config)
        {
            _apiService = new ApiService();
            _config = config;
        }

        [Authorize(Roles = "Admin")]
        [ResponseCache(Duration = 30)]
        public async Task<IActionResult> Index()
        {
            int pagesize = _config.GetValue<int>("PageSettings:PageSize");
            List<CategoriaSocio> lstCategoriaSocio = new List<CategoriaSocio>();
            lstCategoriaSocio = await _apiService.GetAllCategoriasSocios(HttpContext.Session.GetString("APIToken"));
            return View();

        }


        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> GetAllCategoriaSocios()
        {
            List<CategoriaSocio> oLista = new List<CategoriaSocio>();
            oLista = await _apiService.GetAllCategoriasSocios(HttpContext.Session.GetString("APIToken"));

            return Json(new { data = oLista });
        }


        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            return View();
        }



        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> CreateCategoriaSocio([FromBody] CategoriaSocio CategoriaSocio)
        {
            object resultado;
            string mensaje = String.Empty;
            try
            {
                if (CategoriaSocio.Id == 0)
                {
                    if (CategoriaSocio.Descripcion != "")
                    {
                        CategoriaSocio = await _apiService.AddCategoriaSocio(CategoriaSocio, HttpContext.Session.GetString("APIToken"));
                        resultado = CategoriaSocio.Id;
                        mensaje = "CategoriaSocio ingresado correctamente";
                    }
                    else
                    {
                        resultado = false;
                        mensaje = "Por favor ingrese la Descripción";
                    }

                }


                else
                {
                    if (CategoriaSocio.Descripcion != "")
                    {
                        await _apiService.UpdateCategoriaSocio(CategoriaSocio.Id, CategoriaSocio, HttpContext.Session.GetString("APIToken"));

                        resultado = true;
                        mensaje = "CategoriaSocio Modificado correctamente";

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

            CategoriaSocio CategoriaSocio = new CategoriaSocio();
            CategoriaSocio = await _apiService.GetCategoriaSocioById(id, HttpContext.Session.GetString("APIToken"));
            return View(CategoriaSocio);
        }


        //[Authorize(Roles = "Admin")]
        //public async Task<IActionResult> UpdateCategoriaSocio(int id, CategoriaSocio CategoriaSocio)
        //{
        //    await _apiService.UpdateCategoriaSocio(id, CategoriaSocio, HttpContext.Session.GetString("APIToken"));
        //    return RedirectToAction("Index");
        //}

        [Authorize(Roles = "Admin,Student")]
        public async Task<IActionResult> Delete(int id)
        {

            CategoriaSocio CategoriaSocio = new CategoriaSocio();
            CategoriaSocio = await _apiService.GetCategoriaSocioById(id, HttpContext.Session.GetString("APIToken"));
            return View(CategoriaSocio);
        }

        [Authorize(Roles = "Admin,Student")]

        public async Task<JsonResult> DeleteCategoriaSocio([FromBody] CategoriaSocio CategoriaSocio)
        {
            bool resultado = false;
            string mensaje = string.Empty;
            try
            {
                await _apiService.DeleteCategoriaSocio(CategoriaSocio.Id, HttpContext.Session.GetString("APIToken"));
                resultado = true;
                mensaje = "CategoriaSocio eliminado correctante";
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
