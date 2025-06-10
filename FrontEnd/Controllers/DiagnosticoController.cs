using Frontend.Models;
using FrontEnd.Models;
using FrontEnd.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft;

namespace FrontEnd.Controllers
{
    public class DiagnosticoController : Controller
    {
        private readonly ApiService _apiService;
        private readonly IConfiguration _config;

        public DiagnosticoController(IConfiguration config)
        {
            _apiService = new ApiService();
            _config = config;
        }

        [Authorize(Roles = "Admin")]
        [ResponseCache(Duration = 30)]
        public async Task<IActionResult> Index()
        {
            int pagesize = _config.GetValue<int>("PageSettings:PageSize");
            List<Diagnostico> lstDiagnostico = new List<Diagnostico>();
            lstDiagnostico = await _apiService.GetAllDiagnosticos(HttpContext.Session.GetString("APIToken"));
            return View();

        }


        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> GetAllDiagnosticos()
        {
            List<Diagnostico> oLista = new List<Diagnostico>();
            oLista = await _apiService.GetAllDiagnosticos(HttpContext.Session.GetString("APIToken"));
            return Json(new { data = oLista });
        }


        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            return View();
        }



        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> CreateDiagnostico([FromBody] Diagnostico diagnostico)
        {
            object resultado;
            string mensaje = String.Empty;
            try
            {
                if (diagnostico.Id == 0)
                {
                    if (diagnostico.Descripcion != "")
                    {
                        diagnostico = await _apiService.AddDiagnostico(diagnostico, HttpContext.Session.GetString("APIToken"));
                        resultado = diagnostico.Id;
                        mensaje = "Diagnóstico ingresado correctamente";
                    }
                    else
                    {
                        resultado = false;
                        mensaje = "Por favor ingrese la Descripción";
                    }

                }


                else
                {
                    if (diagnostico.Descripcion != "")
                    {
                        await _apiService.UpdateDiagnostico(diagnostico.Id, diagnostico, HttpContext.Session.GetString("APIToken"));

                        resultado = true;
                        mensaje = "Diagnóstico modificado correctamente";

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

            Diagnostico Diagnostico = new Diagnostico();
            Diagnostico = await _apiService.GetDiagnosticoById(id, HttpContext.Session.GetString("APIToken"));
            return View(Diagnostico);
        }


        [Authorize(Roles = "Admin,Student")]
        public async Task<IActionResult> Delete(int id)
        {

            Diagnostico Diagnostico = new Diagnostico();
            Diagnostico = await _apiService.GetDiagnosticoById(id, HttpContext.Session.GetString("APIToken"));
            return View(Diagnostico);
        }

        [Authorize(Roles = "Admin,Student")]

        public async Task<JsonResult> DeleteDiagnostico([FromBody] Diagnostico diagnostico)
        {
            bool resultado = false;
            string mensaje = string.Empty;
            try
            {
                await _apiService.DeleteDiagnostico(diagnostico.Id, HttpContext.Session.GetString("APIToken"));
                resultado = true;
                mensaje = "Diagnóstico eliminado correctamente";
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
