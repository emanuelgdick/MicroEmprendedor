using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private BibliotecaContext _db;
        private readonly ILogger<AutorController> _logger;

        public AutorController(BibliotecaContext db, ILogger<AutorController> logger)
        {
            _db = db;
            _logger = logger;
        }

        [HttpGet]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public IActionResult GetAutores(/*int pagesize, int pagenumber*/)
        {
            _logger.LogInformation("Fetching Todas las Autores");
            var AutorList = _db.Autor.ToList();
            return Ok(AutorList);

        }

        [HttpGet("GetAutorById")]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public ActionResult<Autor> GetAutorById(int id)
        {

            if (id == 0)
            {
                _logger.LogError("Id de Autor no pasada");
                return BadRequest();
            }
            var Autor = _db.Autor.FirstOrDefault(x => x.Id == id);

            if (Autor == null)
            {
                return NotFound();
            }
            return Autor;
        }


        //[HttpGet("GetLastAutor")]
        //[Authorize]
        //[ResponseCache(CacheProfileName = "apicache")]
        //public ActionResult<Autor> GetLastAutor()
        //{
        //    var Autor = _db.Autor.LastOrDefault();

        //    if (Autor == null)
        //    {
        //        return NotFound();
        //    }
        //    return Autor;
        //}



        [HttpPost("AddAutor")]
        [Authorize]
        public ActionResult<Autor> AddAutor([FromBody] Autor autor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Autor.Add(autor);
            _db.SaveChanges();
            return Ok(autor);

        }

        [HttpPost("UpdateAutor")]
        [Authorize]
        public ActionResult<Autor> UpdateAutor(Int32 Id, [FromBody] Autor autor)
        {
            if (autor == null)
            {
                return BadRequest(autor);
            }

            var Autor = _db.Autor.FirstOrDefault(x => x.Id == Id);
            if (Autor == null)
            {
                return NotFound();
            }

            Autor.Descripcion = autor.Descripcion;
            _db.SaveChanges();
            return Ok(Autor);

        }

        [HttpPut("DeleteAutor")]
        [Authorize(Roles = "Admin")]
        public ActionResult<Autor> DeleteAutor(Int32 Id)
        {
            var Autor = _db.Autor.FirstOrDefault(x => x.Id == Id);
            if (Autor == null)
            {
                return NotFound();
            }
            _db.Remove(Autor);
            _db.SaveChanges();
            return NoContent();
        }
    }
}
