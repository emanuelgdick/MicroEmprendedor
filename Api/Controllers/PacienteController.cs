
using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

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

            // Obtener datos de las tablas
            var paciente = _db.Paciente.ToList();
            var profesion = _db.Profesion.ToList();
            //var medico = _db.Medico.ToList();

            // Realizar la unión utilizando Join
            var resultado = from pac in paciente
                             join prof in profesion on pac.IdProfesion equals prof.Id   into profesionPaciente
                            from pp in profesionPaciente.DefaultIfEmpty()
                            select new
                             {
                                 Id = pac.Id,
                                 IdTipoDocumento = pac.IdTipoDocumento,
                                 IdLocalidad = pac?.IdLocalidad == null ? 0 : pac?.IdLocalidad,
                                 IdProfesion = pac?.IdProfesion == null ? 0 : pac?.IdProfesion,
                                 IdMedico = pac?.IdMedico == null ? 0 : pac?.IdMedico,
                                 ApeyNom = pac.ApeyNom,
                                 NroDocumento = pac.NroDocumento,
                                 Fnac = pac.Fnac,
                                 Calle = pac.Calle,
                                 Nro = pac.Nro,
                                 Depto = pac.Depto,
                                 Piso = pac.Piso,
                                 TelCelular = pac.TelCelular,
                                 TelFijo = pac.TelFijo,
                                 Email = pac.Email,
                                 Sexo = pac.Sexo,
                                 Observaciones = pac.Observaciones,
                                 Profesion =  new
                                 {
                                      Id = pp?.Id == null ? 0 : pp.Id,
                                      Descripcion = pp?.Descripcion == null ? "" : pp.Descripcion
                                 },
                                Historia = pac.Historia,
                                NroHC = pac.NroHC
                            };
            return Ok(resultado);

        }

        [HttpGet("GetPacientesFiltrados")]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public IActionResult GetPacientesFiltrados(int localidad)
        {
            _logger.LogInformation("Fetching Todas las Pacientes Filtrados");
            // Obtener datos de las tablas
            var paciente = _db.Paciente.ToList();
            var profesion = _db.Profesion.ToList();

            // Realizar la unión utilizando Join
            var resultado = from pac in paciente
                            join prof in profesion on pac.IdProfesion equals prof.Id into profesionPaciente
                            from pp in profesionPaciente.DefaultIfEmpty()
                            where pac.IdLocalidad == localidad
                            select new
                            {
                                Id = pac.Id,
                                IdTipoDocumento = pac.IdTipoDocumento,
                                IdLocalidad = pac?.IdLocalidad == null ? 0 : pac?.IdLocalidad,
                                IdProfesion = pac?.IdProfesion == null ? 0 : pac?.IdProfesion,
                                IdMedico = pac?.IdMedico == null ? 0 : pac?.IdMedico,
                                ApeyNom = pac.ApeyNom,
                                NroDocumento = pac.NroDocumento,
                                Fnac = pac.Fnac,
                                Calle = pac.Calle,
                                Nro = pac.Nro,
                                Depto = pac.Depto,
                                Piso = pac.Piso,
                                TelCelular = pac.TelCelular,
                                TelFijo = pac.TelFijo,
                                Email = pac.Email,
                                Sexo = pac.Sexo,
                                Observaciones = pac.Observaciones,
                                Profesion = new
                                {
                                    Id = pp?.Id == null ? 0 : pp.Id,
                                    Descripcion = pp?.Descripcion == null ? "" : pp.Descripcion
                                },
                                Historia = pac.Historia,
                                NroHC = pac.NroHC
                            };
            return Ok(resultado);

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

            Paciente.IdTipoDocumento =  paciente.IdTipoDocumento == 0 ? null : paciente.IdTipoDocumento;
            Paciente.NroDocumento = paciente.NroDocumento;
            Paciente.ApeyNom = paciente.ApeyNom;
            Paciente.Fnac = paciente.Fnac;
            Paciente.IdProfesion = paciente.IdProfesion == 0 ? null : paciente.IdProfesion;
            Paciente.IdMedico = paciente.IdMedico == 0 ? null : paciente.IdMedico;
            Paciente.Sexo = paciente.Sexo;

            Paciente.IdLocalidad   = paciente.IdLocalidad == 0 ? null : paciente.IdLocalidad;
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
