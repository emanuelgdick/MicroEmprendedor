using Frontend.Models;
using FrontEnd.Models;
using FrontEnd.Models.DTOs;
using FrontEnd.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Newtonsoft;
using System.Security.Claims;

namespace FrontEnd.Controllers
{
    public class RubroController : Controller
    {
        private readonly ApiService _apiService;
        private readonly IConfiguration _config;

        public RubroController(IConfiguration config)
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
        [ResponseCache(Duration = 30)]
        public async Task<JsonResult> GetAllRubros(string? q = null)
        {
            //List<Rubro> oLista = new List<Rubro>();
            //oLista = await _apiService.GetAllRubros(HttpContext.Session.GetString("APIToken"));
            //return Json(new { data = oLista });

            List<Rubro> oLista = new List<Rubro>();
            oLista = await _apiService.GetAllRubros(HttpContext.Session.GetString("APIToken"));
            List<Rubro> resultados = new List<Rubro>();
            if (q == null || q=="null")
            {
                resultados = oLista.ToList();
                
                return Json(new { data = resultados.Select(c => new { id = c.Id, text = c.Descripcion }) });
            }
            else
            {
                resultados = oLista.Where(s => s.Descripcion.ToLower().Contains(q.ToLower())).ToList();
                return Json(new { data = resultados.Select(c => new { id = c.Id, text = c.Descripcion }).ToList() });
            }



        }


        [Authorize(Roles = "Admin")]
        [ResponseCache(Duration = 30)]
        public async Task<IActionResult> Create()
        {
            return View();
        }



        [Authorize(Roles = "Admin")]
        [ResponseCache(Duration = 30)]
        public async Task<JsonResult> CreateRubro([FromBody] Rubro Rubro)
        {
            object resultado;
            string mensaje = String.Empty;
            try
            {
                if (Rubro.Id == 0)
                {
                    if (Rubro.Descripcion != "")
                    {
                        Rubro = await _apiService.AddRubro(Rubro, HttpContext.Session.GetString("APIToken"));
                        resultado = Rubro.Id;
                        mensaje = "Rubro ingresado correctamente";
                    }
                    else
                    {
                        resultado = false;
                        mensaje = "Por favor ingrese la Descripción";
                    }

                }


                else
                {
                    if (Rubro.Descripcion != "")
                    {
                        await _apiService.UpdateRubro(Rubro.Id, Rubro, HttpContext.Session.GetString("APIToken"));

                        resultado = true;
                        mensaje = "Rubro modificado correctamente";

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

            Rubro Rubro = new Rubro();
            Rubro = await _apiService.GetRubroById(id, HttpContext.Session.GetString("APIToken"));
            return View(Rubro);
        }


        [Authorize(Roles = "Admin,Student")]
        [ResponseCache(Duration = 30)]
        public async Task<IActionResult> Delete(int id)
        {

            Rubro Rubro = new Rubro();
            Rubro = await _apiService.GetRubroById(id, HttpContext.Session.GetString("APIToken"));
            return View(Rubro);
        }

        [Authorize(Roles = "Admin,Student")]
        [ResponseCache(Duration = 30)]

        public async Task<JsonResult> DeleteRubro([FromBody] Rubro Rubro)
        {
            bool resultado = false;
            string mensaje = string.Empty;
            try
            {
                await _apiService.DeleteRubro(Rubro.Id, HttpContext.Session.GetString("APIToken"));
                resultado = true;
                mensaje = "Rubro eliminado correctamente";
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
