
using FrontEnd.Models;
using FrontEnd.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft;

namespace FrontEnd.Controllers
{
    public class DirectorController : Controller
    {
        private readonly ApiService _apiService;
        private readonly IConfiguration _config;

        public DirectorController(IConfiguration config)
        {
            _apiService = new ApiService();
            _config = config;
        }

        [Authorize(Roles = "Admin")]
        [ResponseCache(Duration = 30)]
        public async Task<IActionResult> Index()
        {
            int pagesize = _config.GetValue<int>("PageSettings:PageSize");
            List<Director> lstDirector = new List<Director>();
            lstDirector = await _apiService.GetAllDirectores(HttpContext.Session.GetString("APIToken"));
            return View();

        }


        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> GetAllDirectores()
        {
            List<Director> oLista = new List<Director>();
            oLista = await _apiService.GetAllDirectores(HttpContext.Session.GetString("APIToken"));
            return Json(new { data = oLista });
        }


        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> CreateDirector([FromBody] Director director)
        {
            object resultado;
            string mensaje = String.Empty;
            try
            {
                if (director.Id == 0)
                {
                    if (director.ApeyNom != "")
                    {
                        director = await _apiService.AddDirector(director, HttpContext.Session.GetString("APIToken"));
                        resultado = director.Id;
                        mensaje = "Director ingresado correctamente";
                    }
                    else
                    {
                        resultado = false;
                        mensaje = "Por favor ingrese el Apellido y Nombre";
                    }

                }


                else
                {
                    if (director.ApeyNom != "")
                    {
                        await _apiService.UpdateDirector(director.Id, director, HttpContext.Session.GetString("APIToken"));

                        resultado = true;
                        mensaje = "Director Modificado correctamente";

                    }
                    else
                    {
                        resultado = false;
                        mensaje = "Por favor ingrese el Apellido y Nombre";
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

            Director director = new Director();
            director = await _apiService.GetDirectorById(id, HttpContext.Session.GetString("APIToken"));
            return View(director);
        }

        [Authorize(Roles = "Admin,Student")]
        public async Task<IActionResult> Delete(int id)
        {

            Director director = new Director();
            director = await _apiService.GetDirectorById(id, HttpContext.Session.GetString("APIToken"));
            return View(director);
        }

        [Authorize(Roles = "Admin,Student")]

        public async Task<JsonResult> DeleteDirector([FromBody] Director director)
        {
            bool resultado = false;
            string mensaje = string.Empty;
            try
            {
                await _apiService.DeleteDirector(director.Id, HttpContext.Session.GetString("APIToken"));
                resultado = true;
                mensaje = "Director eliminado correctante";
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
