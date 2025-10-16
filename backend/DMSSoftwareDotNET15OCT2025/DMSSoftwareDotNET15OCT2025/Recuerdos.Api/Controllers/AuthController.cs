using Microsoft.AspNetCore.Mvc;

using DMSSoftwareDotNET15OCT2025.Recuerdos.Application.Interfaces;
using DMSSoftwareDotNET15OCT2025.Recuerdos.Application.DTOs;
using DMSSoftwareDotNET15OCT2025.Recuerdos.Application.Interfaces;

using System;
using System.Threading.Tasks;

namespace DMSSoftwareDotNET15OCT2025.Recuerdos.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _auth;

        public AuthController(IAuthService auth) => _auth = auth;

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest req)
        {
            try
            {
                var res = await _auth.RegisterAsync(req);
                return CreatedAtAction(nameof(Register), res);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { message = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest req)
        {
            var res = await _auth.LoginAsync(req);
            if (res == null) return Unauthorized(new { message = "Credenciales inválidas." });
            return Ok(res);
        }
    }
}
