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

        [HttpGet("amigo/{amigoId}")]
        public async Task<IActionResult> GetRecuerdosDeAmigo(int amigoId)
        {
            var recuerdos = await _service.ListarRecuerdosDeAmigoAsync(amigoId);
            return Ok(recuerdos);
        }

        [HttpGet("{recuerdoId}/objetos")]
        public async Task<ActionResult<List<ObjetoRecuerdoDto>>> GetObjetos(int recuerdoId)
        {
            var objetos = await _service.ListarObjetosAsync(recuerdoId);
            if (objetos == null || !objetos.Any())
                return NotFound(new { Message = "No se encontraron objetos para este recuerdo." });

            return Ok(objetos);
        }
    }
}
