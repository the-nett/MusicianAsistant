using Aplication.DTO.Profile;
using Aplication.Services.Interface; 
using Application.DTO.Profile;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Aplication.DTO.ErrorLogs;
using Domain.Entities;

namespace WebAppMusicianasistant.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfilesController : ControllerBase
    {
        private readonly IProfileService _profileService;
        private readonly ILogger<ProfilesController> _logger;
        private readonly IErrorLogService _errorLogService; // Inyección del servicio de logs

        public ProfilesController(IProfileService profileService, ILogger<ProfilesController> logger, IErrorLogService errorLogService)
        {
            _profileService = profileService;
            _logger = logger;
            _errorLogService = errorLogService; // Asignación del servicio de logs
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
        //---Eliminar en producción AllowAnonymous---//
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddProfile([FromBody] CreateProfileDto dto)
        {
            _logger.LogInformation("Creating new person...");

            // Obtener el UID desde el claim nameidentifier
            string? uid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            //---descomentar en producción---//
            //if (string.IsNullOrEmpty(uid))
            //{
            //    return Unauthorized("No se pudo obtener el UID del token.");
            //}

            try
            {
                if (!ModelState.IsValid)
                {
                    _logger.LogWarning("Invalid model state.");
                    return BadRequest(ModelState); // Error de validación de modelo: respuesta 400
                }

                await _profileService.AddProfile(dto, "uid"); // <-- Aquí usa el UID real en producción
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex) // Este 'catch' captura cualquier excepción inesperada
            {
                _logger.LogError(ex, "Error while creating person.");

                // Intenta obtener el ID de usuario del claim, si no, usa 0
                int userId = 0;
                if (int.TryParse(uid, out int parsedUserId)) // Asumiendo que el UID puede ser un int para id_user
                {
                    userId = parsedUserId;
                }

                // --- REGISTRAR EN ERRORLOGS SOLO ERRORES INESPERADOS ---
                var errorLogDto = new CreateErrorLogDto
                {
                    Message = ex.Message,
                    StackTrace = ex.ToString(),
                    ContextInfo = $"Controller: {nameof(ProfilesController)}, Action: {nameof(AddProfile)}, User UID: {uid ?? "N/A"}",
                    IdUser = userId
                };
                await _errorLogService.CreateErrorLogAsync(errorLogDto);
                // --- FIN REGISTRO ERRORLOGS ---

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
                return BadRequest("Invalid profile data. Profile ID must be positive."); // Error de validación: respuesta 400
            }

            // Si tienes validaciones más complejas en el DTO (ej. [Required], [StringLength])
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("EditProfile: Model state is invalid.");
                return BadRequest(ModelState); // Error de validación: respuesta 400
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
                // 3. Manejo de perfil no encontrado: es un error de negocio esperado.
                // Ya tiene una respuesta específica (404 Not Found), no se loggea en ErrorLogs.
                _logger.LogWarning(ex, $"EditProfile: Profile with ID {dto.Id} not found for update.");
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex) // Este 'catch' es para cualquier otro error inesperado
            {
                // Intenta obtener el ID de usuario del claim, si no, usa 0
                int userId = 0;
                string? uid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (int.TryParse(uid, out int parsedUserId)) // Asumiendo que el UID puede ser un int para id_user
                {
                    userId = parsedUserId;
                }

                _logger.LogError(ex, $"EditProfile: An unexpected error occurred while updating profile with ID {dto.Id}.");
                // --- REGISTRAR EN ERRORLOGS SOLO ERRORES INESPERADOS ---
                var errorLogDto = new CreateErrorLogDto
                {
                    Message = ex.Message,
                    StackTrace = ex.ToString(),
                    ContextInfo = $"Controller: {nameof(ProfilesController)}, Action: {nameof(EditProfile)}, Profile ID: {dto.Id}, User UID: {uid ?? "N/A"}",
                    IdUser = userId
                };
                await _errorLogService.CreateErrorLogAsync(errorLogDto);
                // --- FIN REGISTRO ERRORLOGS ---

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

        // Controllers for users
        [HttpPut("EditUserProfile")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)] // Success
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // Invalid data
        [ProducesResponseType(StatusCodes.Status401Unauthorized)] // Not authenticated
        [ProducesResponseType(StatusCodes.Status404NotFound)] // Profile not found (though less likely if user is authenticated)
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] // Unexpected error
        public async Task<IActionResult> EditMyProfile([FromBody] UserEditProfileDto dto, int userUniqueId) // userUniqueId se debe remober de los parámetros en producción
        {
            // 1. Obtener el UserUniqueId del token autenticado en producción
            string? uid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            int currentUserId = 0; // Usaremos esto para id_user en ErrorLogs

            //---Descomentar en producción---//
            //if (string.IsNullOrEmpty(uid))
            //{
            //    _logger.LogWarning("EditMyProfile: Unauthorized attempt to access profile without UserUniqueId claim.");
            //    return Unauthorized("User unique ID not found in token. Please ensure you are authenticated.");
            //}
            //if (!int.TryParse(uid, out currentUserId))
            //{
            //    _logger.LogWarning($"EditMyProfile: Could not parse UserUniqueId '{uid}' from claim to int.");
            //    return Unauthorized("Invalid user unique ID format in token.");
            //}

            // Para depuración, si no se obtiene del token, se usa el parámetro
            if (!int.TryParse(uid, out currentUserId))
            {
                currentUserId = userUniqueId; // Para cuando userUniqueId viene del parámetro de debug
            }


            // 2. Validate the incoming DTO
            if (dto == null)
            {
                _logger.LogWarning($"EditMyProfile: Received null DTO for user {currentUserId}.");
                return BadRequest("Profile data cannot be null."); // Error de validación: respuesta 400
            }

            if (!ModelState.IsValid) // For DataAnnotations validation in UserEditProfileDto
            {
                _logger.LogWarning($"EditMyProfile: Invalid model state for user {currentUserId}.");
                return BadRequest(ModelState); // Error de validación: respuesta 400
            }

            try
            {
                // 3. Call the service to update the profile
                // El ID del DTO es ignorado por el servicio; el UserUniqueId del token es la autoridad.
                await _profileService.EditUserProfile(currentUserId, dto); // Usar currentUserId aquí

                _logger.LogInformation($"EditMyProfile: Profile for user {currentUserId} updated successfully.");
                return Ok(new { message = "Your profile has been updated successfully." });
            }
            catch (KeyNotFoundException ex)
            {
                // Error de negocio: perfil no encontrado. NO se loggea en ErrorLogs.
                _logger.LogWarning(ex, $"EditMyProfile: Profile not found for user {currentUserId}.");
                return NotFound(new { message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                // Error de negocio: operación inválida (ej. DTO ID mismatch). NO se loggea en ErrorLogs.
                _logger.LogWarning(ex, $"EditMyProfile: Invalid operation for user {currentUserId}.");
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex) // Este 'catch' es para cualquier otro error inesperado
            {
                _logger.LogError(ex, $"EditMyProfile: An unexpected error occurred while updating profile for user {currentUserId}.");

                // --- REGISTRAR EN ERRORLOGS SOLO ERRORES INESPERADOS ---
                var errorLogDto = new CreateErrorLogDto
                {
                    Message = ex.Message,
                    StackTrace = ex.ToString(),
                    ContextInfo = $"Controller: {nameof(ProfilesController)}, Action: {nameof(EditMyProfile)}, Target User ID: {currentUserId}, User UID: {uid ?? "N/A"}",
                    IdUser = currentUserId
                };
                await _errorLogService.CreateErrorLogAsync(errorLogDto);
                // --- FIN REGISTRO ERRORLOGS ---

                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An internal server error occurred while updating your profile." });
            }
        }
    }
}