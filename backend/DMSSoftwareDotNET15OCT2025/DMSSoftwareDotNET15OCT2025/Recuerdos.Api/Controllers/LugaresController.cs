using DMSSoftwareDotNET15OCT2025.Recuerdos.Application.DTOs;
using DMSSoftwareDotNET15OCT2025.Recuerdos.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DMSSoftwareDotNET15OCT2025.Recuerdos.Api.Controllers
{
    /// <summary>
    /// Controlador API para gestión de Lugares y asociación a Recuerdos.
    /// 
    /// Rol en arquitectura hexagonal:
    /// - Capa Interface Adapters (Controllers).
    /// - Recibe solicitudes HTTP, valida entrada mínima y llama a los Application Services.
    /// - No contiene lógica de negocio, cumpliendo SRP.
    /// - Facilita que la capa de dominio permanezca independiente de la infraestructura HTTP.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class LugaresController : ControllerBase
    {
        private readonly LugarService _service;

        public LugaresController(LugarService service) => _service = service;

        /// <summary>
        /// Endpoint para crear un nuevo lugar.
        /// </summary>
        [HttpPost("crear")]
        public async Task<IActionResult> CrearLugar([FromBody] CreateLugarRequest request)
        {
            var lugar = await _service.CrearLugarAsync(request);
            return Ok(lugar);
        }

        /// <summary>
        /// Endpoint para asociar un lugar a un recuerdo.
        /// </summary>
        [HttpPost("asociar")]
        public async Task<IActionResult> AsociarLugar([FromBody] AsociarLugarRecuerdoRequest request)
        {
            var rl = await _service.AsociarLugarAsync(request);
            return Ok(rl);
        }
    }
}
