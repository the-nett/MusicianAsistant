using Aplication.DTO.Profile;
using Aplication.Services.Interface;
using Application.DTO.Profile;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        [ProducesResponseType(typeof(IEnumerable<AdminProfileViewDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<AdminProfileViewDto>>> GetAllProfiles()
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

            return Ok(new { exists = true, UserIsInDb.FullName });
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
        //---Eliminar en producción AlowAnonymous---//
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddProfile([FromBody] CreateProfileDto dto)
        {
            _logger.LogInformation("Creating new person...");

            // Obtener el UID desde el claim nameidentifier
            string? uid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            //---descomenatar en producción---//
            //if (string.isnullorempty(uid))
            //{
            //    return unauthorized("no se pudo obtener el uid del token.");
            //}
            try
            {
                if (!ModelState.IsValid)
                {
                    _logger.LogWarning("Invalid model state.");
                    return BadRequest(ModelState);
                }

                await _profileService.AddProfile(dto, "uid"); // <-- delegás el DTO directamente, en producción "uid" sin comillas
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while creating person.");
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An internal error occurred while creating person." });
            }
        }

        [HttpGet("pending")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(IEnumerable<AdminProfileViewDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPendingProfiles()
        {
            var pendingUsers = await _profileService.GetPendingProfilesAsync();
            return Ok(pendingUsers);
        }

        [HttpPut("EditProfile")] // PUT para reemplazar un recurso completo con los datos proporcionados
        // [AllowAnonymous] // Considera restringir esto en producción a roles autorizados (ej. administradores)
        [ProducesResponseType(StatusCodes.Status200OK)] // Actualización exitosa
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // Datos inválidos
        [ProducesResponseType(StatusCodes.Status404NotFound)] // Perfil no encontrado
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] // Error inesperado del servidor
        public async Task<IActionResult> EditProfile([FromBody] AdminEditProfileDto dto)
        {
            // 1. Validación inicial del DTO (ModelState si tienes DataAnnotations)
            if (dto == null || dto.Id <= 0)
            {
                _logger.LogWarning($"EditProfile: Invalid profile data received. DTO is null or ID is invalid: {dto?.Id}");
                return BadRequest("Invalid profile data. Profile ID must be positive.");
            }

            // Si tienes validaciones más complejas en el DTO (ej. [Required], [StringLength])
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("EditProfile: Model state is invalid.");
                return BadRequest(ModelState);
            }

            try
            {
                // 2. Llamada al servicio para actualizar el perfil
                await _profileService.EditProfile(dto);

                _logger.LogInformation($"Profile with ID {dto.Id} has been successfully updated.");
                return Ok(new { message = "Profile updated successfully." });
            }
            catch (KeyNotFoundException ex)
            {
                // 3. Manejo de perfil no encontrado
                _logger.LogWarning(ex, $"EditProfile: Profile with ID {dto.Id} not found for update.");
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                // 4. Manejo de cualquier otro error inesperado
                _logger.LogError(ex, $"EditProfile: An unexpected error occurred while updating profile with ID {dto.Id}.");
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An internal server error occurred while updating the profile." });
            }
        }
        [HttpGet("GetProfileById")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(Profile), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProfileById(int profileId)
        {
            if (profileId <= 0)
            {
                return BadRequest("Invalid profile ID.");
            }

            var foundProfile = await _profileService.GetProfileByIdAsync(profileId);
            if (foundProfile == null)
            {
                return NotFound($"Profile with ID {profileId} not found.");
            }
            return Ok(foundProfile);
        }
        // COntrollers for users
        [HttpPut("EditUserProfile")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)] // Success
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // Invalid data
        [ProducesResponseType(StatusCodes.Status401Unauthorized)] // Not authenticated
        [ProducesResponseType(StatusCodes.Status404NotFound)] // Profile not found (though less likely if user is authenticated)
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] // Unexpected error
        public async Task<IActionResult> EditMyProfile([FromBody] UserEditProfileDto dto, int userUniqueId) // se debe remober el userUniqueId de los parámetros en producción
        {
            // 1. Get the UserUniqueId from the authenticated user's claims
            //int userUniqueId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            //---------- se pone considera en proccion
            //if (userUniqueId == null)
            //{
            //    // This should ideally not happen if [Authorize] is used correctly,
            //    // but it's a good safeguard.
            //    _logger.LogWarning("EditMyProfile: Unauthorized attempt to access profile without UserUniqueId claim.");
            //    return Unauthorized("User unique ID not found in token. Please ensure you are authenticated.");
            //}

            // 2. Validate the incoming DTO
            if (dto == null)
            {
                _logger.LogWarning($"EditMyProfile: Received null DTO for user userUniqueId."); //{ userUniqueId}
                return BadRequest("Profile data cannot be null.");
            }

            if (!ModelState.IsValid) // For DataAnnotations validation in UserEditProfileDto
            {
                _logger.LogWarning($"EditMyProfile: Invalid model state for user userUniqueId."); //{ userUniqueId}
                return BadRequest(ModelState);
            }

            try
            {
                // 3. Call the service to update the profile
                // The DTO's ID is ignored by the service; the userUniqueId from the token is authoritative.
                await _profileService.EditUserProfile(userUniqueId, dto);

                _logger.LogInformation($"EditMyProfile: Profile for user {userUniqueId} updated successfully.");
                return Ok(new { message = "Your profile has been updated successfully." });
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, $"EditMyProfile: Profile not found for user {userUniqueId}.");
                return NotFound(new { message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                // Catches the DTO ID mismatch or other invalid operations from the service
                _logger.LogWarning(ex, $"EditMyProfile: Invalid operation for user {userUniqueId}.");
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"EditMyProfile: An unexpected error occurred while updating profile for user {userUniqueId}.");
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An internal server error occurred while updating your profile." });
            }
        }
    }
}
