using Aplication.Common.Interfaces;
using Aplication.DTO.UserInstrument;
using Aplication.Services.Interface;
using AutoMapper;

namespace Aplication.Services.Implementation
{
    public class UserInstrumentService : IUserInstrumentService
    {
        private readonly IUserInstrumentRepository _userInstrumentRepository;
        private readonly IMapper _mapper;
        // Si necesitas validar la existencia de Profile o Instrument, inyectarías sus repositorios aquí.
        // private readonly IProfileRepository _profileRepository;
        // private readonly IInstrumentRepository _instrumentRepository;

        public UserInstrumentService(IUserInstrumentRepository userInstrumentRepository, IMapper mapper)
        {
            _userInstrumentRepository = userInstrumentRepository;
            _mapper = mapper;
            // _profileRepository = profileRepository;
            // _instrumentRepository = instrumentRepository;
        }

        public async Task<UserInstrumentDto> CreateUserInstrumentAsync(UserInstrumentCreateDto userInstrumentDto)
        {
            // Validaciones de negocio:
            // 1. Verificar si la relación ya existe para evitar duplicados.
            var existingUserInstrument = await _userInstrumentRepository.GetByIdAsync(userInstrumentDto.UserId, userInstrumentDto.InstrumentId);
            if (existingUserInstrument != null)
            {
                // Si ya existe, podrías lanzar una excepción o devolver el DTO existente.
                // Aquí lanzamos una excepción para indicar un problema de negocio.
                throw new InvalidOperationException($"The relationship between User ID {userInstrumentDto.UserId} and Instrument ID {userInstrumentDto.InstrumentId} already exists.");
            }

            var userInstrument = _mapper.Map<UserInstrument>(userInstrumentDto);

            await _userInstrumentRepository.AddAsync(userInstrument);
            await _userInstrumentRepository.SaveChangesAsync();

            // Para devolver el DTO con los nombres, necesitamos recargar la entidad con las relaciones
            // o asegurarnos de que el repositorio las cargue al añadir.
            // La forma más segura es obtenerla de nuevo para asegurar que las propiedades de navegación están cargadas.
            var createdUserInstrument = await _userInstrumentRepository.GetByIdAsync(userInstrument.UserId, userInstrument.InstrumentId);

            if (createdUserInstrument == null)
            {
                // Esto no debería pasar si SaveChangesAsync fue exitoso, pero es un buen resguardo.
                throw new InvalidOperationException("Failed to retrieve the newly created UserInstrument relationship.");
            }

            return _mapper.Map<UserInstrumentDto>(createdUserInstrument);
        }

        public async Task DeleteUserInstrumentAsync(int userId, int instrumentId)
        {
            var userInstrument = await _userInstrumentRepository.GetByIdAsync(userId, instrumentId);

            if (userInstrument == null)
            {
                throw new KeyNotFoundException($"The relationship between User ID {userId} and Instrument ID {instrumentId} was not found.");
            }

            await _userInstrumentRepository.DeleteAsync(userInstrument);
            await _userInstrumentRepository.SaveChangesAsync();
        }
        public async Task<IEnumerable<UserInstrumentDto>> GetUserInstrumentsByUserIdAsync(int userId)
        {
            var userInstruments = await _userInstrumentRepository.GetByUserIdAsync(userId);
            return _mapper.Map<IEnumerable<UserInstrumentDto>>(userInstruments);
        }
    }
}
