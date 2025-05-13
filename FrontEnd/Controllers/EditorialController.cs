using Frontend.Models;
using FrontEnd.Models;
using FrontEnd.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft;

namespace FrontEnd.Controllers
{
    public class EditorialController : Controller
    {
        private readonly ApiService _apiService;
        private readonly IConfiguration _config;

        public EditorialController(IConfiguration config)
        {
            _apiService = new ApiService();
            _config = config;
        }

        [Authorize(Roles = "Admin")]
        [ResponseCache(Duration = 30)]
        public async Task<IActionResult> Index()
        {
            int pagesize = _config.GetValue<int>("PageSettings:PageSize");
            List<Editorial> lstEditorial = new List<Editorial>();
            lstEditorial = await _apiService.GetAllEditoriales(HttpContext.Session.GetString("APIToken"));
            return View();

        }


        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> GetAllEditoriales()
        {
            List<Editorial> oLista = new List<Editorial>();
            oLista = await _apiService.GetAllEditoriales(HttpContext.Session.GetString("APIToken"));
            return Json(new { data = oLista });
        }


        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            return View();
        }



        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> CreateEditorial([FromBody] Editorial editorial)
        {
            object resultado;
            string mensaje = String.Empty;
            try
            {
                if (editorial.Id == 0)
                {
                    if (editorial.Descripcion != "")
                    {
                        editorial = await _apiService.AddEditorial(editorial, HttpContext.Session.GetString("APIToken"));
                        resultado = editorial.Id;
                        mensaje = "Editorial ingresada correctamente";
                    }
                    else
                    {
                        resultado = false;
                        mensaje = "Por favor ingrese la Descripción";
                    }

                }


                else
                {
                    if (editorial.Descripcion != "")
                    {
                        await _apiService.UpdateEditorial(editorial.Id, editorial, HttpContext.Session.GetString("APIToken"));

                        resultado = true;
                        mensaje = "Editorial Modificada correctamente";

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

            Editorial editorial = new Editorial();
            editorial = await _apiService.GetEditorialById(id, HttpContext.Session.GetString("APIToken"));
            return View(editorial);
        }


        [Authorize(Roles = "Admin,Student")]
        public async Task<IActionResult> Delete(int id)
        {

            Editorial editorial = new Editorial();
            editorial = await _apiService.GetEditorialById(id, HttpContext.Session.GetString("APIToken"));
            return View(editorial);
        }

        [Authorize(Roles = "Admin,Student")]

        public async Task<JsonResult> DeleteEditorial([FromBody] Editorial editorial)
        {
            bool resultado = false;
            string mensaje = string.Empty;
            try
            {
                await _apiService.DeleteEditorial(editorial.Id, HttpContext.Session.GetString("APIToken"));
                resultado = true;
                mensaje = "Editorial eliminada correctante";
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
