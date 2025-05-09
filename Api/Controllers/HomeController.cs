using Api.Models;
using FrontEnd.Models;
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
            totales.TotalUsuarios = _db.Usuario.Count();
            totales.TotalSocios = _db.Socio.Count();
            return Ok(totales);

        }

    }
}
