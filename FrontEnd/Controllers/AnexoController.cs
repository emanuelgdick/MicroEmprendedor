using Frontend.Models;
using FrontEnd.Models;
using FrontEnd.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft;

namespace FrontEnd.Controllers
{
    public class AnexoController : Controller
    {
        private readonly ApiService _apiService;
        private readonly IConfiguration _config;

        public AnexoController(IConfiguration config)
        {
            _apiService = new ApiService();
            _config = config;
        }

        [Authorize(Roles = "Admin")]
        [ResponseCache(Duration = 30)]
        public async Task<IActionResult> Index()
        {
            int pagesize = _config.GetValue<int>("PageSettings:PageSize");
            List<Anexo> lstAnexo = new List<Anexo>();
            lstAnexo = await _apiService.GetAllAnexos(HttpContext.Session.GetString("APIToken"));
            return View();

        }


        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> GetAllAnexos()
        {
            List<Anexo> oLista = new List<Anexo>();
            oLista = await _apiService.GetAllAnexos(HttpContext.Session.GetString("APIToken"));

            return Json(new { data = oLista });
        }


        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            return View();
        }



        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> CreateAnexo([FromBody] Anexo Anexo)
        {
            object resultado;
            string mensaje = String.Empty;
            try
            {
                if (Anexo.Id == 0)
                {
                    if (Anexo.Descripcion != "")
                    {
                        Anexo = await _apiService.AddAnexo(Anexo, HttpContext.Session.GetString("APIToken"));
                        resultado = Anexo.Id;
                        mensaje = "Anexo ingresado correctamente";
                    }
                    else
                    {
                        resultado = false;
                        mensaje = "Por favor ingrese la Descripción";
                    }

                }


                else
                {
                    if (Anexo.Descripcion != "")
                    {
                        await _apiService.UpdateAnexo(Anexo.Id, Anexo, HttpContext.Session.GetString("APIToken"));

                        resultado = true;
                        mensaje = "Anexo Modificado correctamente";

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

            Anexo Anexo = new Anexo();
            Anexo = await _apiService.GetAnexoById(id, HttpContext.Session.GetString("APIToken"));
            return View(Anexo);
        }


        //[Authorize(Roles = "Admin")]
        //public async Task<IActionResult> UpdateAnexo(int id, Anexo Anexo)
        //{
        //    await _apiService.UpdateAnexo(id, Anexo, HttpContext.Session.GetString("APIToken"));
        //    return RedirectToAction("Index");
        //}

        [Authorize(Roles = "Admin,Student")]
        public async Task<IActionResult> Delete(int id)
        {

            Anexo Anexo = new Anexo();
            Anexo = await _apiService.GetAnexoById(id, HttpContext.Session.GetString("APIToken"));
            return View(Anexo);
        }

        [Authorize(Roles = "Admin,Student")]

        public async Task<JsonResult> DeleteAnexo([FromBody] Anexo Anexo)
        {
            bool resultado = false;
            string mensaje = string.Empty;
            try
            {
                await _apiService.DeleteAnexo(Anexo.Id, HttpContext.Session.GetString("APIToken"));
                resultado = true;
                mensaje = "Anexo eliminado correctante";
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
