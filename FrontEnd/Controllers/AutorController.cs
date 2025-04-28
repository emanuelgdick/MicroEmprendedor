using FrontEnd.Models;
using FrontEnd.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using Microsoft.Extensions.Configuration;
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
        public async Task<IActionResult> Index(int pagenumber = 1)
        {
            int pagesize = _config.GetValue<int>("PageSettings:PageSize");
            PageResult<Autor> lstAutor = new PageResult<Autor>();
            lstAutor = await _apiService.GetAllAutores(HttpContext.Session.GetString("APIToken"), pagesize, pagenumber);
            return View(lstAutor);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateAutor(Autor Autor)
        {
            await _apiService.AddAutor(Autor, HttpContext.Session.GetString("APIToken"));
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin,Student")]
        public async Task<IActionResult> Details(int id)
        {

            Autor Autor = new Autor();
            Autor = await _apiService.GetAutorById(id, HttpContext.Session.GetString("APIToken"));
            return View(Autor);
        }


        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateAutor(int id, Autor Autor)
        {
            await _apiService.UpdateAutor(id, Autor, HttpContext.Session.GetString("APIToken"));
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin,Student")]
        public async Task<IActionResult> Delete(int id)
        {

            Autor Autor = new Autor();
            Autor = await _apiService.GetAutorById(id, HttpContext.Session.GetString("APIToken"));
            return View(Autor);
        }

        public async Task<IActionResult> DeleteAutor(int id)
        {
            await _apiService.DeleteAutor(id, HttpContext.Session.GetString("APIToken"));
            return RedirectToAction("Index");
        }

        public IActionResult ErrorPage()
        {
            return View();
        }
    }
}
