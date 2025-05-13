using Frontend.Models;
using FrontEnd.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft;


namespace FrontEnd.Controllers
{
    public class SocioController : Controller
    {
        private readonly ApiService _apiService;
        private readonly IConfiguration _config;

        public SocioController(IConfiguration config)
        {
            _apiService = new ApiService();
            _config = config;
        }

        [Authorize(Roles = "Admin")]
        [ResponseCache(Duration = 30)]
        public async Task<IActionResult> Index()
        {
            int pagesize = _config.GetValue<int>("PageSettings:PageSize");
            List<Socio> lstSocio = new List<Socio>();
            lstSocio = await _apiService.GetAllSocios(HttpContext.Session.GetString("APIToken"));
            return View();

        }


        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> GetAllSocios()
        {
            List<Socio> oLista = new List<Socio>();
            oLista = await _apiService.GetAllSocios(HttpContext.Session.GetString("APIToken"));
            return Json(new { data = oLista });
        }


        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            return View();
        }



        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> CreateSocio([FromBody] Socio socio)
        {
            object resultado;
            string mensaje = String.Empty;
            try
            {
                if (socio.Id == 0)
                {
                    if (socio.ApeyNom != "")
                    {
                        socio = await _apiService.AddSocio(socio, HttpContext.Session.GetString("APIToken"));
                        resultado = socio.Id;
                        mensaje = "Socio ingresado correctamente";
                    }
                    else
                    {
                        resultado = false;
                        mensaje = "Por favor ingrese el Apellido y Nombre";
                    }
                }
                else
                {
                    if (socio.ApeyNom != "")
                    {
                        await _apiService.UpdateSocio(socio.Id, socio, HttpContext.Session.GetString("APIToken"));

                        resultado = true;
                        mensaje = "Socio modificado correctamente";
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
            Socio socio = new Socio();
            socio = await _apiService.GetSocioById(id, HttpContext.Session.GetString("APIToken"));
            return View(socio);
        }


        //[Authorize(Roles = "Admin")]
        //public async Task<IActionResult> UpdateSocio(int id, Socio Socio)
        //{
        //    await _apiService.UpdateSocio(id, Socio, HttpContext.Session.GetString("APIToken"));
        //    return RedirectToAction("Index");
        //}

        [Authorize(Roles = "Admin,Student")]
        public async Task<IActionResult> Delete(int id)
        {

            Socio Socio = new Socio();
            Socio = await _apiService.GetSocioById(id, HttpContext.Session.GetString("APIToken"));
            return View(Socio);
        }

        [Authorize(Roles = "Admin,Student")]

        public async Task<JsonResult> DeleteSocio([FromBody] Socio Socio)
        {
            bool resultado = false;
            string mensaje = string.Empty;
            try
            {
                await _apiService.DeleteSocio(Socio.Id, HttpContext.Session.GetString("APIToken"));
                resultado = true;
                mensaje = "Socio eliminado correctante";
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
