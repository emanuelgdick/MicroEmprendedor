using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialMovimientoController : ControllerBase
    {
        private BibliotecaContext _db;
        private readonly ILogger<MaterialMovimientoController> _logger;

        public MaterialMovimientoController(BibliotecaContext db, ILogger<MaterialMovimientoController> logger)
        {
            _db = db;
            _logger = logger;
        }

        [HttpGet]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public IActionResult GetMaterialMovimientos(/*int pagesize, int pagenumber*/)
        {
            _logger.LogInformation("Fetching Todas las MaterialMovimiento");
            var MaterialMovimientoList = _db.MaterialMovimiento.ToList();
            return Ok(MaterialMovimientoList);

        }

        [HttpGet("GetMaterialMovimientoById")]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public ActionResult<MaterialMovimiento> GetMaterialMovimientoById(int id)
        {

            if (id == 0)
            {
                _logger.LogError("Id de MaterialMovimiento no pasada");
                return BadRequest();
            }
            var MaterialMovimiento = _db.MaterialMovimiento.FirstOrDefault(x => x.Id == id);

            if (MaterialMovimiento == null)
            {
                return NotFound();
            }
            return MaterialMovimiento;
        }


        [HttpGet("GetMaterialMovimientoBySocio")]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public ActionResult<List<MaterialMovimiento>> GetMaterialMovimientoBySocio(int socio)
        {

            if (socio == 0)
            {
                _logger.LogError("Id de MaterialMovimiento no pasada");
                return BadRequest();
            }
            
            var MaterialMovimiento = _db.MaterialMovimiento.Where(x => x.Socio.NroSocio == socio)
                .Include(y=>y.TipoMovimiento)
                .Include(q=>q.Material)
                .Include(r=>r.Socio)
                .OrderBy(s=>s.Fecha).ToList();

            if (MaterialMovimiento == null)
            {
                return NotFound();
            }
            return MaterialMovimiento;
        }

        [HttpPost("AddMaterialMovimiento")]
        [Authorize]
        public ActionResult<MaterialMovimiento> AddMaterialMovimiento([FromBody] MaterialMovimiento materialMovimiento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.MaterialMovimiento.Add(materialMovimiento);
            _db.SaveChanges();
            return Ok(materialMovimiento);

        }

        [HttpPost("UpdateMaterialMovimiento")]
        [Authorize]
        public ActionResult<MaterialMovimiento> UpdateMaterialMovimiento(Int32 Id, [FromBody] MaterialMovimiento materialMovimiento)
        {
            if (materialMovimiento == null)
            {
                return BadRequest(materialMovimiento);
            }

            var MaterialMovimiento = _db.MaterialMovimiento.FirstOrDefault(x => x.Id == Id);
            if (MaterialMovimiento == null)
            {
                return NotFound();
            }

            MaterialMovimiento.Fecha = MaterialMovimiento.Fecha;
            _db.SaveChanges();
            return Ok(MaterialMovimiento);

        }

        [HttpPut("DeleteMaterialMovimiento")]
        [Authorize(Roles = "Admin")]
        public ActionResult<MaterialMovimiento> DeleteMaterialMovimiento(Int32 Id)
        {
            var MaterialMovimiento = _db.MaterialMovimiento.FirstOrDefault(x => x.Id == Id);
            if (MaterialMovimiento == null)
            {
                return NotFound();
            }
            _db.Remove(MaterialMovimiento);
            _db.SaveChanges();
            return NoContent();
        }
    }
}
