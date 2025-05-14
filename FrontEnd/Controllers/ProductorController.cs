using Frontend.Models;
using FrontEnd.Models;
using FrontEnd.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft;

namespace FrontEnd.Controllers
{
    public class ProductorController : Controller
    {
        private readonly ApiService _apiService;
        private readonly IConfiguration _config;

        public ProductorController(IConfiguration config)
        {
            _apiService = new ApiService();
            _config = config;
        }

        [Authorize(Roles = "Admin")]
        [ResponseCache(Duration = 30)]
        public async Task<IActionResult> Index()
        {
            int pagesize = _config.GetValue<int>("PageSettings:PageSize");
            List<Productor> lstProductor = new List<Productor>();
            lstProductor = await _apiService.GetAllProductores(HttpContext.Session.GetString("APIToken"));
            return View();

        }

        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> GetAllProductores()
        {
            List<Productor> oLista = new List<Productor>();
            oLista = await _apiService.GetAllProductores(HttpContext.Session.GetString("APIToken"));
            return Json(new { data = oLista });
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> CreateProductor([FromBody] Productor productor)
        {
            object resultado;
            string mensaje = String.Empty;
            try
            {
                if (productor.Id == 0)
                {
                    if (productor.ApeyNom != "")
                    {
                        productor = await _apiService.AddProductor(productor, HttpContext.Session.GetString("APIToken"));
                        resultado = productor.Id;
                        mensaje = "Productor ingresado correctamente";
                    }
                    else
                    {
                        resultado = false;
                        mensaje = "Por favor ingrese el Apellido y Nombre";
                    }

                }


                else
                {
                    if (productor.ApeyNom != "")
                    {
                        await _apiService.UpdateProductor(productor.Id, productor, HttpContext.Session.GetString("APIToken"));

                        resultado = true;
                        mensaje = "Productor modificado correctamente";

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

            Productor productor = new Productor();
            productor = await _apiService.GetProductorById(id, HttpContext.Session.GetString("APIToken"));
            return View(productor);
        }

        [Authorize(Roles = "Admin,Student")]
        public async Task<IActionResult> Delete(int id)
        {

            Productor productor = new Productor();
            productor = await _apiService.GetProductorById(id, HttpContext.Session.GetString("APIToken"));
            return View(productor);
        }

        [Authorize(Roles = "Admin,Student")]

        public async Task<JsonResult> DeleteProductor([FromBody] Productor productor)
        {
            bool resultado = false;
            string mensaje = string.Empty;
            try
            {
                await _apiService.DeleteProductor(productor.Id, HttpContext.Session.GetString("APIToken"));
                resultado = true;
                mensaje = "Productor eliminado correctante";
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
