using Aplication.Services.Interface;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Aplication.DTO.Gender;

namespace WebAppMusicianasistant.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GendersController : ControllerBase
    {
        private readonly IGenderService _gendereService;
        private readonly ILogger<GendersController> _logger;

        public GendersController(IGenderService genderService, ILogger<GendersController> logger)
        {
            _gendereService = genderService ?? throw new ArgumentNullException(nameof(genderService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetGenderDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<GetGenderDto >>> GetAllGenders()
        {
            try
            {
                var genders = await _gendereService.GetAllGenders();

                if (genders == null || !genders.Any())
                {
                    _logger.LogInformation("No se encontraron géneros en la base de datos.");
                    return NoContent(); // Opcionalmente podrías usar NotFound() si prefieres.
                }

                return Ok(genders);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrió un error al obtener los géneros.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Se produjo un error interno en el servidor.");
            }
        }
    }
}
