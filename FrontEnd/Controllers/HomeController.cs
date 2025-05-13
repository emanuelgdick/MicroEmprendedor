using FrontEnd.Models;
using FrontEnd.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft;



namespace Frontend.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApiService _apiService;
        public HomeController()
        {
            _apiService = new ApiService();
        }

        [Authorize(Roles = "Admin")]
        [ResponseCache(Duration = 30)]
        public async Task<IActionResult> Index()
        {
            TotalesDTO totales = new TotalesDTO();
            totales = await _apiService.GetTotales(HttpContext.Session.GetString("APIToken"));
            return View(totales);

        }
    }
}