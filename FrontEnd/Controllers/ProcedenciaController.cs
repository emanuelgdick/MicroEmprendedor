using Frontend.Models;
using FrontEnd.Models;
using FrontEnd.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft;

namespace FrontEnd.Controllers
{
    public class ProcedenciaController : Controller
    {
        private readonly ApiService _apiService;
        private readonly IConfiguration _config;

        public ProcedenciaController(IConfiguration config)
        {
            _apiService = new ApiService();
            _config = config;
        }

        [Authorize(Roles = "Admin")]
        [ResponseCache(Duration = 30)]
        public async Task<IActionResult> Index()
        {
            int pagesize = _config.GetValue<int>("PageSettings:PageSize");
            List<Procedencia> lstProcedencia = new List<Procedencia>();
            lstProcedencia = await _apiService.GetAllProcedencias(HttpContext.Session.GetString("APIToken"));
            return View();

        }


        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> GetAllProcedencias()
        {
            List<Procedencia> oLista = new List<Procedencia>();
            oLista = await _apiService.GetAllProcedencias(HttpContext.Session.GetString("APIToken"));
            return Json(new { data = oLista });
        }


        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            return View();
        }



        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> CreateProcedencia([FromBody] Procedencia procedencia)
        {
            object resultado;
            string mensaje = String.Empty;
            try
            {
                if (procedencia.Id == 0)
                {
                    if (procedencia.Descripcion != "")
                    {
                        procedencia = await _apiService.AddProcedencia(procedencia, HttpContext.Session.GetString("APIToken"));
                        resultado = procedencia.Id;
                        mensaje = "Procedencia ingresada correctamente";
                    }
                    else
                    {
                        resultado = false;
                        mensaje = "Por favor ingrese la Descripción";
                    }

                }


                else
                {
                    if (procedencia.Descripcion != "")
                    {
                        await _apiService.UpdateProcedencia(procedencia.Id, procedencia, HttpContext.Session.GetString("APIToken"));

                        resultado = true;
                        mensaje = "Procedencia modificada correctamente";

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

            Procedencia procedencia = new Procedencia();
            procedencia = await _apiService.GetProcedenciaById(id, HttpContext.Session.GetString("APIToken"));
            return View(procedencia);
        }


        [Authorize(Roles = "Admin,Student")]
        public async Task<IActionResult> Delete(int id)
        {
            Procedencia procedencia = new Procedencia();
            procedencia = await _apiService.GetProcedenciaById(id, HttpContext.Session.GetString("APIToken"));
            return View(procedencia);
        }

        [Authorize(Roles = "Admin,Student")]

        public async Task<JsonResult> DeleteProcedencia([FromBody] Procedencia procedencia)
        {
            bool resultado = false;
            string mensaje = string.Empty;
            try
            {
                await _apiService.DeleteProcedencia(procedencia.Id, HttpContext.Session.GetString("APIToken"));
                resultado = true;
                mensaje = "Procedencia eliminada correctante";
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
