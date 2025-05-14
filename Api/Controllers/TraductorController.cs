using Api.Models;
using FrontEnd.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TraductorController : ControllerBase
    {
        private BibliotecaContext _db;
        private readonly ILogger<TraductorController> _logger;

        public TraductorController(BibliotecaContext db, ILogger<TraductorController> logger)
        {
            _db = db;
            _logger = logger;
        }

        [HttpGet]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public IActionResult GetTraductores(/*int pagesize, int pagenumber*/)
        {
            _logger.LogInformation("Fetching Todas las Traductors");
            var TraductorList = _db.Traductor.ToList();
            return Ok(TraductorList);

        }

        [HttpGet("GetTraductorById")]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public ActionResult<Traductor> GetTraductorById(int id)
        {
            if (id == 0)
            {
                _logger.LogError("Id de Traductor no pasada");
                return BadRequest();
            }
            var Traductor = _db.Traductor.FirstOrDefault(x => x.Id == id);

            if (Traductor == null)
            {
                return NotFound();
            }
            return Traductor;
        }


        [HttpPost("AddTraductor")]
        [Authorize]
        public ActionResult<Traductor> AddTraductor([FromBody] Traductor Traductor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _db.Traductor.Add(Traductor);
            _db.SaveChanges();
            return Ok(Traductor);
        }

        [HttpPost("UpdateTraductor")]
        [Authorize]
        public ActionResult<Traductor> UpdateTraductor(Int32 Id, [FromBody] Traductor traductor)
        {
            if (traductor == null)
            {
                return BadRequest(traductor);
            }

            var Traductor = _db.Traductor.FirstOrDefault(x => x.Id == Id);
            if (Traductor == null)
            {
                return NotFound();
            }

            Traductor.ApeyNom = Traductor.ApeyNom;
            _db.SaveChanges();
            return Ok(Traductor);

        }

        [HttpPut("DeleteTraductor")]
        [Authorize(Roles = "Admin")]
        public ActionResult<Traductor> DeleteTraductor(Int32 Id)
        {
            var Traductor = _db.Traductor.FirstOrDefault(x => x.Id == Id);
            if (Traductor == null)
            {
                return NotFound();
            }
            _db.Remove(Traductor);
            _db.SaveChanges();
            return NoContent();
        }
    }
}
