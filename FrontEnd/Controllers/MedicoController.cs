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
    public class MedicoController : Controller
    {
        private readonly ApiService _apiService;
        private readonly IConfiguration _config;

        public MedicoController(IConfiguration config)
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
        public async Task<JsonResult> GetAllMedicos()
        {
            List<Medico> oLista = new List<Medico>();
            oLista = await _apiService.GetAllMedicos(HttpContext.Session.GetString("APIToken"));
            return Json(new { data = oLista });
        }
        

        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> GetMedicosConAgenda()
        {
            List<Medico> oLista = new List<Medico>();
            oLista = await _apiService.GetMedicosConAgenda(HttpContext.Session.GetString("APIToken"));
            return Json(new { data = oLista });
        }




        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            return View();
        }


        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> CreateMedico([FromBody] Medico Medico)
        {
            object resultado;
            string mensaje = String.Empty;
            try
            {
                if (Medico.Id == 0)
                {
                    if (Medico.ApeyNom != "")
                    {
                        Medico = await _apiService.AddMedico(Medico, HttpContext.Session.GetString("APIToken"));
                        resultado = Medico.Id;
                        mensaje = "Médico ingresado correctamente";
                    }
                    else
                    {
                        resultado = false;
                        mensaje = "Por favor ingrese el Apellido y Nombre";
                    }

                }


                else
                {
                    if (Medico.ApeyNom != "")
                    {
                        await _apiService.UpdateMedico(Medico.Id, Medico, HttpContext.Session.GetString("APIToken"));

                        resultado = true;
                        mensaje = "Médico modificado correctamente";

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

            Medico Medico = new Medico();
            Medico = await _apiService.GetMedicoById(id, HttpContext.Session.GetString("APIToken"));
            return View(Medico);
        }


        [Authorize(Roles = "Admin,Student")]
        public async Task<IActionResult> Delete(int id)
        {

            Medico Medico = new Medico();
            Medico = await _apiService.GetMedicoById(id, HttpContext.Session.GetString("APIToken"));
            return View(Medico);
        }

        [Authorize(Roles = "Admin,Student")]

        public async Task<JsonResult> DeleteMedico([FromBody] Medico Medico)
        {
            bool resultado = false;
            string mensaje = string.Empty;
            try
            {
                await _apiService.DeleteMedico(Medico.Id, HttpContext.Session.GetString("APIToken"));
                resultado = true;
                mensaje = "Médico eliminado correctamente";
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
