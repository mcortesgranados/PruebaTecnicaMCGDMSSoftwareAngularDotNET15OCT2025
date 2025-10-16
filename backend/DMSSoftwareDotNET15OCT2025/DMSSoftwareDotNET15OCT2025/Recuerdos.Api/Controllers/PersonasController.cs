using DMSSoftwareDotNET15OCT2025.Recuerdos.Application.DTOs;
using DMSSoftwareDotNET15OCT2025.Recuerdos.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DMSSoftwareDotNET15OCT2025.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonasController : ControllerBase
    {
        private readonly PersonaService _personaService;

        public PersonasController(PersonaService personaService)
        {
            _personaService = personaService;
        }

        [HttpPost("asociar")]
        public async Task<IActionResult> AsociarPersona([FromBody] AsociarPersonaRecuerdoRequest request)
        {
            try
            {
                var resultado = await _personaService.CrearYAsociarAsync(request);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al asociar persona: {ex.Message}");
            }
        }
    }
}
