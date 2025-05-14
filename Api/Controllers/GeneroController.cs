using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneroController : ControllerBase
    {
        private BibliotecaContext _db;
        private readonly ILogger<GeneroController> _logger;

        public GeneroController(BibliotecaContext db, ILogger<GeneroController> logger)
        {
            _db = db;
            _logger = logger;
        }

        [HttpGet]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public IActionResult GetGeneros(/*int pagesize, int pagenumber*/)
        {
            _logger.LogInformation("Fetching Todas las Generos");
            var GeneroList = _db.Genero.ToList();
            return Ok(GeneroList);
        }

        [HttpGet("GetGeneroById")]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public ActionResult<Genero> GetGeneroById(int id)
        {
            if (id == 0)
            {
                _logger.LogError("Id de Genero no pasada");
                return BadRequest();
            }
            var Genero = _db.Genero.FirstOrDefault(x => x.Id == id);

            if (Genero == null)
            {
                return NotFound();
            }
            return Genero;
        }


        [HttpPost("AddGenero")]
        [Authorize]
        public ActionResult<Genero> AddGenero([FromBody] Genero genero)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _db.Genero.Add(genero);
            _db.SaveChanges();
            return Ok(genero);
        }

        [HttpPost("UpdateGenero")]
        [Authorize]
        public ActionResult<Genero> UpdateGenero(Int32 Id, [FromBody] Genero genero)
        {
            if (genero == null)
            {
                return BadRequest(genero);
            }

            var Genero = _db.Genero.FirstOrDefault(x => x.Id == Id);
            if (Genero == null)
            {
                return NotFound();
            }

            Genero.Descripcion = genero.Descripcion;
            _db.SaveChanges();
            return Ok(Genero);

        }

        [HttpPut("DeleteGenero")]
        [Authorize(Roles = "Admin")]
        public ActionResult<Genero> DeleteGenero(Int32 Id)
        {
            var Genero = _db.Genero.FirstOrDefault(x => x.Id == Id);
            if (Genero == null)
            {
                return NotFound();
            }
            _db.Remove(Genero);
            _db.SaveChanges();
            return NoContent();
        }
    }
}
