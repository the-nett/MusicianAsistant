using Aplication.DTO.Songs;
using Aplication.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System;
using Aplication.DTO.ErrorLogs;
using Aplication.DTO.Songs;
using Aplication.Services.Interface;

namespace WebApiMusicianasistant.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    // [Authorize] // Habilitar en producción
    public class SongsController : ControllerBase
    {
        private readonly ISongService _songService;
        private readonly IProfileService _profileService;
        private readonly ILogger<SongsController> _logger;
        private readonly IErrorLogService _errorLogService;

        public SongsController(
            ISongService songService,
            IProfileService profileService,
            ILogger<SongsController> logger,
            IErrorLogService errorLogService)
        {
            _songService = songService;
            _profileService = profileService;
            _logger = logger;
            _errorLogService = errorLogService;
        }

        // --- READ: Get all songs ---
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SongViewDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<SongViewDto>>> GetAll()
        {
            try
            {
                _logger.LogInformation("Attempting to retrieve all songs.");
                var songs = await _songService.GetAllSongsAsync();
                _logger.LogInformation("Successfully retrieved all songs.");
                return Ok(songs);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while retrieving all songs.");

                var errorLogDto = new CreateErrorLogDto
                {
                    Message = ex.Message,
                    StackTrace = ex.StackTrace ?? string.Empty,
                    ContextInfo = "SongsController.GetAll",
                    IdUser = 0 // Asigna un valor predeterminado si no hay usuario autenticado
                };
                await _errorLogService.CreateErrorLogAsync(errorLogDto);

                return StatusCode(StatusCodes.Status500InternalServerError, "An internal server error occurred while fetching songs.");
            }
        }

       

        // --- READ: Get song by ID ---
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(SongViewDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<SongViewDto>> GetById(int id)
        {
            if (id <= 0)
            {
                _logger.LogWarning($"GetById: Invalid song ID provided: {id}. ID must be a positive integer.");
                return BadRequest("Invalid song ID. The ID must be a positive integer.");
            }

            try
            {
                _logger.LogInformation($"Attempting to retrieve song with ID: {id}.");
                var song = await _songService.GetSongByIdAsync(id);
                if (song == null)
                {
                    _logger.LogWarning($"GetById: Song with ID {id} not found.");
                    return NotFound($"Song with ID {id} not found.");
                }
                _logger.LogInformation($"Successfully retrieved song with ID: {id}.");
                return Ok(song);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An unexpected error occurred while retrieving song with ID: {id}.");

                var errorLogDto = new CreateErrorLogDto
                {
                    Message = ex.Message,
                    StackTrace = ex.StackTrace ?? string.Empty,
                    ContextInfo = $"SongsController.GetById (SongId: {id})",
                    IdUser = 0
                };
                await _errorLogService.CreateErrorLogAsync(errorLogDto);

                return StatusCode(StatusCodes.Status500InternalServerError, $"An internal server error occurred while fetching song with ID {id}.");
            }
        }

       

        // --- CREATE: Add a new song ---
        [HttpPost]
        [ProducesResponseType(typeof(SongViewDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<SongViewDto>> Add([FromBody] CreateSongDto dto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Add: Invalid model state for CreateSongDto.");
                return BadRequest(ModelState);
            }

            // Lógica de prueba: usar un ID fijo para el creador
            int creatorId = 1;

            /* Lógica de producción:
            var userUniqueId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userUniqueId))
            {
                _logger.LogWarning("Add: Unauthorized attempt. UserUniqueId claim not found.");
                return Unauthorized("User ID not found. Please ensure you are authenticated.");
            }
            var currentProfile = await _profileService.VerifyUser(userUniqueId);
            if (currentProfile == null)
            {
                _logger.LogWarning($"AddSong: Profile not found for UserUniqueId: {userUniqueId}. Cannot create song.");
                return BadRequest("Authenticated user profile not found. Cannot create song.");
            }
            int creatorId = currentProfile.Id;
            */

            try
            {
                _logger.LogInformation($"Attempting to add new song: '{dto.Name}' by creator ID: {creatorId}.");
                var newSong = await _songService.CreateSongAsync(dto, creatorId);
                _logger.LogInformation($"Successfully added new song with ID: {newSong.SongId}.");
                return CreatedAtAction(nameof(GetById), new { id = newSong.SongId }, newSong);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An unexpected error occurred while adding song: '{dto.Name}' by creator ID: {creatorId}.");

                var errorLogDto = new CreateErrorLogDto
                {
                    Message = ex.Message,
                    StackTrace = ex.StackTrace ?? string.Empty,
                    ContextInfo = $"SongsController.Add (SongName: {dto.Name}, CreatorId: {creatorId})",
                    IdUser = creatorId
                };
                await _errorLogService.CreateErrorLogAsync(errorLogDto);

                return StatusCode(StatusCodes.Status500InternalServerError, "An internal server error occurred while creating the song.");
            }
        }

        

        // --- UPDATE: Update an existing song ---
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateSongDto dto)
        {
            if (id <= 0 || id != dto.SongId)
            {
                _logger.LogWarning($"Update: Invalid song ID in URL ({id}) or mismatch with DTO ID ({dto.SongId}).");
                return BadRequest("URL ID does not match DTO ID or is invalid.");
            }
            if (!ModelState.IsValid)
            {
                _logger.LogWarning($"Update: Invalid model state for UpdateSongDto for song ID: {id}.");
                return BadRequest(ModelState);
            }

            // Lógica de prueba: usar un ID fijo para el actualizador
            int updaterId = 1;

            /* Lógica de producción:
            var userUniqueId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userUniqueId))
            {
                _logger.LogWarning($"Update: Unauthorized attempt for song ID {id}. UserUniqueId claim not found.");
                return Unauthorized("User ID not found. Please ensure you are authenticated.");
            }
            var currentProfile = await _profileService.VerifyUser(userUniqueId);
            if (currentProfile == null)
            {
                 _logger.LogWarning($"UpdateSong: Profile not found for UserUniqueId: {userUniqueId}. Cannot update song ID: {id}.");
                return BadRequest("Authenticated user profile not found. Cannot update song.");
            }
            int updaterId = currentProfile.Id;
            */

            try
            {
                _logger.LogInformation($"Attempting to update song with ID: {id} by updater ID: {updaterId}.");
                await _songService.UpdateSongAsync(dto, updaterId);
                _logger.LogInformation($"Successfully updated song with ID: {id}.");
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, $"Update: Song with ID {id} not found for update.");
                return NotFound(ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                _logger.LogWarning(ex, $"Update: Unauthorized access to update song with ID {id} by updater ID {updaterId}.");
                return Forbid(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An unexpected error occurred while updating song with ID: {id} by updater ID: {updaterId}.");

                var errorLogDto = new CreateErrorLogDto
                {
                    Message = ex.Message,
                    StackTrace = ex.StackTrace ?? string.Empty,
                    ContextInfo = $"SongsController.Update (SongId: {id}, UpdaterId: {updaterId})",
                    IdUser = updaterId
                };
                await _errorLogService.CreateErrorLogAsync(errorLogDto);

                return StatusCode(StatusCodes.Status500InternalServerError, $"An internal server error occurred while updating song with ID {id}.");
            }
        }

       

        // --- DELETE: Delete an existing song ---
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                _logger.LogWarning($"Delete: Invalid song ID provided: {id}.");
                return BadRequest("Invalid song ID. The ID must be a positive integer.");
            }

            // Lógica de prueba: usar un ID fijo para el eliminador
            int deleterId = 1;

            /* Lógica de producción:
            var userUniqueId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userUniqueId))
            {
                _logger.LogWarning($"Delete: Unauthorized attempt for song ID {id}. UserUniqueId claim not found.");
                return Unauthorized("User ID not found. Please ensure you are authenticated.");
            }
            var currentProfile = await _profileService.VerifyUser(userUniqueId);
            if (currentProfile == null)
            {
                 _logger.LogWarning($"DeleteSong: Profile not found for UserUniqueId: {userUniqueId}. Cannot delete song ID: {id}.");
                return BadRequest("Authenticated user profile not found. Cannot delete song.");
            }
            int deleterId = currentProfile.Id;
            */

            try
            {
                _logger.LogInformation($"Attempting to delete song with ID: {id} by deleter ID: {deleterId}.");
                await _songService.DeleteSongAsync(id, deleterId);
                _logger.LogInformation($"Successfully deleted song with ID: {id}.");
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, $"Delete: Song with ID {id} not found for deletion.");
                return NotFound(ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                _logger.LogWarning(ex, $"Delete: Unauthorized access to delete song with ID {id} by deleter ID {deleterId}.");
                return Forbid(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An unexpected error occurred while deleting song with ID: {id} by deleter ID: {deleterId}.");

                var errorLogDto = new CreateErrorLogDto
                {
                    Message = ex.Message,
                    StackTrace = ex.StackTrace ?? string.Empty,
                    ContextInfo = $"SongsController.Delete (SongId: {id}, DeleterId: {deleterId})",
                    IdUser = deleterId
                };
                await _errorLogService.CreateErrorLogAsync(errorLogDto);

                return StatusCode(StatusCodes.Status500InternalServerError, $"An internal server error occurred while deleting song with ID {id}.");
            }
        }
    }
}