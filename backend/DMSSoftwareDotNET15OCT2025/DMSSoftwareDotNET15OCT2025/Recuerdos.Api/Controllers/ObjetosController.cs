using DMSSoftwareDotNET15OCT2025.Recuerdos.Application.DTOs;
using DMSSoftwareDotNET15OCT2025.Recuerdos.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace DMSSoftwareDotNET15OCT2025.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ObjetosController : ControllerBase
    {
        private readonly LugarService _lugarService; // Reutilizable si manejas lógica compartida
        private readonly ObjetoService _objetoService;

        public ObjetosController(ObjetoService objetoService, LugarService lugarService)
        {
            _objetoService = objetoService;
            _lugarService = lugarService;
        }

        /// <summary>
        /// Crear y asociar un listado de objetos al recuerdo.
        /// </summary>
        [HttpPost("asociar")]
        public async Task<IActionResult> AsociarObjetos([FromBody] AsociarObjetosRecuerdoRequest request)
        {
            if (request.Objetos == null || !request.Objetos.Any())
                return BadRequest("No se proporcionaron objetos para asociar.");

            try
            {
                var resultado = await _objetoService.AsociarObjetosRecuerdoAsync(request);
                return Ok(resultado); // Puede devolver la lista de objetos asociados
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al asociar objetos: {ex.Message}");
            }
        }
    }
}
