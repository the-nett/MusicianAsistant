using Aplication.Services.Interface;
using Application.DTO.Profile;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Claims;

namespace WebAppMusicianasistant.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfilesController : ControllerBase
    {
        private readonly IProfileService _profileService;
        private readonly ILogger<ProfilesController> _logger;
        public ProfilesController(IProfileService profileService, ILogger<ProfilesController> logger)
        {
            _profileService = profileService;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Profile>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Profile>>> GetAllProfiles()
        {
            var profiles = await _profileService.GetAllProfiles();
            return Ok(profiles);
        }

        [HttpGet("verify-user")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> VerifyUser()
        {
            // Obtener el UID desde el claim nameidentifier
            var uid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(uid))
            {
                return Unauthorized("No se pudo obtener el UID del token.");
            }

            var UserIsInDb = await _profileService.VerifyUser(uid);
            if (UserIsInDb == null)
            {
                // Usuario no registrado en la base de datos.
                return Ok(new { exists = false, fullName = (string?)null });
            }

            return Ok(new { exists = true, UserIsInDb.FullName});
        }

        //----------------------------------------------------------------------
        [HttpGet("debug-token")]
        [AllowAnonymous] // Para facilitar las pruebas
        public IActionResult DebugToken()
        {
            if (User.Identity?.IsAuthenticated != true)
            {
                return Ok(new { message = "No autenticado" });
            }

            var claims = User.Claims.Select(c => new { Type = c.Type, Value = c.Value }).ToList();
            return Ok(new
            {
                isAuthenticated = true,
                totalClaims = claims.Count,
                claims = claims
            });
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddProfile([FromBody] CreateProfileDto dto)
        {
            _logger.LogInformation("Creating new person...");

            // Obtener el UID desde el claim nameidentifier
            string? uid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(uid))
            {
                return Unauthorized("No se pudo obtener el UID del token.");
            }
            try
            {
                if (!ModelState.IsValid)
                {
                    _logger.LogWarning("Invalid model state.");
                    return BadRequest(ModelState);
                }

                await _profileService.AddProfile(dto, uid); // <-- delegás el DTO directamente
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while creating person.");
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An internal error occurred while creating person." });
            }
        }
    }
}
