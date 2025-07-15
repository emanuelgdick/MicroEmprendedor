using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RubroController : ControllerBase
    {
        private MicroEmprendedorContext _db;
        private readonly ILogger<RubroController> _logger;

        public RubroController(MicroEmprendedorContext db, ILogger<RubroController> logger)
        {
            _db = db;
            _logger = logger;
        }

        [HttpGet]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public IActionResult GetAllRubro(/*int pagesize, int pagenumber*/)
        {
            _logger.LogInformation("Fetching Todos las Rubros");
            var RubroList = _db.Rubro.ToList();
            return Ok(RubroList);

        }

        [HttpGet("GetRubroById")]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public ActionResult<Rubro> GetRubroById(int id)
        {

            if (id == 0)
            {
                _logger.LogError("Id de Rubro no pasada");
                return BadRequest();
            }
            var Rubro = _db.Rubro.FirstOrDefault(x => x.Id == id);

            if (Rubro == null)
            {
                return NotFound();
            }
            return Rubro;
        }


        [HttpPost("AddRubro")]
        [Authorize]
        public ActionResult<Rubro> AddRubro([FromBody] Rubro Rubro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Rubro.Add(Rubro);
            _db.SaveChanges();
            return Ok(Rubro);

        }

        [HttpPost("UpdateRubro")]
        [Authorize]
        public ActionResult<Rubro> UpdateRubro(Int32 Id, [FromBody] Rubro rubro)
        {
            if (rubro == null)
            {
                return BadRequest(rubro);
            }

            var Rubro = _db.Rubro.FirstOrDefault(x => x.Id == Id);
            if (Rubro == null)
            {
                return NotFound();
            }

            Rubro.Descripcion = Rubro.Descripcion;
            _db.SaveChanges();
            return Ok(Rubro);

        }

        [HttpPut("DeleteRubro")]
        [Authorize(Roles = "Admin")]
        public ActionResult<Rubro> DeleteRubro(Int32 Id)
        {
            var Rubro = _db.Rubro.FirstOrDefault(x => x.Id == Id);
            if (Rubro == null)
            {
                return NotFound();
            }
            _db.Remove(Rubro);
            _db.SaveChanges();
            return NoContent();
        }
    }
}
