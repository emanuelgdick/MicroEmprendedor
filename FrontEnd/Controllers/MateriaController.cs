using Frontend.Models;
using FrontEnd.Models;
using FrontEnd.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft;

namespace FrontEnd.Controllers
{
    public class MateriaController : Controller
    {
        private readonly ApiService _apiService;
        private readonly IConfiguration _config;

        public MateriaController(IConfiguration config)
        {
            _apiService = new ApiService();
            _config = config;
        }

        [Authorize(Roles = "Admin")]
        [ResponseCache(Duration = 30)]
        public async Task<IActionResult> Index()
        {
            int pagesize = _config.GetValue<int>("PageSettings:PageSize");
            List<Materia> lstMateria = new List<Materia>();
            lstMateria = await _apiService.GetAllMaterias(HttpContext.Session.GetString("APIToken"));
            return View();
        }


        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> GetAllMaterias()
        {
            List<Materia> oLista = new List<Materia>();
            oLista = await _apiService.GetAllMaterias(HttpContext.Session.GetString("APIToken"));
            return Json(new { data = oLista });
        }


        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> CreateMateria([FromBody] Materia materia)
        {
            object resultado;
            string mensaje = String.Empty;
            try
            {
                if (materia.Id == 0)
                {
                    if (materia.Descripcion != "")
                    {
                        materia = await _apiService.AddMateria(materia, HttpContext.Session.GetString("APIToken"));
                        resultado = materia.Id;
                        mensaje = "Materia ingresada correctamente";
                    }
                    else
                    {
                        resultado = false;
                        mensaje = "Por favor ingrese la Descripción";
                    }

                }


                else
                {
                    if (materia.Descripcion != "")
                    {
                        await _apiService.UpdateMateria(materia.Id, materia, HttpContext.Session.GetString("APIToken"));

                        resultado = true;
                        mensaje = "Materia modificada correctamente";

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

            Materia materia = new Materia();
            materia = await _apiService.GetMateriaById(id, HttpContext.Session.GetString("APIToken"));
            return View(materia);
        }


        [Authorize(Roles = "Admin,Student")]
        public async Task<IActionResult> Delete(int id)
        {

            Materia materia = new Materia();
            materia = await _apiService.GetMateriaById(id, HttpContext.Session.GetString("APIToken"));
            return View(materia);
        }

        [Authorize(Roles = "Admin,Student")]

        public async Task<JsonResult> DeleteMateria([FromBody] Materia materia)
        {
            bool resultado = false;
            string mensaje = string.Empty;
            try
            {
                await _apiService.DeleteMateria(materia.Id, HttpContext.Session.GetString("APIToken"));
                resultado = true;
                mensaje = "Materia eliminada correctante";
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
