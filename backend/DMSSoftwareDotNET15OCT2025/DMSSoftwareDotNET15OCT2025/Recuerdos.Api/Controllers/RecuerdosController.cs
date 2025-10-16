using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DMSSoftwareDotNET15OCT2025.Recuerdos.Application.DTOs;
using DMSSoftwareDotNET15OCT2025.Recuerdos.Application.Services;

namespace DMSSoftwareDotNET15OCT2025.Recuerdos.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class RecuerdosController : ControllerBase
    {
        private readonly RecuerdoService _service;

        public RecuerdosController(RecuerdoService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CrearRecuerdo([FromBody] CreateRecuerdoRequest request)
        {
            var recuerdo = await _service.CrearRecuerdoAsync(request);
            return CreatedAtAction(nameof(ObtenerRecuerdo), new { id = recuerdo.Id }, recuerdo);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerRecuerdo(int id)
        {
            // Implementar método GetById en el service si deseas
            return Ok();
        }


        /// <summary>
        /// Busca recuerdos que contengan la palabra clave en la situación
        /// GET: api/Recuerdos/buscar?palabraClave=...
        /// </summary>
        [HttpGet("buscar")]
        public async Task<IActionResult> BuscarRecuerdos([FromQuery] string palabraClave)
        {
            var resultados = await _service.BuscarRecuerdosAsync(palabraClave);
            return Ok(resultados);
        }
    }
}
