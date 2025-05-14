using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaSocioController : ControllerBase
    {
        private BibliotecaContext _db;
        private readonly ILogger<CategoriaSocioController> _logger;

        public CategoriaSocioController(BibliotecaContext db, ILogger<CategoriaSocioController> logger)
        {
            _db = db;
            _logger = logger;
        }

        [HttpGet]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public IActionResult GetCategoriaSocios(/*int pagesize, int pagenumber*/)
        {
            _logger.LogInformation("Fetching Todas las CategoriaSocios");
            var CategoriaSocioList = _db.CategoriaSocio.ToList();
            return Ok(CategoriaSocioList);
        }

        [HttpGet("GetCategoriaSocioById")]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public ActionResult<CategoriaSocio> GetCategoriaSocioById(int id)
        {
            if (id == 0)
            {
                _logger.LogError("Id de CategoriaSocio no pasada");
                return BadRequest();
            }
            var CategoriaSocio = _db.CategoriaSocio.FirstOrDefault(x => x.Id == id);

            if (CategoriaSocio == null)
            {
                return NotFound();
            }
            return CategoriaSocio;
        }

        [HttpPost("AddCategoriaSocio")]
        [Authorize]
        public ActionResult<CategoriaSocio> AddCategoriaSocio([FromBody] CategoriaSocio categoriaSocio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.CategoriaSocio.Add(categoriaSocio);
            _db.SaveChanges();
            return Ok(categoriaSocio);
        }

        [HttpPost("UpdateCategoriaSocio")]
        [Authorize]
        public ActionResult<CategoriaSocio> UpdateCategoriaSocio(Int32 Id, [FromBody] CategoriaSocio categoriaSocio)
        {
            if (categoriaSocio == null)
            {
                return BadRequest(categoriaSocio);
            }

            var CategoriaSocio = _db.CategoriaSocio.FirstOrDefault(x => x.Id == Id);
            if (CategoriaSocio == null)
            {
                return NotFound();
            }

            CategoriaSocio.Descripcion = categoriaSocio.Descripcion;
            _db.SaveChanges();
            return Ok(CategoriaSocio);
        }

        [HttpPut("DeleteCategoriaSocio")]
        [Authorize(Roles = "Admin")]
        public ActionResult<CategoriaSocio> DeleteCategoriaSocio(Int32 Id)
        {
            var CategoriaSocio = _db.CategoriaSocio.FirstOrDefault(x => x.Id == Id);
            if (CategoriaSocio == null)
            {
                return NotFound();
            }
            _db.Remove(CategoriaSocio);
            _db.SaveChanges();
            return NoContent();
        }
    }
}
