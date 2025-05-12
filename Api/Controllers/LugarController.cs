using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LugarController : ControllerBase
    {
        private BibliotecaContext _db;
        private readonly ILogger<LugarController> _logger;

        public LugarController(BibliotecaContext db, ILogger<LugarController> logger)
        {
            _db = db;
            _logger = logger;
        }

        [HttpGet]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public IActionResult GetLugares(/*int pagesize, int pagenumber*/)
        {
            _logger.LogInformation("Fetching Todas las Lugars");
            var LugarList = _db.Lugar.ToList();
            return Ok(LugarList);

        }

        [HttpGet("GetLugarById")]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public ActionResult<Lugar> GetLugarById(int id)
        {

            if (id == 0)
            {
                _logger.LogError("Id de Lugar no pasada");
                return BadRequest();
            }
            var Lugar = _db.Lugar.FirstOrDefault(x => x.Id == id);

            if (Lugar == null)
            {
                return NotFound();
            }
            return Lugar;
        }


        [HttpPost("AddLugar")]
        [Authorize]
        public ActionResult<Lugar> AddLugar([FromBody] Lugar lugar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Lugar.Add(lugar);
            _db.SaveChanges();
            return Ok(lugar);

        }

        [HttpPost("UpdateLugar")]
        [Authorize]
        public ActionResult<Lugar> UpdateLugar(Int32 Id, [FromBody] Lugar lugar)
        {
            if (lugar == null)
            {
                return BadRequest(lugar);
            }

            var Lugar = _db.Lugar.FirstOrDefault(x => x.Id == Id);
            if (Lugar == null)
            {
                return NotFound();
            }

            Lugar.Descripcion = lugar.Descripcion;
            _db.SaveChanges();
            return Ok(Lugar);

        }

        [HttpPut("DeleteLugar")]
        [Authorize(Roles = "Admin")]
        public ActionResult<Lugar> DeleteLugar(Int32 Id)
        {
            var Lugar = _db.Lugar.FirstOrDefault(x => x.Id == Id);
            if (Lugar == null)
            {
                return NotFound();
            }
            _db.Remove(Lugar);
            _db.SaveChanges();
            return NoContent();
        }
    }
}
