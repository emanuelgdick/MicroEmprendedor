using FrontEnd.Models;
using FrontEnd.Models.DTOs;
using FrontEnd.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft;
using System.Security.Claims;



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
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            string userId = string.Empty;
            if (userIdClaim != null)
            {
                 userId=userIdClaim.Value;
            }
            TotalesDTO totales = new TotalesDTO();
            totales = await _apiService.GetTotales(int.Parse(userId),HttpContext.Session.GetString("APIToken"));
            return View(totales);

        }
    }
}