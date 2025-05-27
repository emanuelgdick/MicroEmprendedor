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
        private BibliotecaContext _db;
        private readonly ILogger<HomeController> _logger;

        public HomeController(BibliotecaContext db, ILogger<HomeController> logger)
        {
            _db = db;
            _logger = logger;
        }

        [HttpGet]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public IActionResult GetTotales()
        {
         
            TotalesDTO totales=new TotalesDTO();
            totales.TotalCobradores = _db.Cobrador.Count();
            
            totales.TotalSocios = _db.Socio.Count();
            totales.TotalSociosVitalicios = _db.Socio.Where(x => x.Vitalicio == true).Count();
            totales.TotalSociosActivos = _db.Socio.Where(x => x.EstadoSocio.Id == 1).Count();
            totales.TotalSociosSuspendidos = _db.Socio.Where(x => x.EstadoSocio.Id == 2).Count();
            totales.TotalSociosDadosDeBaja = _db.Socio.Where(x => x.EstadoSocio.Id == 3).Count();
            totales.TotalUsuarios = _db.Usuario.Count();
            totales.TotalSocios = _db.Socio.Count();
            return Ok(totales);

        }

    }
}
