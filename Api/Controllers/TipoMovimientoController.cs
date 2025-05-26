using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoMovimientoController : ControllerBase
    {
        private BibliotecaContext _db;
        private readonly ILogger<TipoMovimientoController> _logger;

        public TipoMovimientoController(BibliotecaContext db, ILogger<TipoMovimientoController> logger)
        {
            _db = db;
            _logger = logger;
        }

        [HttpGet]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public IActionResult GetTipoMovimientos(/*int pagesize, int pagenumber*/)
        {
            _logger.LogInformation("Fetching Todas las TipoMovimientos");
            var TipoMovimientoList = _db.TipoMovimiento.ToList();
            return Ok(TipoMovimientoList);

        }

        [HttpGet("GetTipoMovimientoById")]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public ActionResult<TipoMovimiento> GetTipoMovimientoById(int id)
        {

            if (id == 0)
            {
                _logger.LogError("Id de TipoMovimiento no pasada");
                return BadRequest();
            }
            var TipoMovimiento = _db.TipoMovimiento.FirstOrDefault(x => x.Id == id);

            if (TipoMovimiento == null)
            {
                return NotFound();
            }
            return TipoMovimiento;
        }


        [HttpPost("AddTipoMovimiento")]
        [Authorize]
        public ActionResult<TipoMovimiento> AddTipoMovimiento([FromBody] TipoMovimiento tipoMovimiento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.TipoMovimiento.Add(tipoMovimiento);
            _db.SaveChanges();
            return Ok(tipoMovimiento);

        }

        [HttpPost("UpdateTipoMovimiento")]
        [Authorize]
        public ActionResult<TipoMovimiento> UpdateTipoMovimiento(Int32 Id, [FromBody] TipoMovimiento tipoMovimiento)
        {
            if (tipoMovimiento == null)
            {
                return BadRequest(tipoMovimiento);
            }

            var TipoMovimiento = _db.TipoMovimiento.FirstOrDefault(x => x.Id == Id);
            if (TipoMovimiento == null)
            {
                return NotFound();
            }

            TipoMovimiento.Descripcion = tipoMovimiento.Descripcion;
            TipoMovimiento.CantDias = tipoMovimiento.CantDias;
            TipoMovimiento.NroMov = tipoMovimiento.NroMov;
            _db.SaveChanges();
            return Ok(TipoMovimiento);

        }

        [HttpPut("DeleteTipoMovimiento")]
        [Authorize(Roles = "Admin")]
        public ActionResult<TipoMovimiento> DeleteTipoMovimiento(Int32 Id)
        {
            var TipoMovimiento = _db.TipoMovimiento.FirstOrDefault(x => x.Id == Id);
            if (TipoMovimiento == null)
            {
                return NotFound();
            }
            _db.Remove(TipoMovimiento);
            _db.SaveChanges();
            return NoContent();
        }
    }
}
