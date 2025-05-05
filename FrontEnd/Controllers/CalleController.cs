using FrontEnd.Models;
using FrontEnd.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft;





namespace FrontEnd.Controllers
{
    public class CalleController : Controller
    {
        private readonly ApiService _apiService;
        private readonly IConfiguration _config;

        public CalleController(IConfiguration config)
        {
            _apiService = new ApiService();
            _config = config;
        }

        [Authorize(Roles = "Admin")]
        [ResponseCache(Duration = 30)]
        public async Task<IActionResult> Index()
        {
            int pagesize = _config.GetValue<int>("PageSettings:PageSize");
            List<Calle> lstCalle = new List<Calle>();
            lstCalle = await _apiService.GetAllCalles(HttpContext.Session.GetString("APIToken"));
            return View();

        }


        [Authorize(Roles = "Admin")]
        public async Task<JsonResult>  GetAllCalle()
        {
            List<Calle> oLista = new List<Calle>();
            oLista = await _apiService.GetAllCalles(HttpContext.Session.GetString("APIToken"));
       
            return Json(new { data = oLista });
        }


        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            return View();
        }



        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> CreateCalle([FromBody] Calle calle)
        {
            object resultado;
            string mensaje = String.Empty;
            try
            {
                if (calle.Id == 0)
                {
                    if (calle.Descripcion != "")
                    {
                        calle= await _apiService.AddCalle(calle, HttpContext.Session.GetString("APIToken"));
                        resultado = calle.Id;
                        mensaje = "Calle ingresada correctamente";
                    }
                    else
                    {
                        resultado = false;
                        mensaje = "Por favor ingrese la descripción";
                    }

                }


                else
                {
                    if (calle.Descripcion != "")
                    {
                        await _apiService.UpdateCalle(calle.Id, calle, HttpContext.Session.GetString("APIToken"));
                        
                        resultado = true;
                        mensaje = "Calle Modificada correctamente";

                    }
                    else
                    {
                        resultado = false;
                        mensaje = "Por favor ingrese la descripción";
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

            Calle calle = new Calle();
            calle = await _apiService.GetCalleById(id, HttpContext.Session.GetString("APIToken"));
            return View(calle);
        }


        //[Authorize(Roles = "Admin")]
        //public async Task<IActionResult> UpdateCalle(int id, Calle calle)
        //{
        //    await _apiService.UpdateCalle(id, calle, HttpContext.Session.GetString("APIToken"));
        //    return RedirectToAction("Index");
        //}

        [Authorize(Roles = "Admin,Student")]
        public async Task<IActionResult> Delete(int id)
        {

            Calle calle = new Calle();
            calle = await _apiService.GetCalleById(id, HttpContext.Session.GetString("APIToken"));
            return View(calle);
        }

        [Authorize(Roles = "Admin,Student")]
        
        public async Task<JsonResult> DeleteCalle([FromBody] Calle calle)
        {
            bool resultado = false;
            string mensaje = string.Empty;
            try
            {
                await _apiService.DeleteCalle(calle.Id, HttpContext.Session.GetString("APIToken"));
                resultado = true;
                mensaje = "Calle eliminada correctante";
            }catch (Exception ex)
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
