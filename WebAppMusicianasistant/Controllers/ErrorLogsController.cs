using Aplication.DTO.ErrorLogs;
using Aplication.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace WebApiMusicianasistant.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    // [Authorize(Roles = "Administrator")] // Considera proteger este endpoint para admins
    public class ErrorLogsController : ControllerBase
    {
        private readonly IErrorLogService _errorLogService;
        private readonly ILogger<ErrorLogsController> _logger; // Opcional, pero bueno para logging interno del controlador

        public ErrorLogsController(IErrorLogService errorLogService, ILogger<ErrorLogsController> logger)
        {
            _errorLogService = errorLogService;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ErrorLogDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<ErrorLogDto>>> GetAllErrorLogs()
        {
            try
            {
                _logger.LogInformation("Attempting to retrieve all error logs.");
                var errorLogs = await _errorLogService.GetAllErrorLogsAsync();
                return Ok(errorLogs);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving error logs.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred while fetching error logs.");
            }
        }
    }
}
