using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorController : ControllerBase
    {
        private BibliotecaContext _db;
        private readonly ILogger<DirectorController> _logger;

        public DirectorController(BibliotecaContext db, ILogger<DirectorController> logger)
        {
            _db = db;
            _logger = logger;
        }

        [HttpGet]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public IActionResult GetDirector(/*int pagesize, int pagenumber*/)
        {
            _logger.LogInformation("Fetching Todas las Directors");
            var DirectorList = _db.Director.ToList();
            return Ok(DirectorList);

        }

        [HttpGet("GetDirectorById")]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public ActionResult<Director> GetDirectorById(int id)
        {

            if (id == 0)
            {
                _logger.LogError("Id de Director no pasada");
                return BadRequest();
            }
            var Director = _db.Director.FirstOrDefault(x => x.Id == id);

            if (Director == null)
            {
                return NotFound();
            }
            return Director;
        }

        [HttpPost("AddDirector")]
        [Authorize]
        public ActionResult<Director> AddDirector([FromBody] Director director)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Director.Add(director);
            _db.SaveChanges();
            return Ok(director);

        }

        [HttpPost("UpdateDirector")]
        [Authorize]
        public ActionResult<Director> UpdateDirector(Int32 Id, [FromBody] Director director)
        {
            if (director == null)
            {
                return BadRequest(director);
            }

            var Director = _db.Director.FirstOrDefault(x => x.Id == Id);
            if (Director == null)
            {
                return NotFound();
            }

            Director.ApeyNom = director.ApeyNom;
            _db.SaveChanges();
            return Ok(Director);

        }

        [HttpPut("DeleteDirector")]
        [Authorize(Roles = "Admin")]
        public ActionResult<Director> DeleteDirector(Int32 Id)
        {
            var Director = _db.Director.FirstOrDefault(x => x.Id == Id);
            if (Director == null)
            {
                return NotFound();
            }
            _db.Remove(Director);
            _db.SaveChanges();
            return NoContent();
        }
    }
}
