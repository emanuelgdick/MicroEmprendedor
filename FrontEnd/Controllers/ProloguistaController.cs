using Frontend.Models;
using FrontEnd.Models;
using FrontEnd.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft;

namespace FrontEnd.Controllers
{
    public class ProloguistaController : Controller
    {
        private readonly ApiService _apiService;
        private readonly IConfiguration _config;
        public ProloguistaController(IConfiguration config)
        {
            _apiService = new ApiService();
            _config = config;
        }

        [Authorize(Roles = "Admin")]
        [ResponseCache(Duration = 30)]
        public async Task<IActionResult> Index()
        {
            int pagesize = _config.GetValue<int>("PageSettings:PageSize");
            List<Prologuista> lstProloguista = new List<Prologuista>();
            lstProloguista = await _apiService.GetAllProloguistas(HttpContext.Session.GetString("APIToken"));
            return View();
        }

        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> GetAllProloguistas()
        {
            List<Prologuista> oLista = new List<Prologuista>();
            oLista = await _apiService.GetAllProloguistas(HttpContext.Session.GetString("APIToken"));
            return Json(new { data = oLista });
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> CreateProloguista([FromBody] Prologuista prologuista)
        {
            object resultado;
            string mensaje = String.Empty;
            try
            {
                if (prologuista.Id == 0)
                {
                    if (prologuista.ApeyNom != "")
                    {
                        prologuista = await _apiService.AddProloguista(prologuista, HttpContext.Session.GetString("APIToken"));
                        resultado = prologuista.Id;
                        mensaje = "Prologuista ingresado correctamente";
                    }
                    else
                    {
                        resultado = false;
                        mensaje = "Por favor ingrese el Apellido y Nombre";
                    }
                }
                else
                {
                    if (prologuista.ApeyNom != "")
                    {
                        await _apiService.UpdateProloguista(prologuista.Id, prologuista, HttpContext.Session.GetString("APIToken"));
                        resultado = true;
                        mensaje = "Prologuista Modificado correctamente";
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
            Prologuista Prologuista = new Prologuista();
            Prologuista = await _apiService.GetProloguistaById(id, HttpContext.Session.GetString("APIToken"));
            return View(Prologuista);
        }

        [Authorize(Roles = "Admin,Student")]
        public async Task<IActionResult> Delete(int id)
        {
            Prologuista prologuista = new Prologuista();
            prologuista = await _apiService.GetProloguistaById(id, HttpContext.Session.GetString("APIToken"));
            return View(prologuista);
        }

        [Authorize(Roles = "Admin,Student")]
        public async Task<JsonResult> DeleteProloguista([FromBody] Prologuista prologuista)
        {
            bool resultado = false;
            string mensaje = string.Empty;
            try
            {
                await _apiService.DeleteProloguista(prologuista.Id, HttpContext.Session.GetString("APIToken"));
                resultado = true;
                mensaje = "Prologuista eliminado correctante";
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
