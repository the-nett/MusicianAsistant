using Aplication.DTO.UserInstrument;

namespace Aplication.Services.Interface
{
    public interface IUserInstrumentService
    {
        // Crea una nueva relación UserInstrument
        Task<UserInstrumentDto> CreateUserInstrumentAsync(UserInstrumentCreateDto userInstrumentDto);
        // Elimina una relación UserInstrument
        Task DeleteUserInstrumentAsync(int userId, int instrumentId);

        // Obtiene la lista de instrumentos asociados a un usuario
        Task<IEnumerable<UserInstrumentDto>> GetUserInstrumentsByUserIdAsync(int userId);
    }
}
