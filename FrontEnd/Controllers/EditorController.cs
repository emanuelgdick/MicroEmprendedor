using Frontend.Models;
using FrontEnd.Models;
using FrontEnd.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft;

namespace FrontEnd.Controllers
{
    public class EditorController : Controller
    {
        private readonly ApiService _apiService;
        private readonly IConfiguration _config;
        public EditorController(IConfiguration config)
        {
            _apiService = new ApiService();
            _config = config;
        }

        [Authorize(Roles = "Admin")]
        [ResponseCache(Duration = 30)]
        public async Task<IActionResult> Index()
        {
            int pagesize = _config.GetValue<int>("PageSettings:PageSize");
            List<Editor> lstEditor = new List<Editor>();
            lstEditor = await _apiService.GetAllEditors(HttpContext.Session.GetString("APIToken"));
            return View();
        }

        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> GetAllEditors()
        {
            List<Editor> oLista = new List<Editor>();
            oLista = await _apiService.GetAllEditors(HttpContext.Session.GetString("APIToken"));
            return Json(new { data = oLista });
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> CreateEditor([FromBody] Editor editor)
        {
            object resultado;
            string mensaje = String.Empty;
            try
            {
                if (editor.Id == 0)
                {
                    if (editor.Descripcion != "")
                    {
                        editor = await _apiService.AddEditor(editor, HttpContext.Session.GetString("APIToken"));
                        resultado = editor.Id;
                        mensaje = "Editor ingresado correctamente";
                    }
                    else
                    {
                        resultado = false;
                        mensaje = "Por favor ingrese la Descripción";
                    }
                }
                else
                {
                    if (editor.Descripcion != "")
                    {
                        await _apiService.UpdateEditor(editor.Id, editor, HttpContext.Session.GetString("APIToken"));
                        resultado = true;
                        mensaje = "Editor Modificado correctamente";
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
            Editor editor = new Editor();
            editor = await _apiService.GetEditorById(id, HttpContext.Session.GetString("APIToken"));
            return View(editor);
        }


        [Authorize(Roles = "Admin,Student")]
        public async Task<IActionResult> Delete(int id)
        {
            Editor editor = new Editor();
            editor = await _apiService.GetEditorById(id, HttpContext.Session.GetString("APIToken"));
            return View(editor);
        }

        [Authorize(Roles = "Admin,Student")]

        public async Task<JsonResult> DeleteEditor([FromBody] Editor editor)
        {
            bool resultado = false;
            string mensaje = string.Empty;
            try
            {
                await _apiService.DeleteEditor(editor.Id, HttpContext.Session.GetString("APIToken"));
                resultado = true;
                mensaje = "Editor eliminado correctante";
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
