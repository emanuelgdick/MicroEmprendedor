using Frontend.Models;
using FrontEnd.Models;
using FrontEnd.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft;

namespace FrontEnd.Controllers
{
    public class PrestamoController : Controller
    {
        private readonly ApiService _apiService;
        private readonly IConfiguration _config;

        public PrestamoController(IConfiguration config)
        {
            _apiService = new ApiService();
            _config = config;
        }

        [Authorize(Roles = "Admin")]
        [ResponseCache(Duration = 30)]
        public async Task<IActionResult> Index()
        {
            int pagesize = _config.GetValue<int>("PageSettings:PageSize");
            List<Prestamo> lstPrestamo = new List<Prestamo>();
            lstPrestamo = await _apiService.GetAllPrestamos(HttpContext.Session.GetString("APIToken"));
            return View();

        }


        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> GetAllPrestamos()
        {
            List<Prestamo> oLista = new List<Prestamo>();
            oLista = await _apiService.GetAllPrestamos(HttpContext.Session.GetString("APIToken"));
            return Json(new { data = oLista });
        }


        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> CreatePrestamo([FromBody] Prestamo prestamo)
        {
            object resultado;
            string mensaje = String.Empty;
            try
            {
                if (prestamo.Id == 0)
                {
                    if (prestamo.Descripcion != "")
                    {
                        prestamo = await _apiService.AddPrestamo(prestamo, HttpContext.Session.GetString("APIToken"));
                        resultado = prestamo.Id;
                        mensaje = "Préstamo ingresado correctamente";
                    }
                    else
                    {
                        resultado = false;
                        mensaje = "Por favor ingrese la Descripción";
                    }

                }


                else
                {
                    if (prestamo.Descripcion != "")
                    {
                        await _apiService.UpdatePrestamo(prestamo.Id, prestamo, HttpContext.Session.GetString("APIToken"));

                        resultado = true;
                        mensaje = "Préstamo modificado correctamente";

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

            Prestamo prestamo = new Prestamo();
            prestamo = await _apiService.GetPrestamoById(id, HttpContext.Session.GetString("APIToken"));
            return View(prestamo);
        }

        [Authorize(Roles = "Admin,Student")]
        public async Task<IActionResult> Delete(int id)
        {
            Prestamo prestamo = new Prestamo();
            prestamo = await _apiService.GetPrestamoById(id, HttpContext.Session.GetString("APIToken"));
            return View(prestamo);
        }

        [Authorize(Roles = "Admin,Student")]

        public async Task<JsonResult> DeletePrestamo([FromBody] Prestamo prestamo)
        {
            bool resultado = false;
            string mensaje = string.Empty;
            try
            {
                await _apiService.DeletePrestamo(prestamo.Id, HttpContext.Session.GetString("APIToken"));
                resultado = true;
                mensaje = "Préstamo eliminado correctante";
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
