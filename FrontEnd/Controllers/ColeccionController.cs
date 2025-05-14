
using FrontEnd.Models;
using FrontEnd.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft;

namespace FrontEnd.Controllers
{
    public class ColeccionController : Controller
    {
        private readonly ApiService _apiService;
        private readonly IConfiguration _config;

        public ColeccionController(IConfiguration config)
        {
            _apiService = new ApiService();
            _config = config;
        }

        [Authorize(Roles = "Admin")]
        [ResponseCache(Duration = 30)]
        public async Task<IActionResult> Index()
        {
            int pagesize = _config.GetValue<int>("PageSettings:PageSize");
            List<Coleccion> lstColeccion = new List<Coleccion>();
            lstColeccion = await _apiService.GetAllColecciones(HttpContext.Session.GetString("APIToken"));
            return View();

        }


        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> GetAllColecciones()
        {
            List<Coleccion> oLista = new List<Coleccion>();
            oLista = await _apiService.GetAllColecciones(HttpContext.Session.GetString("APIToken"));
            return Json(new { data = oLista });
        }


        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            return View();
        }



        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> CreateColeccion([FromBody] Coleccion coleccion)
        {
            object resultado;
            string mensaje = String.Empty;
            try
            {
                if (coleccion.Id == 0)
                {
                    if (coleccion.Descripcion != "")
                    {
                        coleccion = await _apiService.AddColeccion(coleccion, HttpContext.Session.GetString("APIToken"));
                        resultado = coleccion.Id;
                        mensaje = "Colección ingresada correctamente";
                    }
                    else
                    {
                        resultado = false;
                        mensaje = "Por favor ingrese la Descripción";
                    }
                }
                else
                {
                    if (coleccion.Descripcion != "")
                    {
                        await _apiService.UpdateColeccion(coleccion.Id, coleccion, HttpContext.Session.GetString("APIToken"));

                        resultado = true;
                        mensaje = "Colección modificada correctamente";

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

            Coleccion coleccion = new Coleccion();
            coleccion = await _apiService.GetColeccionById(id, HttpContext.Session.GetString("APIToken"));
            return View(coleccion);
        }


        [Authorize(Roles = "Admin,Student")]
        public async Task<IActionResult> Delete(int id)
        {

            Coleccion coleccion = new Coleccion();
            coleccion = await _apiService.GetColeccionById(id, HttpContext.Session.GetString("APIToken"));
            return View(coleccion);
        }

        [Authorize(Roles = "Admin,Student")]

        public async Task<JsonResult> DeleteColeccion([FromBody] Coleccion coleccion)
        {
            bool resultado = false;
            string mensaje = string.Empty;
            try
            {
                await _apiService.DeleteColeccion(coleccion.Id, HttpContext.Session.GetString("APIToken"));
                resultado = true;
                mensaje = "Coleccion eliminada correctante";
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
