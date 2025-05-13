using Frontend.Models;
using FrontEnd.Models;
using FrontEnd.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft;

namespace FrontEnd.Controllers
{
    public class InterpreteController : Controller
    {
        private readonly ApiService _apiService;
        private readonly IConfiguration _config;

        public InterpreteController(IConfiguration config)
        {
            _apiService = new ApiService();
            _config = config;
        }

        [Authorize(Roles = "Admin")]
        [ResponseCache(Duration = 30)]
        public async Task<IActionResult> Index()
        {
            int pagesize = _config.GetValue<int>("PageSettings:PageSize");
            List<Interprete> lstInterprete = new List<Interprete>();
            lstInterprete = await _apiService.GetAllInterpretes(HttpContext.Session.GetString("APIToken"));
            return View();

        }


        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> GetAllInterpretes()
        {
            List<Interprete> oLista = new List<Interprete>();
            oLista = await _apiService.GetAllInterpretes(HttpContext.Session.GetString("APIToken"));
            return Json(new { data = oLista });
        }


        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            return View();
        }



        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> CreateInterprete([FromBody] Interprete interprete)
        {
            object resultado;
            string mensaje = String.Empty;
            try
            {
                if (interprete.Id == 0)
                {
                    if (interprete.Descripcion != "")
                    {
                        interprete = await _apiService.AddInterprete(interprete, HttpContext.Session.GetString("APIToken"));
                        resultado = interprete.Id;
                        mensaje = "Interprete ingresado correctamente";
                    }
                    else
                    {
                        resultado = false;
                        mensaje = "Por favor ingrese la Descripción";
                    }

                }


                else
                {
                    if (interprete.Descripcion != "")
                    {
                        await _apiService.UpdateInterprete(interprete.Id, interprete, HttpContext.Session.GetString("APIToken"));

                        resultado = true;
                        mensaje = "Interprete modificado correctamente";

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

            Interprete interprete = new Interprete();
            interprete = await _apiService.GetInterpreteById(id, HttpContext.Session.GetString("APIToken"));
            return View(interprete);
        }


        [Authorize(Roles = "Admin,Student")]
        public async Task<IActionResult> Delete(int id)
        {

            Interprete interprete = new Interprete();
            interprete = await _apiService.GetInterpreteById(id, HttpContext.Session.GetString("APIToken"));
            return View(interprete);
        }

        [Authorize(Roles = "Admin,Student")]

        public async Task<JsonResult> DeleteInterprete([FromBody] Interprete interprete)
        {
            bool resultado = false;
            string mensaje = string.Empty;
            try
            {
                await _apiService.DeleteInterprete(interprete.Id, HttpContext.Session.GetString("APIToken"));
                resultado = true;
                mensaje = "Interprete eliminado correctante";
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
