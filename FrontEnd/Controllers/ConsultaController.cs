using Frontend.Models;
using FrontEnd.Models;
using FrontEnd.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft;

namespace FrontEnd.Controllers
{
    
    public class ConsultaController : Controller
    {
        private readonly ApiService _apiService;
        private readonly IConfiguration _config;

        public ConsultaController(IConfiguration config)
        {
            _apiService = new ApiService();
            _config = config;
        }

        [Authorize(Roles = "Admin")]
        [ResponseCache(Duration = 30)]
        public async Task<IActionResult> Index()
        {
            int pagesize = _config.GetValue<int>("PageSettings:PageSize");
            List<Consulta> lstEvent = new List<Consulta>();
            lstEvent = await _apiService.GetAllConsulta(HttpContext.Session.GetString("APIToken"));
            return View();

        }


        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> Events(string start,string end)
        {
            List<Consulta> oLista = new List<Consulta>();
            oLista = await _apiService.GetAllConsulta(HttpContext.Session.GetString("APIToken"));
            return Json(new { data = oLista });
        }


        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            return View();
        }



        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> CreateEvent([FromBody] Consulta consulta)
        {
            object resultado;
            string mensaje = String.Empty;
            try
            {
                if (consulta.Id == 0)
                {
                    //if (Event.Start != "")
                    //{
                    consulta = await _apiService.AddEvent(consulta, HttpContext.Session.GetString("APIToken"));
                        resultado = consulta.Id;
                        mensaje = "Event ingresada correctamente";
                    //}
                    //else
                    //{
                    //    resultado = false;
                    //    mensaje = "Por favor ingrese la Descripción";
                    //}

                }


                else
                {
                    //if (Event.Descripcion != "")
                    //{
                        await _apiService.UpdateEvent(consulta.Id, consulta, HttpContext.Session.GetString("APIToken"));

                        resultado = true;
                        mensaje = "Event modificado correctamente";

                    //}
                    //else
                    //{
                    //    resultado = false;
                    //    mensaje = "Por favor ingrese la Descripción";
                    //}

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

            Consulta Consulta = new Consulta();
            Consulta = await _apiService.GetEventById(id, HttpContext.Session.GetString("APIToken"));
            return View(Consulta);
        }


        [Authorize(Roles = "Admin,Student")]
        public async Task<IActionResult> Delete(int id)
        {

            Consulta Consulta = new Consulta();
            Consulta = await _apiService.GetEventById(id, HttpContext.Session.GetString("APIToken"));
            return View(Consulta);
        }

        [Authorize(Roles = "Admin,Student")]

        public async Task<JsonResult> DeleteEvent([FromBody] Consulta Consulta)
        {
            bool resultado = false;
            string mensaje = string.Empty;
            try
            {
                await _apiService.DeleteEvent(Consulta.Id, HttpContext.Session.GetString("APIToken"));
                resultado = true;
                mensaje = "Event eliminada correctamente";
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
