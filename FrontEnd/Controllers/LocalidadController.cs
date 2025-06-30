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
    public class LocalidadController : Controller
    {
        private readonly ApiService _apiService;
        private readonly IConfiguration _config;

        public LocalidadController(IConfiguration config)
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
        public async Task<JsonResult> GetAllLocalidades()
        {
            List<Localidad> oLista = new List<Localidad>();
            oLista = await _apiService.GetAllLocalidades(HttpContext.Session.GetString("APIToken"));
            return Json(new { data = oLista });
        }


        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            return View();
        }



        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> CreateLocalidad([FromBody] Localidad localidad)
        {
            object resultado;
            string mensaje = String.Empty;
            try
            {
                if (localidad.Id == 0)
                {
                    if (localidad.Descripcion != "")
                    {
                        localidad = await _apiService.AddLocalidad(localidad, HttpContext.Session.GetString("APIToken"));
                        resultado = localidad.Id;
                        mensaje = "Localidad ingresada correctamente";
                    }
                    else
                    {
                        resultado = false;
                        mensaje = "Por favor ingrese la Descripción";
                    }

                }


                else
                {
                    if (localidad.Descripcion != "")
                    {
                        await _apiService.UpdateLocalidad(localidad.Id, localidad, HttpContext.Session.GetString("APIToken"));

                        resultado = true;
                        mensaje = "Localidad modificado correctamente";

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

            Localidad localidad = new Localidad();
            localidad = await _apiService.GetLocalidadById(id, HttpContext.Session.GetString("APIToken"));
            return View(localidad);
        }


        [Authorize(Roles = "Admin,Student")]
        public async Task<IActionResult> Delete(int id)
        {

            Localidad localidad = new Localidad();
            localidad = await _apiService.GetLocalidadById(id, HttpContext.Session.GetString("APIToken"));
            return View(localidad);
        }

        [Authorize(Roles = "Admin,Student")]

        public async Task<JsonResult> DeleteLocalidad([FromBody] Localidad localidad)
        {
            bool resultado = false;
            string mensaje = string.Empty;
            try
            {
                await _apiService.DeleteLocalidad(localidad.Id, HttpContext.Session.GetString("APIToken"));
                resultado = true;
                mensaje = "Localidad eliminada correctamente";
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
