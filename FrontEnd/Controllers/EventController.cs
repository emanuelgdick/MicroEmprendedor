using Frontend.Models;
using FrontEnd.Models;
using FrontEnd.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft;

namespace FrontEnd.Controllers
{
    public class EventController : Controller
    {
        private readonly ApiService _apiService;
        private readonly IConfiguration _config;

        public EventController(IConfiguration config)
        {
            _apiService = new ApiService();
            _config = config;
        }

        [Authorize(Roles = "Admin")]
        [ResponseCache(Duration = 30)]
        public async Task<IActionResult> Index()
        {
            int pagesize = _config.GetValue<int>("PageSettings:PageSize");
            List<Event> lstEvent = new List<Event>();
            lstEvent = await _apiService.GetAllEvents(HttpContext.Session.GetString("APIToken"));
            return View();

        }


        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> GetAllEvents()
        {
            List<Event> oLista = new List<Event>();
            oLista = await _apiService.GetAllEvents(HttpContext.Session.GetString("APIToken"));
            return Json(new { data = oLista });
        }


        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            return View();
        }



        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> CreateEvent([FromBody] Event Event)
        {
            object resultado;
            string mensaje = String.Empty;
            try
            {
                if (Event.Id == 0)
                {
                    //if (Event.Start != "")
                    //{
                        Event = await _apiService.AddEvent(Event, HttpContext.Session.GetString("APIToken"));
                        resultado = Event.Id;
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
                        await _apiService.UpdateEvent(Event.Id, Event, HttpContext.Session.GetString("APIToken"));

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

            Event Event = new Event();
            Event = await _apiService.GetEventById(id, HttpContext.Session.GetString("APIToken"));
            return View(Event);
        }


        [Authorize(Roles = "Admin,Student")]
        public async Task<IActionResult> Delete(int id)
        {

            Event Event = new Event();
            Event = await _apiService.GetEventById(id, HttpContext.Session.GetString("APIToken"));
            return View(Event);
        }

        [Authorize(Roles = "Admin,Student")]

        public async Task<JsonResult> DeleteEvent([FromBody] Event Event)
        {
            bool resultado = false;
            string mensaje = string.Empty;
            try
            {
                await _apiService.DeleteEvent(Event.Id, HttpContext.Session.GetString("APIToken"));
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
