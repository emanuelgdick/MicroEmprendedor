using Frontend.Models;
using FrontEnd.Models;
using FrontEnd.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft;

namespace FrontEnd.Controllers
{
    public class EditoraController : Controller
    {
        private readonly ApiService _apiService;
        private readonly IConfiguration _config;

        public EditoraController(IConfiguration config)
        {
            _apiService = new ApiService();
            _config = config;
        }

        [Authorize(Roles = "Admin")]
        [ResponseCache(Duration = 30)]
        public async Task<IActionResult> Index()
        {
            int pagesize = _config.GetValue<int>("PageSettings:PageSize");
            List<Editora> lstEditora = new List<Editora>();
            lstEditora = await _apiService.GetAllEditoras(HttpContext.Session.GetString("APIToken"));
            return View();

        }


        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> GetAllEditoras()
        {
            List<Editora> oLista = new List<Editora>();
            oLista = await _apiService.GetAllEditoras(HttpContext.Session.GetString("APIToken"));

            return Json(new { data = oLista });
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> CreateEditora([FromBody] Editora editora)
        {
            object resultado;
            string mensaje = String.Empty;
            try
            {
                if (editora.Id == 0)
                {
                    if (editora.Descripcion != "")
                    {
                        editora = await _apiService.AddEditora(editora, HttpContext.Session.GetString("APIToken"));
                        resultado = editora.Id;
                        mensaje = "Editora ingresada correctamente";
                    }
                    else
                    {
                        resultado = false;
                        mensaje = "Por favor ingrese la Descripción";
                    }

                }


                else
                {
                    if (editora.Descripcion != "")
                    {
                        await _apiService.UpdateEditora(editora.Id, editora, HttpContext.Session.GetString("APIToken"));

                        resultado = true;
                        mensaje = "Editora Modificado correctamente";

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

            Editora Editora = new Editora();
            Editora = await _apiService.GetEditoraById(id, HttpContext.Session.GetString("APIToken"));
            return View(Editora);
        }

        [Authorize(Roles = "Admin,Student")]
        public async Task<IActionResult> Delete(int id)
        {

            Editora editora = new Editora();
            editora = await _apiService.GetEditoraById(id, HttpContext.Session.GetString("APIToken"));
            return View(editora);
        }

        [Authorize(Roles = "Admin,Student")]

        public async Task<JsonResult> DeleteEditora([FromBody] Editora editora)
        {
            bool resultado = false;
            string mensaje = string.Empty;
            try
            {
                await _apiService.DeleteEditora(editora.Id, HttpContext.Session.GetString("APIToken"));
                resultado = true;
                mensaje = "Editora eliminada correctante";
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
