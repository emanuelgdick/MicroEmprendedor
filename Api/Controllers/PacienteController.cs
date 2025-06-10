using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private ConsultorioContext _db;
        private readonly ILogger<PacienteController> _logger;

        public PacienteController(ConsultorioContext db, ILogger<PacienteController> logger)
        {
            _db = db;
            _logger = logger;
        }

        [HttpGet]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public IActionResult GetPacientes(/*int pagesize, int pagenumber*/)
        {
            _logger.LogInformation("Fetching Todas las Paciente");
            var PacienteList = (from pac in _db.Paciente
                                 join prof in _db.Profesion on pac.IdProfesion equals prof.Id 
                                select new
                                {
                                    pac.Id,
                                    pac.ApeyNom,
                                    pac.NroDocumento,
                                    pac.Fnac,
                                    pac.Calle,
                                    pac.Nro,
                                    pac.Depto,
                                    pac.Piso,
                                    pac.TelCelular,
                                    pac.TelFijo,
                                    pac.Email,
                                    pac.Sexo,
                                    pac.Observaciones,
                                    prof.Descripcion
                                    
                                }).ToList();
                
                //_db.Paciente//.Where(s => s.Id <= 500) 
                //                            .Include(y => y.Localidad)
                //                            .Include(y => y.TipoDocumento)
                //                            .Include(y => y.Profesion!);
                //                           //  .OrderBy(s => s.ApeyNom).ToList();

            return Ok(PacienteList);

        }

        [HttpGet("GetPacientesFiltrados")]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public IActionResult GetPacientesFiltrados(int localidad)
        {
            _logger.LogInformation("Fetching Todas las Pacientes Filtrados");
            var PacienteList = _db.Paciente//.Where(s=> s.Localidad.Id==localidad)
                                           //.Include(y => y.Localidad)
                                           //.Include(y => y.TipoDocumento)
                                           //.Include(y => y.Profesion!)
                .OrderBy(s => s.ApeyNom).ToList();

            return Ok(PacienteList);

        }



        [HttpGet("GetPacienteById")]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public ActionResult<Paciente> GetPacienteById(int id)
        {

            if (id == 0)
            {
                _logger.LogError("Id de Paciente no pasada");
                return BadRequest();
            }
            var Paciente = _db.Paciente.FirstOrDefault(x => x.Id == id);

            if (Paciente == null)
            {
                return NotFound();
            }
            return Paciente;
        }

        [HttpPost("AddPaciente")]
        [Authorize]
        public ActionResult<Paciente> AddPaciente([FromBody] Paciente Paciente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _db.Paciente.Add(Paciente);
            _db.SaveChanges();
            return Ok(Paciente);

        }

        [HttpPost("UpdatePaciente")]
        [Authorize]
        public ActionResult<Paciente> UpdatePaciente(Int32 id, [FromBody] Paciente paciente)
        {
            if (paciente == null)
            {
                return BadRequest(paciente);
            }

            var Paciente = _db.Paciente.FirstOrDefault(x => x.Id == id);
            if (Paciente == null)
            {
                return NotFound();
            }

            Paciente.IdTipoDocumento= paciente.IdTipoDocumento;
            Paciente.NroDocumento = paciente.NroDocumento;
            Paciente.ApeyNom = paciente.ApeyNom;
            Paciente.Fnac = paciente.Fnac;
            Paciente.IdProfesion = paciente.IdProfesion;
            Paciente.Sexo = paciente.Sexo;

           // Paciente.IdLocalidad = paciente.IdLocalidad;
            Paciente.Calle = paciente.Calle;
            Paciente.Nro = paciente.Nro;
            Paciente.Piso = paciente.Piso;
            Paciente.Depto = paciente.Depto;
            Paciente.TelFijo = paciente.TelFijo;
            Paciente.TelCelular = paciente.TelCelular;
            Paciente.Email = paciente.Email;
            
            Paciente.NroHC = paciente.NroHC;
            Paciente.Observaciones = paciente.Observaciones;


            _db.SaveChanges();
            return Ok(Paciente);

        }

        [HttpPut("DeletePaciente")]
        [Authorize(Roles = "Admin")]
        public ActionResult<Paciente> DeletePaciente(Int32 Id)
        {
            var Paciente = _db.Paciente.FirstOrDefault(x => x.Id == Id);
            if (Paciente == null)
            {
                return NotFound();
            }
            _db.Remove(Paciente);
            _db.SaveChanges();
            return NoContent();
        }
    }
}
