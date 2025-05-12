using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisController : ControllerBase
    {
        private BibliotecaContext _db;
        private readonly ILogger<PaisController> _logger;

        public PaisController(BibliotecaContext db, ILogger<PaisController> logger)
        {
            _db = db;
            _logger = logger;
        }

        [HttpGet]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public IActionResult GetPais(/*int pagesize, int pagenumber*/)
        {
            _logger.LogInformation("Fetching Todas las Paiss");
            var PaisList = _db.Pais.ToList();
            return Ok(PaisList);

        }

        [HttpGet("GetPaisById")]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public ActionResult<Pais> GetPaisById(int id)
        {

            if (id == 0)
            {
                _logger.LogError("Id de Pais no pasada");
                return BadRequest();
            }
            var Pais = _db.Pais.FirstOrDefault(x => x.Id == id);

            if (Pais == null)
            {
                return NotFound();
            }
            return Pais;
        }


        [HttpPost("AddPais")]
        [Authorize]
        public ActionResult<Pais> AddPais([FromBody] Pais pais)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Pais.Add(pais);
            _db.SaveChanges();
            return Ok(pais);

        }

        [HttpPost("UpdatePais")]
        [Authorize]
        public ActionResult<Pais> UpdatePais(Int32 Id, [FromBody] Pais pais)
        {
            if (pais == null)
            {
                return BadRequest(pais);
            }

            var Pais = _db.Pais.FirstOrDefault(x => x.Id == Id);
            if (Pais == null)
            {
                return NotFound();
            }

            Pais.Descripcion = pais.Descripcion;
            _db.SaveChanges();
            return Ok(Pais);

        }

        [HttpPut("DeletePais")]
        [Authorize(Roles = "Admin")]
        public ActionResult<Pais> DeletePais(Int32 Id)
        {
            var Pais = _db.Pais.FirstOrDefault(x => x.Id == Id);
            if (Pais == null)
            {
                return NotFound();
            }
            _db.Remove(Pais);
            _db.SaveChanges();
            return NoContent();
        }
    }
}
