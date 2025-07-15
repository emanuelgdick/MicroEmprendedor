using Api.Models;
using Api.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private MicroEmprendedorContext _db;
        private readonly ILogger<HomeController> _logger;

        public HomeController(MicroEmprendedorContext db, ILogger<HomeController> logger)
        {
            _db = db;
            _logger = logger;
        }

        [HttpGet]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public IActionResult GetTotales(int id)
        {
        
            TotalesDTO totales=new TotalesDTO();
            //totales.TotalPacientes = _db.Paciente.Count();
            //totales.TotalMutuales = _db.Mutual.Count();
            //totales.TotalMedicos = _db.Medico.Count();
            //totales.TotalConsultas = _db.Consulta.Count();
            //totales.TotalRubros = _db.Rubro.Count();
            totales.Usuario = _db.Usuario.Where(s => s.Id ==id).FirstOrDefault();
            totales.TotalUsuarios = _db.Usuario.Count();
            return Ok(totales);

        }

    }
}
