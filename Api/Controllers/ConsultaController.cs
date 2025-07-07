using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Models;
using Microsoft.AspNetCore.Authorization;


namespace Api.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    public class ConsultaController : ControllerBase
    {

        private ConsultorioContext _db;
        private readonly ILogger<DiagnosticoController> _logger;

        public ConsultaController(ConsultorioContext db, ILogger<DiagnosticoController> logger)
        {
            _db = db;
            _logger = logger;
        }

        // GET: api/Events
        [HttpGet]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public IActionResult GetEvents(DateTime start, DateTime end)
        {
            var paciente = _db.Paciente.ToList();
            var consulta = _db.Consulta.ToList();
            var mutual = _db.Mutual.ToList();
            var medico = _db.Medico.Where(s=>s.TieneAgenda==true).ToList();

            var resultado = from con in consulta
                            join pac in paciente on con.IdPaciente equals pac.Id into consultaPaciente
                            join mut in mutual on con.Paciente.IdMutual equals mut.Id into mutualPaciente
                            from cp in consultaPaciente.DefaultIfEmpty()
                            from mp in mutualPaciente.DefaultIfEmpty()
                            select new
                            
                            {
                                Id = con.Id,
                                text= con.Paciente.Mutual == null ? cp.ApeyNom + "(Sin Mutual)" + "\n" + "Tel Fijo:" + cp.TelFijo +"\n"+ "Tel Celular:" + cp.TelCelular + "\n" + con.observaciones : cp.ApeyNom + "(" + mp.DescA + ")\n" +  "Tel Fijo:" + cp.TelFijo + "\n" + "Tel Celular:" + cp.TelCelular + "\n"+ con.observaciones,   
                                start=con.start,
                                end=con.end,
                                IdPaciente=con.IdPaciente,
                                IdMedico = con.IdMedico,
                                color =con.color,
                                mutual=con.Paciente.IdMutual == null ? "" :mp.DescA
                                

                            };
                

            // var consulta = _db.Consulta.Where(s => s.start >= start && s.end <= end).ToList();
            return Ok(resultado);
        }


        // GET: api/EventsByMedico
        [HttpGet("GetEventsByMedico")]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public IActionResult GetEventsByMedico(DateTime start, DateTime end, int idMedico)
        {
            var paciente = _db.Paciente.ToList();
            var consulta = _db.Consulta.ToList();
            var mutual = _db.Mutual.ToList();
            var medico = _db.Medico.Where(s => s.TieneAgenda == true).ToList();

            var resultado = from con in consulta
                            where ((con.IdMedico == idMedico) && (idMedico != 0) || (idMedico == 0))
                            join pac in paciente on con.IdPaciente equals pac.Id into consultaPaciente
                            join mut in mutual on con.Paciente.IdMutual equals mut.Id into mutualPaciente
                            from cp in consultaPaciente.DefaultIfEmpty()
                            from mp in mutualPaciente.DefaultIfEmpty()
                            select new
                            {
                                Id = con.Id,
                                text = con.Paciente.Mutual == null ? cp.ApeyNom + "(Sin Mutual)" + "\n" + "Tel Fijo:" + cp.TelFijo + "\n" + "Tel Celular:" + cp.TelCelular + "\n" + con.observaciones : cp.ApeyNom + "(" + mp.DescA + ")\n" + "Tel Fijo:" + cp.TelFijo + "\n" + "Tel Celular:" + cp.TelCelular + "\n" + con.observaciones,
                                start = con.start,
                                end = con.end,
                                IdPaciente = con.IdPaciente,
                                IdMedico = con.IdMedico,
                                color = con.color,
                                mutual = con.Paciente.IdMutual == null ? "" : mp.DescA
                            };


            // var consulta = _db.Consulta.Where(s => s.start >= start && s.end <= end).ToList();
            return Ok(resultado);
        }




        // GET: api/Events
        [HttpGet("GetEventsByFecha")]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public IActionResult/*IEnumerable<Event>*/ GetEventsByFecha(string start)
        {
            return Ok();//from e in _context.Events where !((e.End.ToString().Length <= 10) || (e.Start.ToString().Length >=10 )) select e;
        }

        // GET: api/Events/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEvent([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var @event = await _db.Consulta.SingleOrDefaultAsync(m => m.Id == id);

            if (@event == null)
            {
                return NotFound();
            }

            return Ok(@event);
        }

        // PUT: api/Events/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvent([FromRoute] int id, [FromBody] Consulta @event)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != @event.Id)
            {
                return BadRequest();
            }

            _db.Entry(@event).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // PUT: api/Events/5/move
        [HttpPut("{id}/move")]
        //[HttpPut("Move")]
        public async Task<IActionResult> MoveConsulta([FromRoute] int id, [FromBody] Consulta c)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var @event = await _db.Consulta.SingleOrDefaultAsync(m => m.Id == id);
            if (@event == null)
            {
                return NotFound();
            }

            @event.start = c.start;
            @event.end = c.end;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // PUT: api/Events/5/color
        [HttpPut("{id}/color")]
        public async Task<IActionResult> SetEventColor([FromRoute] int id, [FromBody] Consulta param)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var @event = await _db.Consulta.SingleOrDefaultAsync(m => m.Id == id);
            if (@event == null)
            {
                return NotFound();
            }

            @event.color = param.color;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        // PUT: api/Events/5/color
        [HttpPut("{id}/UpdateConsulta")]
        public async Task<IActionResult> UpdateConsulta([FromRoute] int id, [FromBody] Consulta param)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var @event = await _db.Consulta.SingleOrDefaultAsync(m => m.Id == id);
            if (@event == null)
            {
                return NotFound();
            }

            @event.IdPaciente = param.IdPaciente;
            @event.observaciones = param.observaciones;
            @event.color = param.color;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }





        // POST: api/Events
        [HttpPost("PostEvent")]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]

        public async Task<IActionResult> PostEvent([FromBody] Consulta consulta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cDiag = await _db.ConsultaDiagnostico.SingleOrDefaultAsync(m => m.IdConsulta == consulta.Id);


            cDiag.IdDiagnostico = consulta.Cdiag.FirstOrDefault().Id;
            @event.IdPaciente = param.IdPaciente;
            @event.observaciones = param.observaciones;
            @event.color = param.color;


            _db.Consulta.Add(consulta);
            try
            {
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                e.ToString();

            }
            
            //await _db.SaveChangesAsync();
            return CreatedAtAction("GetEvent", new { id = consulta.Id }, consulta);
        }

        // DELETE: api/Events/5
        //[HttpDelete("{id}")]
        [HttpPut("DeleteEvent")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteEvent(Int32 id)
       // public async Task<IActionResult> DeleteEvent([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var @event = await _db.Consulta.SingleOrDefaultAsync(m => m.Id == id);
            if (@event == null)
            {
                return NotFound();
            }

            _db.Consulta.Remove(@event);
            await _db.SaveChangesAsync();

            return Ok(@event);
        }

        private bool EventExists(int id)
        {
            return _db.Consulta.Any(e => e.Id == id);
        }
    }


    public class EventMoveParams
    {
        public DateTime start { get; set; }
        public DateTime end { get; set; }

        public int IdPaciente { get; set; }
    }

    public class EventColorParams
    {
        public string Color { get; set; }
    }

}