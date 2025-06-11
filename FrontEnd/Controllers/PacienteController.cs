
using Frontend.Models;
using FrontEnd.Models;
using FrontEnd.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft;


namespace FrontEnd.Controllers
{
    public class PacienteController : Controller
    {
        private readonly ApiService _apiService;
        private readonly IConfiguration _config;


        public PacienteController(IConfiguration config)
        {
            _apiService = new ApiService();
            _config = config;
            
        }

        [Authorize(Roles = "Admin")]
        [ResponseCache(Duration = 30)]
        public async Task<IActionResult> Index()
        {
            int pagesize = _config.GetValue<int>("PageSettings:PageSize");
            List<Paciente> lstPaciente = new List<Paciente>();
            lstPaciente = await _apiService.GetAllPacientes(HttpContext.Session.GetString("APIToken"));
            return View();

        }


        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> GetAllPacientes()
        {
            List<Paciente> oLista = new List<Paciente>();
            oLista = await _apiService.GetAllPacientes(HttpContext.Session.GetString("APIToken"));
            return Json(new { data = oLista });
        }
        
        
        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> GetPacientesFiltrados(int localidad)
        {
            List<Paciente> oLista = new List<Paciente>();
            oLista = await _apiService. GetPacientesFiltrados(localidad,HttpContext.Session.GetString("APIToken"));
            return Json(new { data = oLista });
        }


        

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            return View();
        }



        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> CreatePaciente([FromBody] Paciente paciente)
        {
            object resultado = null;
            string mensaje = String.Empty;
            if (paciente != null) { 
            try
            {
                if (paciente.Id == 0)
                {
                    if (paciente.ApeyNom != "")
                    {
                        paciente = await _apiService.AddPaciente(paciente, HttpContext.Session.GetString("APIToken"));
                        resultado = paciente.Id;
                        mensaje = "Paciente ingresado correctamente";
                    }
                    else
                    {
                        resultado = false;
                        mensaje = "Por favor ingrese el Apellido y Nombre";
                    }
                }
                else
                {
                    if (paciente.ApeyNom != "")
                    {
                        await _apiService.UpdatePaciente(paciente.Id, paciente, HttpContext.Session.GetString("APIToken"));

                        resultado = true;
                        mensaje = "Paciente modificado correctamente";
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
            }
            return Json(new { resultado = resultado, mensaje = mensaje });
        }

        [Authorize(Roles = "Admin,Student")]
        public async Task<IActionResult> Details(int id)
        {
            Paciente Paciente = new Paciente();
            Paciente = await _apiService.GetPacienteById(id, HttpContext.Session.GetString("APIToken"));
            return View(Paciente);
        }


        //[Authorize(Roles = "Admin")]
        //public async Task<IActionResult> UpdatePaciente(int id, Paciente Paciente)
        //{
        //    await _apiService.UpdatePaciente(id, Paciente, HttpContext.Session.GetString("APIToken"));
        //    return RedirectToAction("Index");
        //}

        [Authorize(Roles = "Admin,Student")]
        public async Task<IActionResult> Delete(int id)
        {

            Paciente Paciente = new Paciente();
            Paciente = await _apiService.GetPacienteById(id, HttpContext.Session.GetString("APIToken"));
            return View(Paciente);
        }

        [Authorize(Roles = "Admin,Student")]

        public async Task<JsonResult> DeletePaciente([FromBody] Paciente paciente)
        {
            bool resultado = false;
            string mensaje = string.Empty;
            try
            {
                await _apiService.DeletePaciente(paciente.Id, HttpContext.Session.GetString("APIToken"));
                resultado = true;
                mensaje = "Paciente eliminado correctamente";
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
