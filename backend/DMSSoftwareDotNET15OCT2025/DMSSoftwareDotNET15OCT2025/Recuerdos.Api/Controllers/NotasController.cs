using DMSSoftwareDotNET15OCT2025.Recuerdos.Application.DTOs;
using DMSSoftwareDotNET15OCT2025.Recuerdos.Application.Services;
using DMSSoftwareDotNET15OCT2025.Recuerdos.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DMSSoftwareDotNET15OCT2025.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotasController : ControllerBase
    {
        private readonly NotaService _notaService;

        public NotasController(NotaService notaService)
        {
            _notaService = notaService;
        }

        [HttpPost("asociar")]
        public async Task<IActionResult> AsociarNota([FromBody] CreateNotaRequest request)
        {
            try
            {
                Nota nota = await _notaService.CrearYAsociarNotaAsync(request);
                return Ok(nota);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al asociar nota: {ex.Message}");
            }
        }
    }
}
