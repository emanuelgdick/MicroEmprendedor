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
        public async Task<IActionResult> GetAllCalle()
        {
            List<Calle> oLista = new List<Calle>();
            oLista = await _apiService.GetAllCalles(HttpContext.Session.GetString("APIToken"));
            //return new JsonResult(oLista);// Json(oLista);
          //  return Json(new { data = oLista }, System.Web.Mvc.JsonRequestBehavior.AllowGet);

            //var dat = "{Id:1}";
            //return Json(new { data =dat }, System.Web.Mvc.JsonRequestBehavior.AllowGet);
             return new JsonResult(new { data = oLista });
        }


        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateCalle(Calle calle)
        {
            await _apiService.AddCalle(calle, HttpContext.Session.GetString("APIToken"));
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin,Student")]
        public async Task<IActionResult> Details(int id)
        {

            Calle calle = new Calle();
            calle = await _apiService.GetCalleById(id, HttpContext.Session.GetString("APIToken"));
            return View(calle);
        }


        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateCalle(int id, Calle calle)
        {
            await _apiService.UpdateCalle(id, calle, HttpContext.Session.GetString("APIToken"));
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin,Student")]
        public async Task<IActionResult> Delete(int id)
        {

            Calle calle = new Calle();
            calle = await _apiService.GetCalleById(id, HttpContext.Session.GetString("APIToken"));
            return View(calle);
        }

        public async Task<IActionResult> DeleteCalle(int id)
        {
            await _apiService.DeleteCalle(id, HttpContext.Session.GetString("APIToken"));
            return RedirectToAction("Index");
        }

        public IActionResult ErrorPage()
        {
            return View();
        }
    }
}
