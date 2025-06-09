using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesionController : ControllerBase
    {
        private ConsultorioContext _db;
        private readonly ILogger<ProfesionController> _logger;

        public ProfesionController(ConsultorioContext db, ILogger<ProfesionController> logger)
        {
            _db = db;
            _logger = logger;
        }

        [HttpGet]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public IActionResult GetProfesiones(/*int pagesize, int pagenumber*/)
        {
            _logger.LogInformation("Fetching Todas las Profesions");
            var ProfesionList = _db.Profesion.ToList();
            return Ok(ProfesionList);

        }

        [HttpGet("GetProfesionById")]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public ActionResult<Profesion> GetProfesionById(int id)
        {

            if (id == 0)
            {
                _logger.LogError("Id de Profesion no pasada");
                return BadRequest();
            }
            var Profesion = _db.Profesion.FirstOrDefault(x => x.Id == id);

            if (Profesion == null)
            {
                return NotFound();
            }
            return Profesion;
        }


        [HttpPost("AddProfesion")]
        [Authorize]
        public ActionResult<Profesion> AddProfesion([FromBody] Profesion profesion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Profesion.Add(profesion);
            _db.SaveChanges();
            return Ok(profesion);

        }

        [HttpPost("UpdateProfesion")]
        [Authorize]
        public ActionResult<Profesion> UpdateProfesion(Int32 Id, [FromBody] Profesion profesion)
        {
            if (profesion == null)
            {
                return BadRequest(profesion);
            }

            var Profesion = _db.Profesion.FirstOrDefault(x => x.Id == Id);
            if (Profesion == null)
            {
                return NotFound();
            }

            Profesion.Descripcion = profesion.Descripcion;
            _db.SaveChanges();
            return Ok(Profesion);

        }

        [HttpPut("DeleteProfesion")]
        [Authorize(Roles = "Admin")]
        public ActionResult<Profesion> DeleteProfesion(Int32 Id)
        {
            var Profesion = _db.Profesion.FirstOrDefault(x => x.Id == Id);
            if (Profesion == null)
            {
                return NotFound();
            }
            _db.Remove(Profesion);
            _db.SaveChanges();
            return NoContent();
        }
    }
}
