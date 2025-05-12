using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinciaController : ControllerBase
    {
        private BibliotecaContext _db;
        private readonly ILogger<ProvinciaController> _logger;

        public ProvinciaController(BibliotecaContext db, ILogger<ProvinciaController> logger)
        {
            _db = db;
            _logger = logger;
        }

        [HttpGet]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public IActionResult GetProvincias(/*int pagesize, int pagenumber*/)
        {
            _logger.LogInformation("Fetching Todas las Provincias");
            var ProvinciaList = _db.Provincia.ToList();
            return Ok(ProvinciaList);

        }

        [HttpGet("GetProvinciaById")]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public ActionResult<Provincia> GetProvinciaById(int id)
        {

            if (id == 0)
            {
                _logger.LogError("Id de Provincia no pasada");
                return BadRequest();
            }
            var Provincia = _db.Provincia.FirstOrDefault(x => x.Id == id);

            if (Provincia == null)
            {
                return NotFound();
            }
            return Provincia;
        }


        [HttpPost("AddProvincia")]
        [Authorize]
        public ActionResult<Provincia> AddProvincia([FromBody] Provincia provincia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Provincia.Add(provincia);
            _db.SaveChanges();
            return Ok(provincia);

        }

        [HttpPost("UpdateProvincia")]
        [Authorize]
        public ActionResult<Provincia> UpdateProvincia(Int32 Id, [FromBody] Provincia provincia)
        {
            if (provincia == null)
            {
                return BadRequest(provincia);
            }

            var Provincia = _db.Provincia.FirstOrDefault(x => x.Id == Id);
            if (Provincia == null)
            {
                return NotFound();
            }

            Provincia.Descripcion = provincia.Descripcion;
            _db.SaveChanges();
            return Ok(Provincia);

        }

        [HttpPut("DeleteProvincia")]
        [Authorize(Roles = "Admin")]
        public ActionResult<Provincia> DeleteProvincia(Int32 Id)
        {
            var Provincia = _db.Provincia.FirstOrDefault(x => x.Id == Id);
            if (Provincia == null)
            {
                return NotFound();
            }
            _db.Remove(Provincia);
            _db.SaveChanges();
            return NoContent();
        }
    }
}
