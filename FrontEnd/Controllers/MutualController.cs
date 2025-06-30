using Frontend.Models;
using FrontEnd.Models;
using FrontEnd.Models.DTOs;
using FrontEnd.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft;
using System.Security.Claims;

namespace FrontEnd.Controllers
{
    public class MutualController : Controller
    {
        private readonly ApiService _apiService;
        private readonly IConfiguration _config;

        public MutualController(IConfiguration config)
        {
            _apiService = new ApiService();
            _config = config;
        }

        [Authorize(Roles = "Admin")]
        [ResponseCache(Duration = 30)]
        public async Task<IActionResult> Index()
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            string userId = string.Empty;
            if (userIdClaim != null)
            {
                userId = userIdClaim.Value;
            }
            TotalesDTO totales = new TotalesDTO();
            totales = await _apiService.GetTotales(int.Parse(userId), HttpContext.Session.GetString("APIToken"));
            return View(totales);
        }


        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> GetAllMutuales()
        {
            List<Mutual> oLista = new List<Mutual>();
            oLista = await _apiService.GetAllMutuales(HttpContext.Session.GetString("APIToken"));
            return Json(new { data = oLista });
        }


        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            return View();
        }



        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> CreateMutual([FromBody] Mutual mutual)
        {
            object resultado;
            string mensaje = String.Empty;
            try
            {
                if (mutual.Id == 0)
                {
                    if (mutual.DescA != "")
                    {
                        mutual = await _apiService.AddMutual(mutual, HttpContext.Session.GetString("APIToken"));
                        resultado = mutual.Id;
                        mensaje = "Mutual ingresada correctamente";
                    }
                    else
                    {
                        resultado = false;
                        mensaje = "Por favor ingrese la Descripción";
                    }

                }


                else
                {
                    if (mutual.DescA != "")
                    {
                        await _apiService.UpdateMutual(mutual.Id, mutual, HttpContext.Session.GetString("APIToken"));

                        resultado = true;
                        mensaje = "Mutual modificada correctamente";

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

            Mutual Mutual = new Mutual();
            Mutual = await _apiService.GetMutualById(id, HttpContext.Session.GetString("APIToken"));
            return View(Mutual);
        }


        [Authorize(Roles = "Admin,Student")]
        public async Task<IActionResult> Delete(int id)
        {

            Mutual Mutual = new Mutual();
            Mutual = await _apiService.GetMutualById(id, HttpContext.Session.GetString("APIToken"));
            return View(Mutual);
        }

        [Authorize(Roles = "Admin,Student")]

        public async Task<JsonResult> DeleteMutual([FromBody] Mutual mutual)
        {
            bool resultado = false;
            string mensaje = string.Empty;
            try
            {
                await _apiService.DeleteMutual(mutual.Id, HttpContext.Session.GetString("APIToken"));
                resultado = true;
                mensaje = "Mutual eliminada correctamente";
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
