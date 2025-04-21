using FrontEnd.Models;
using FrontEnd.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace FrontEnd.Controllers
{
    public class CalleController : Controller
    {
        private readonly ApiService _apiService;

        public CalleController()
        {
            _apiService = new ApiService();
        }

        [Authorize(Roles = "Admin")]
        [ResponseCache(Duration =30)]
        public async Task<IActionResult> Index()
        {
            List<Calle> lstCalle = new List<Calle>();
            lstCalle = await _apiService.GetAllCalles(HttpContext.Session.GetString("APIToken"));
            return View(lstCalle);
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

        [Authorize(Roles ="Admin,Student")]
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
