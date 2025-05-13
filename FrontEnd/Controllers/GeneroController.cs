using Frontend.Models;
using FrontEnd.Models;
using FrontEnd.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft;

namespace FrontEnd.Controllers
{
    public class GeneroController : Controller
    {
        private readonly ApiService _apiService;
        private readonly IConfiguration _config;

        public GeneroController(IConfiguration config)
        {
            _apiService = new ApiService();
            _config = config;
        }

        [Authorize(Roles = "Admin")]
        [ResponseCache(Duration = 30)]
        public async Task<IActionResult> Index()
        {
            int pagesize = _config.GetValue<int>("PageSettings:PageSize");
            List<Genero> lstGenero = new List<Genero>();
            lstGenero = await _apiService.GetAllGeneros(HttpContext.Session.GetString("APIToken"));
            return View();

        }


        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> GetAllGeneros()
        {
            List<Genero> oLista = new List<Genero>();
            oLista = await _apiService.GetAllGeneros(HttpContext.Session.GetString("APIToken"));
            return Json(new { data = oLista });
        }


        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            return View();
        }



        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> CreateGenero([FromBody] Genero genero)
        {
            object resultado;
            string mensaje = String.Empty;
            try
            {
                if (genero.Id == 0)
                {
                    if (genero.Descripcion != "")
                    {
                        genero = await _apiService.AddGenero(genero, HttpContext.Session.GetString("APIToken"));
                        resultado = genero.Id;
                        mensaje = "Género ingresado correctamente";
                    }
                    else
                    {
                        resultado = false;
                        mensaje = "Por favor ingrese la Descripción";
                    }

                }


                else
                {
                    if (genero.Descripcion != "")
                    {
                        await _apiService.UpdateGenero(genero.Id, genero, HttpContext.Session.GetString("APIToken"));

                        resultado = true;
                        mensaje = "Género modificado correctamente";

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

            Genero Genero = new Genero();
            Genero = await _apiService.GetGeneroById(id, HttpContext.Session.GetString("APIToken"));
            return View(Genero);
        }


        [Authorize(Roles = "Admin,Student")]
        public async Task<IActionResult> Delete(int id)
        {

            Genero genero = new Genero();
            genero = await _apiService.GetGeneroById(id, HttpContext.Session.GetString("APIToken"));
            return View(genero);
        }

        [Authorize(Roles = "Admin,Student")]

        public async Task<JsonResult> DeleteGenero([FromBody] Genero genero)
        {
            bool resultado = false;
            string mensaje = string.Empty;
            try
            {
                await _apiService.DeleteGenero(genero.Id, HttpContext.Session.GetString("APIToken"));
                resultado = true;
                mensaje = "Género eliminado correctante";
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
