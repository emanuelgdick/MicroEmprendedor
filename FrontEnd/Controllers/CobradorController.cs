using Frontend.Models;
using FrontEnd.Models;
using FrontEnd.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft;


namespace FrontEnd.Controllers
{
    public class CobradorController : Controller
    {
        private readonly ApiService _apiService;
        private readonly IConfiguration _config;

        public CobradorController(IConfiguration config)
        {
            _apiService = new ApiService();
            _config = config;
        }

        [Authorize(Roles = "Admin")]
        [ResponseCache(Duration = 30)]
        public async Task<IActionResult> Index()
        {
            int pagesize = _config.GetValue<int>("PageSettings:PageSize");
            List<Cobrador> lstCobrador = new List<Cobrador>();
            lstCobrador = await _apiService.GetAllCobradores(HttpContext.Session.GetString("APIToken"));
            return View();

        }


        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> GetAllCobradores()
        {
            List<Cobrador> oLista = new List<Cobrador>();
            oLista = await _apiService.GetAllCobradores(HttpContext.Session.GetString("APIToken"));

            return Json(new { data = oLista });
        }


        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            return View();
        }



        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> CreateCobrador([FromBody] Cobrador Cobrador)
        {
            object resultado;
            string mensaje = String.Empty;
            try
            {
                if (Cobrador.Id == 0)
                {
                    if (Cobrador.ApeyNom != "")
                    {
                        Cobrador = await _apiService.AddCobrador(Cobrador, HttpContext.Session.GetString("APIToken"));
                        resultado = Cobrador.Id;
                        mensaje = "Cobrador ingresado correctamente";
                    }
                    else
                    {
                        resultado = false;
                        mensaje = "Por favor ingrese el Apellido y Nombre";
                    }

                }


                else
                {
                    if (Cobrador.ApeyNom != "")
                    {
                        await _apiService.UpdateCobrador(Cobrador.Id, Cobrador, HttpContext.Session.GetString("APIToken"));

                        resultado = true;
                        mensaje = "Cobrador Modificado correctamente";

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

            Cobrador Cobrador = new Cobrador();
            Cobrador = await _apiService.GetCobradorById(id, HttpContext.Session.GetString("APIToken"));
            return View(Cobrador);
        }


        //[Authorize(Roles = "Admin")]
        //public async Task<IActionResult> UpdateCobrador(int id, Cobrador Cobrador)
        //{
        //    await _apiService.UpdateCobrador(id, Cobrador, HttpContext.Session.GetString("APIToken"));
        //    return RedirectToAction("Index");
        //}

        [Authorize(Roles = "Admin,Student")]
        public async Task<IActionResult> Delete(int id)
        {

            Cobrador Cobrador = new Cobrador();
            Cobrador = await _apiService.GetCobradorById(id, HttpContext.Session.GetString("APIToken"));
            return View(Cobrador);
        }

        [Authorize(Roles = "Admin,Student")]

        public async Task<JsonResult> DeleteCobrador([FromBody] Cobrador Cobrador)
        {
            bool resultado = false;
            string mensaje = string.Empty;
            try
            {
                await _apiService.DeleteCobrador(Cobrador.Id, HttpContext.Session.GetString("APIToken"));
                resultado = true;
                mensaje = "Cobrador eliminado correctante";
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
