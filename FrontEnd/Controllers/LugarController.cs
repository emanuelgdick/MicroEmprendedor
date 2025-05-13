using Frontend.Models;
using FrontEnd.Models;
using FrontEnd.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft;

namespace FrontEnd.Controllers
{
    public class LugarController : Controller
    {
        private readonly ApiService _apiService;
        private readonly IConfiguration _config;

        public LugarController(IConfiguration config)
        {
            _apiService = new ApiService();
            _config = config;
        }

        [Authorize(Roles = "Admin")]
        [ResponseCache(Duration = 30)]
        public async Task<IActionResult> Index()
        {
            int pagesize = _config.GetValue<int>("PageSettings:PageSize");
            List<Lugar> lstLugar = new List<Lugar>();
            lstLugar = await _apiService.GetAllLugares(HttpContext.Session.GetString("APIToken"));
            return View();

        }


        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> GetAllLugares()
        {
            List<Lugar> oLista = new List<Lugar>();
            oLista = await _apiService.GetAllLugares(HttpContext.Session.GetString("APIToken"));

            return Json(new { data = oLista });
        }


        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            return View();
        }



        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> CreateLugar([FromBody] Lugar lugar)
        {
            object resultado;
            string mensaje = String.Empty;
            try
            {
                if (lugar.Id == 0)
                {
                    if (lugar.Descripcion != "")
                    {
                        lugar = await _apiService.AddLugar(lugar, HttpContext.Session.GetString("APIToken"));
                        resultado = lugar.Id;
                        mensaje = "Lugar ingresado correctamente";
                    }
                    else
                    {
                        resultado = false;
                        mensaje = "Por favor ingrese la Descripción";
                    }

                }


                else
                {
                    if (lugar.Descripcion != "")
                    {
                        await _apiService.UpdateLugar(lugar.Id, lugar, HttpContext.Session.GetString("APIToken"));

                        resultado = true;
                        mensaje = "Lugar modificado correctamente";

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

            Lugar lugar = new Lugar();
            lugar = await _apiService.GetLugarById(id, HttpContext.Session.GetString("APIToken"));
            return View(lugar);
        }


        [Authorize(Roles = "Admin,Student")]
        public async Task<IActionResult> Delete(int id)
        {

            Lugar lugar = new Lugar();
            lugar = await _apiService.GetLugarById(id, HttpContext.Session.GetString("APIToken"));
            return View(lugar);
        }

        [Authorize(Roles = "Admin,Student")]

        public async Task<JsonResult> DeleteLugar([FromBody] Lugar lugar)
        {
            bool resultado = false;
            string mensaje = string.Empty;
            try
            {
                await _apiService.DeleteLugar(lugar.Id, HttpContext.Session.GetString("APIToken"));
                resultado = true;
                mensaje = "Lugar eliminado correctante";
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
