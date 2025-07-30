using Aplication.DTO.UserInstrument;
using Aplication.Services.Interface; 
using Microsoft.AspNetCore.Mvc;
using Aplication.DTO.ErrorLogs; 

namespace WebApiMusicianasistant.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserInstrumentsController : ControllerBase
    {
        private readonly IUserInstrumentService _userInstrumentService;
        private readonly ILogger<UserInstrumentsController> _logger;
        private readonly IErrorLogService _errorLogService; // ¡Nueva inyección!

        public UserInstrumentsController(IUserInstrumentService userInstrumentService, ILogger<UserInstrumentsController> logger, IErrorLogService errorLogService) // ¡Parámetro añadido!
        {
            _userInstrumentService = userInstrumentService;
            _logger = logger;
            _errorLogService = errorLogService; // ¡Asignación!
        }

        // POST: api/userinstruments
        // Permite a un administrador o usuario añadir un instrumento a un perfil.
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UserInstrumentDto>> CreateUserInstrument([FromBody] UserInstrumentCreateDto dto)
        {
            _logger.LogInformation($"Attempting to create UserInstrument for UserId: {dto.UserId}, InstrumentId: {dto.InstrumentId}");
            try
            {
                if (!ModelState.IsValid)
                {
                    _logger.LogWarning("Invalid model state for CreateUserInstrument.");
                    return BadRequest(ModelState); // Error de validación: respuesta 400
                }

                var result = await _userInstrumentService.CreateUserInstrumentAsync(dto);
                _logger.LogInformation($"UserInstrument created successfully for UserId: {result.UserId}, InstrumentId: {result.InstrumentId}");
                return StatusCode(StatusCodes.Status201Created, result);
            }
            catch (InvalidOperationException ex)
            {
                // Captura excepciones de negocio, como duplicados. Esta es una respuesta esperada.
                // NO se loggea en ErrorLogs.
                _logger.LogWarning(ex, $"Conflict when creating UserInstrument: {ex.Message}");
                return Conflict(new { message = ex.Message }); // 409 Conflict
            }
            catch (KeyNotFoundException ex)
            {
                // Captura si el usuario o instrumento no existen. Esta es una respuesta esperada.
                // NO se loggea en ErrorLogs.
                _logger.LogWarning(ex, $"Dependency not found for UserInstrument creation: {ex.Message}");
                return NotFound(new { message = ex.Message }); // 404 Not Found
            }
            catch (Exception ex) // Este 'catch' captura cualquier excepción inesperada
            {
                _logger.LogError(ex, "An unexpected error occurred while creating UserInstrument.");

                // --- REGISTRAR EN ERRORLOGS SOLO ERRORES INESPERADOS ---
                // Se usa dto.UserId para el id_user en ErrorLogs
                var errorLogDto = new CreateErrorLogDto
                {
                    Message = ex.Message,
                    StackTrace = ex.ToString(),
                    ContextInfo = $"Controller: {nameof(UserInstrumentsController)}, Action: {nameof(CreateUserInstrument)}, UserId: {dto.UserId}, InstrumentId: {dto.InstrumentId}",
                    IdUser = dto.UserId // Usar el ID del usuario de la solicitud
                };
                await _errorLogService.CreateErrorLogAsync(errorLogDto);
                // --- FIN REGISTRO ERRORLOGS ---

                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An internal server error occurred while creating the user instrument relationship." });
            }
        }

        // GET: api/userinstruments/byuser/{userId}
        // Obtiene todos los instrumentos asociados a un usuario específico.
        [HttpGet("byuser/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<UserInstrumentDto>>> GetUserInstrumentsByUserId(int userId)
        {
            _logger.LogInformation($"Attempting to get all UserInstruments for UserId: {userId}");
            try
            {
                var result = await _userInstrumentService.GetUserInstrumentsByUserIdAsync(userId);

                if (result == null || !result.Any())
                {
                    _logger.LogInformation($"No UserInstruments found for UserId: {userId}");
                    return NotFound($"No instruments found for user with ID {userId}."); // Perfil no encontrado: respuesta 404
                }
                _logger.LogInformation($"Found {result.Count()} UserInstruments for UserId: {userId}");
                return Ok(result);
            }
            catch (Exception ex) // Este 'catch' captura cualquier excepción inesperada
            {
                _logger.LogError(ex, $"An unexpected error occurred while getting UserInstruments for UserId: {userId}.");

                // --- REGISTRAR EN ERRORLOGS SOLO ERRORES INESPERADOS ---
                var errorLogDto = new CreateErrorLogDto
                {
                    Message = ex.Message,
                    StackTrace = ex.ToString(),
                    ContextInfo = $"Controller: {nameof(UserInstrumentsController)}, Action: {nameof(GetUserInstrumentsByUserId)}, Target UserId: {userId}",
                    IdUser = userId // Usar el ID del usuario de la ruta
                };
                await _errorLogService.CreateErrorLogAsync(errorLogDto);
                // --- FIN REGISTRO ERRORLOGS ---

                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An internal server error occurred while retrieving user instrument relationships." });
            }
        }

        // DELETE: api/userinstruments/{userId}/{instrumentId}
        // Elimina una relación UserInstrument.
        [HttpDelete("{userId}/{instrumentId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteUserInstrument(int userId, int instrumentId)
        {
            _logger.LogInformation($"Attempting to delete UserInstrument for UserId: {userId}, InstrumentId: {instrumentId}");
            try
            {
                await _userInstrumentService.DeleteUserInstrumentAsync(userId, instrumentId);
                _logger.LogInformation($"UserInstrument deleted successfully for UserId: {userId}, InstrumentId: {instrumentId}");
                return NoContent(); // 204 No Content para eliminación exitosa
            }
            catch (KeyNotFoundException ex)
            {
                // Elemento no encontrado para eliminación: es un error de negocio esperado.
                // NO se loggea en ErrorLogs.
                _logger.LogWarning(ex, $"UserInstrument not found for deletion: {ex.Message}");
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex) // Este 'catch' captura cualquier excepción inesperada
            {
                _logger.LogError(ex, $"An unexpected error occurred while deleting UserInstrument for UserId: {userId}, InstrumentId: {instrumentId}.");

                // --- REGISTRAR EN ERRORLOGS SOLO ERRORES INESPERADOS ---
                var errorLogDto = new CreateErrorLogDto
                {
                    Message = ex.Message,
                    StackTrace = ex.ToString(),
                    ContextInfo = $"Controller: {nameof(UserInstrumentsController)}, Action: {nameof(DeleteUserInstrument)}, UserId: {userId}, InstrumentId: {instrumentId}",
                    IdUser = userId // Usar el ID del usuario de la ruta
                };
                await _errorLogService.CreateErrorLogAsync(errorLogDto);
                // --- FIN REGISTRO ERRORLOGS ---

                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An internal server error occurred while deleting the user instrument relationship." });
            }
        }
    }
}