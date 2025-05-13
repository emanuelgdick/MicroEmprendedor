using Frontend.Models;
using FrontEnd.Models;
using FrontEnd.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft;

namespace FrontEnd.Controllers
{
    public class GuionistaController : Controller
    {
        private readonly ApiService _apiService;
        private readonly IConfiguration _config;

        public GuionistaController(IConfiguration config)
        {
            _apiService = new ApiService();
            _config = config;
        }

        [Authorize(Roles = "Admin")]
        [ResponseCache(Duration = 30)]
        public async Task<IActionResult> Index()
        {
            int pagesize = _config.GetValue<int>("PageSettings:PageSize");
            List<Guionista> lstGuionista = new List<Guionista>();
            lstGuionista = await _apiService.GetAllGuionistas(HttpContext.Session.GetString("APIToken"));
            return View();

        }


        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> GetAllGuionistas()
        {
            List<Guionista> oLista = new List<Guionista>();
            oLista = await _apiService.GetAllGuionistas(HttpContext.Session.GetString("APIToken"));
            return Json(new { data = oLista });
        }


        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            return View();
        }


        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> CreateGuionista([FromBody] Guionista guionista)
        {
            object resultado;
            string mensaje = String.Empty;
            try
            {
                if (guionista.Id == 0)
                {
                    if (guionista.ApeyNom != "")
                    {
                        guionista = await _apiService.AddGuionista(guionista, HttpContext.Session.GetString("APIToken"));
                        resultado = guionista.Id;
                        mensaje = "Guionista ingresado correctamente";
                    }
                    else
                    {
                        resultado = false;
                        mensaje = "Por favor ingrese la Descripción";
                    }

                }

                else
                {
                    if (guionista.ApeyNom != "")
                    {
                        await _apiService.UpdateGuionista(guionista.Id, guionista, HttpContext.Session.GetString("APIToken"));
                        resultado = true;
                        mensaje = "Guionista modificado correctamente";

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
            Guionista guionista = new Guionista();
            guionista = await _apiService.GetGuionistaById(id, HttpContext.Session.GetString("APIToken"));
            return View(guionista);
        }


        [Authorize(Roles = "Admin,Student")]
        public async Task<IActionResult> Delete(int id)
        {

            Guionista guionista = new Guionista();
            guionista = await _apiService.GetGuionistaById(id, HttpContext.Session.GetString("APIToken"));
            return View(guionista);
        }

        [Authorize(Roles = "Admin,Student")]

        public async Task<JsonResult> DeleteGuionista([FromBody] Guionista guionista)
        {
            bool resultado = false;
            string mensaje = string.Empty;
            try
            {
                await _apiService.DeleteGuionista(guionista.Id, HttpContext.Session.GetString("APIToken"));
                resultado = true;
                mensaje = "Guionista eliminado correctante";
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
