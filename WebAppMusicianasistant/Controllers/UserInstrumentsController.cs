using Aplication.DTO.UserInstrument;
using Aplication.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace WebApiMusicianasistant.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserInstrumentsController : ControllerBase
    {
        private readonly IUserInstrumentService _userInstrumentService;
        private readonly ILogger<UserInstrumentsController> _logger; // Inyectar ILogger

        public UserInstrumentsController(IUserInstrumentService userInstrumentService, ILogger<UserInstrumentsController> logger)
        {
            _userInstrumentService = userInstrumentService;
            _logger = logger;
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
                    return BadRequest(ModelState);
                }

                var result = await _userInstrumentService.CreateUserInstrumentAsync(dto);
                _logger.LogInformation($"UserInstrument created successfully for UserId: {result.UserId}, InstrumentId: {result.InstrumentId}");
                // Se cambió nameof(GetUserInstrumentById) a la cadena literal "GetUserInstrumentById"
                return CreatedAtAction("GetUserInstrumentById", new { userId = result.UserId, instrumentId = result.InstrumentId }, result);
            }
            catch (InvalidOperationException ex)
            {
                // Captura excepciones de negocio, como duplicados
                _logger.LogWarning(ex, $"Conflict when creating UserInstrument: {ex.Message}");
                return Conflict(new { message = ex.Message }); // 409 Conflict
            }
            catch (KeyNotFoundException ex)
            {
                // Captura si el usuario o instrumento no existen (si implementas esa validación en el servicio)
                _logger.LogWarning(ex, $"Dependency not found for UserInstrument creation: {ex.Message}");
                return NotFound(new { message = ex.Message }); // 404 Not Found
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while creating UserInstrument.");
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
                    return NotFound($"No instruments found for user with ID {userId}.");
                }
                _logger.LogInformation($"Found {result.Count()} UserInstruments for UserId: {userId}");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An unexpected error occurred while getting UserInstruments for UserId: {userId}.");
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
                _logger.LogWarning(ex, $"UserInstrument not found for deletion: {ex.Message}");
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An unexpected error occurred while deleting UserInstrument for UserId: {userId}, InstrumentId: {instrumentId}.");
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An internal server error occurred while deleting the user instrument relationship." });
            }
        }
    }
}
