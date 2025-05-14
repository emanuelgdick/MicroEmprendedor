using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CobradorController : ControllerBase
    {
        private BibliotecaContext _db;
        private readonly ILogger<CobradorController> _logger;

        public CobradorController(BibliotecaContext db, ILogger<CobradorController> logger)
        {
            _db = db;
            _logger = logger;
        }

        [HttpGet]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public IActionResult GetCobradores(/*int pagesize, int pagenumber*/)
        {
            _logger.LogInformation("Fetching Todas las Cobradores");
            var CobradorList = _db.Cobrador.ToList();
            return Ok(CobradorList);
        }

        [HttpGet("GetCobradorById")]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public ActionResult<Cobrador> GetCobradorById(int id)
        {
            if (id == 0)
            {
                _logger.LogError("Id de Cobrador no pasada");
                return BadRequest();
            }
            var Cobrador = _db.Cobrador.FirstOrDefault(x => x.Id == id);

            if (Cobrador == null)
            {
                return NotFound();
            }
            return Cobrador;
        }

        [HttpPost("AddCobrador")]
        [Authorize]
        public ActionResult<Cobrador> AddCobrador([FromBody] Cobrador Cobrador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Cobrador.Add(Cobrador);
            _db.SaveChanges();
            return Ok(Cobrador);

        }

        [HttpPost("UpdateCobrador")]
        [Authorize]
        public ActionResult<Cobrador> UpdateCobrador(Int32 Id, [FromBody] Cobrador cobrador)
        {
            if (cobrador == null)
            {
                return BadRequest(cobrador);
            }

            var Cobr = _db.Cobrador.FirstOrDefault(x => x.Id == Id);
            if (Cobr == null)
            {
                return NotFound();
            }

            Cobr.ApeyNom = cobrador.ApeyNom;
            _db.SaveChanges();
            return Ok(Cobr);

        }

        [HttpPut("DeleteCobrador")]
        [Authorize(Roles = "Admin")]
        public ActionResult<Cobrador> DeleteCobrador(Int32 Id)
        {
            var Cobrador = _db.Cobrador.FirstOrDefault(x => x.Id == Id);
            if (Cobrador == null)
            {
                return NotFound();
            }
            _db.Remove(Cobrador);
            _db.SaveChanges();
            return NoContent();
        }
    }
}
