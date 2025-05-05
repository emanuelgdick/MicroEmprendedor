using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalleController : ControllerBase
    {
        private BibliotecaContext _db;
        private readonly ILogger<CalleController> _logger;

        public CalleController(BibliotecaContext db, ILogger<CalleController> logger)
        {
            _db = db;
            _logger = logger;
        }

        [HttpGet]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public IActionResult GetCalles(/*int pagesize, int pagenumber*/)
        {
            _logger.LogInformation("Fetching Todas las Calles");
            var calleList = _db.Calle.ToList();
            return Ok(calleList);
            
        }

        [HttpGet("GetCalleById")]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public ActionResult<Calle> GetCalleById(int id)
        {

            if (id == 0)
            {
                _logger.LogError("Id de Calle no pasada");
                return BadRequest();
            }
            var calle = _db.Calle.FirstOrDefault(x => x.Id == id);

            if (calle == null)
            {
                return NotFound();
            }
            return calle;
        }


        //[HttpGet("GetLastCalle")]
        //[Authorize]
        //[ResponseCache(CacheProfileName = "apicache")]
        //public ActionResult<Calle> GetLastCalle()
        //{
        //    var calle = _db.Calle.LastOrDefault();

        //    if (calle == null)
        //    {
        //        return NotFound();
        //    }
        //    return calle;
        //}



        [HttpPost("AddCalle")]
        [Authorize]
        public ActionResult<Calle> AddCalle([FromBody] Calle calle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Calle.Add(calle);
            _db.SaveChanges();
            return Ok(calle);

        }

        [HttpPost("UpdateCalle")]
        [Authorize]
        public ActionResult<Calle> UpdateCalle(Int32 Id, [FromBody] Calle calle)
        {
            if (calle == null)
            {
                return BadRequest(calle);
            }

            var Calle = _db.Calle.FirstOrDefault(x => x.Id == Id);
            if (Calle == null)
            {
                return NotFound();
            }

            Calle.Descripcion = calle.Descripcion;
            _db.SaveChanges();
            return Ok(calle);

        }

        [HttpPut("DeleteCalle")]
        [Authorize(Roles = "Admin")]
        public ActionResult<Calle> DeleteCalle(Int32 Id)
        {
            var Calle = _db.Calle.FirstOrDefault(x => x.Id == Id);
            if (Calle == null)
            {
                return NotFound();
            }
            _db.Remove(Calle);
            _db.SaveChanges();
            return NoContent();
        }
    }
}
