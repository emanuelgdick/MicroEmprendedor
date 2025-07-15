using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalidadController : ControllerBase
    {
        private MicroEmprendedorContext _db;
        private readonly ILogger<LocalidadController> _logger;

        public LocalidadController(MicroEmprendedorContext db, ILogger<LocalidadController> logger)
        {
            _db = db;
            _logger = logger;
        }

        [HttpGet]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public IActionResult GetLocalidades(/*int pagesize, int pagenumber*/)
        {
            _logger.LogInformation("Fetching Todas las Localidads");
            var LocalidadList = _db.Localidad.ToList();
            return Ok(LocalidadList);

        }

        [HttpGet("GetLocalidadById")]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public ActionResult<Localidad> GetLocalidadById(int id)
        {

            if (id == 0)
            {
                _logger.LogError("Id de Localidad no pasada");
                return BadRequest();
            }
            var Localidad = _db.Localidad.FirstOrDefault(x => x.Id == id);

            if (Localidad == null)
            {
                return NotFound();
            }
            return Localidad;
        }


        [HttpPost("AddLocalidad")]
        [Authorize]
        public ActionResult<Localidad> AddLocalidad([FromBody] Localidad localidad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Localidad.Add(localidad);
            _db.SaveChanges();
            return Ok(localidad);

        }

        [HttpPost("UpdateLocalidad")]
        [Authorize]
        public ActionResult<Localidad> UpdateLocalidad(Int32 Id, [FromBody] Localidad localidad)
        {
            if (localidad == null)
            {
                return BadRequest(localidad);
            }

            var Localidad = _db.Localidad.FirstOrDefault(x => x.Id == Id);
            if (Localidad == null)
            {
                return NotFound();
            }

            Localidad.Descripcion = localidad.Descripcion;
            _db.SaveChanges();
            return Ok(Localidad);

        }

        [HttpPut("DeleteLocalidad")]
        [Authorize(Roles = "Admin")]
        public ActionResult<Localidad> DeleteLocalidad(Int32 Id)
        {
            var Localidad = _db.Localidad.FirstOrDefault(x => x.Id == Id);
            if (Localidad == null)
            {
                return NotFound();
            }
            _db.Remove(Localidad);
            _db.SaveChanges();
            return NoContent();
        }
    }
}
