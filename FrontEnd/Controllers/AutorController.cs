using Frontend.Models;
using FrontEnd.Models;
using FrontEnd.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft;





namespace FrontEnd.Controllers
{
    public class AutorController : Controller
    {
        private readonly ApiService _apiService;
        private readonly IConfiguration _config;

        public AutorController(IConfiguration config)
        {
            _apiService = new ApiService();
            _config = config;
        }

        [Authorize(Roles = "Admin")]
        [ResponseCache(Duration = 30)]
        public async Task<IActionResult> Index()
        {
            int pagesize = _config.GetValue<int>("PageSettings:PageSize");
            List<Autor> lstAutor = new List<Autor>();
            lstAutor = await _apiService.GetAllAutores(HttpContext.Session.GetString("APIToken"));
            return View();

        }


        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> GetAllAutores()
        {
            List<Autor> oLista = new List<Autor>();
            oLista = await _apiService.GetAllAutores(HttpContext.Session.GetString("APIToken"));

            return Json(new { data = oLista });
        }


        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            return View();
        }



        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> CreateAutor([FromBody] Autor Autor)
        {
            object resultado;
            string mensaje = String.Empty;
            try
            {
                if (Autor.Id == 0)
                {
                    if (Autor.ApeyNom != "")
                    {
                        Autor = await _apiService.AddAutor(Autor, HttpContext.Session.GetString("APIToken"));
                        resultado = Autor.Id;
                        mensaje = "Autor ingresado correctamente";
                    }
                    else
                    {
                        resultado = false;
                        mensaje = "Por favor ingrese el Apellido y Nombre";
                    }

                }


                else
                {
                    if (Autor.ApeyNom != "")
                    {
                        await _apiService.UpdateAutor(Autor.Id, Autor, HttpContext.Session.GetString("APIToken"));

                        resultado = true;
                        mensaje = "Autor Modificado correctamente";

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

            Autor Autor = new Autor();
            Autor = await _apiService.GetAutorById(id, HttpContext.Session.GetString("APIToken"));
            return View(Autor);
        }


        //[Authorize(Roles = "Admin")]
        //public async Task<IActionResult> UpdateAutor(int id, Autor Autor)
        //{
        //    await _apiService.UpdateAutor(id, Autor, HttpContext.Session.GetString("APIToken"));
        //    return RedirectToAction("Index");
        //}

        [Authorize(Roles = "Admin,Student")]
        public async Task<IActionResult> Delete(int id)
        {

            Autor Autor = new Autor();
            Autor = await _apiService.GetAutorById(id, HttpContext.Session.GetString("APIToken"));
            return View(Autor);
        }

        [Authorize(Roles = "Admin,Student")]

        public async Task<JsonResult> DeleteAutor([FromBody] Autor Autor)
        {
            bool resultado = false;
            string mensaje = string.Empty;
            try
            {
                await _apiService.DeleteAutor(Autor.Id, HttpContext.Session.GetString("APIToken"));
                resultado = true;
                mensaje = "Autor eliminado correctante";
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
