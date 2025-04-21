using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Custom;
using Backend.Models;
using Backend.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;


namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class CalleController : ControllerBase
    {
        private readonly BibliotecaContext _BibliotecaContext;
        public CalleController(BibliotecaContext BibliotecaContext)
        {
            _BibliotecaContext = BibliotecaContext;
        }
        
        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var lista = await _BibliotecaContext.Calles.ToListAsync();
            return StatusCode(StatusCodes.Status200OK, new { value = lista });
        }
    }
}
