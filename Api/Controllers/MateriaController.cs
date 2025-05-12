using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriaController : ControllerBase
    {
        private BibliotecaContext _db;
        private readonly ILogger<MateriaController> _logger;

        public MateriaController(BibliotecaContext db, ILogger<MateriaController> logger)
        {
            _db = db;
            _logger = logger;
        }

        [HttpGet]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public IActionResult GetMaterias(/*int pagesize, int pagenumber*/)
        {
            _logger.LogInformation("Fetching Todas las Materias");
            var MateriaList = _db.Materia.ToList();
            return Ok(MateriaList);

        }

        [HttpGet("GetMateriaById")]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public ActionResult<Materia> GetMateriaById(int id)
        {

            if (id == 0)
            {
                _logger.LogError("Id de Materia no pasada");
                return BadRequest();
            }
            var Materia = _db.Materia.FirstOrDefault(x => x.Id == id);

            if (Materia == null)
            {
                return NotFound();
            }
            return Materia;
        }


        [HttpPost("AddMateria")]
        [Authorize]
        public ActionResult<Materia> AddMateria([FromBody] Materia materia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Materia.Add(materia);
            _db.SaveChanges();
            return Ok(materia);

        }

        [HttpPost("UpdateMateria")]
        [Authorize]
        public ActionResult<Materia> UpdateMateria(Int32 Id, [FromBody] Materia materia)
        {
            if (materia == null)
            {
                return BadRequest(materia);
            }

            var Materia = _db.Materia.FirstOrDefault(x => x.Id == Id);
            if (Materia == null)
            {
                return NotFound();
            }

            Materia.Descripcion = Materia.Descripcion;
            _db.SaveChanges();
            return Ok(Materia);

        }

        [HttpPut("DeleteMateria")]
        [Authorize(Roles = "Admin")]
        public ActionResult<Materia> DeleteMateria(Int32 Id)
        {
            var Materia = _db.Materia.FirstOrDefault(x => x.Id == Id);
            if (Materia == null)
            {
                return NotFound();
            }
            _db.Remove(Materia);
            _db.SaveChanges();
            return NoContent();
        }
    }
}
