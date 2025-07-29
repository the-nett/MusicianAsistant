namespace Aplication.Common.Interfaces
{
    public interface IUserInstrumentRepository
    {
        // Añade una nueva relación UserInstrument
        Task AddAsync(UserInstrument userInstrument);
        // Elimina una relación UserInstrument
        Task DeleteAsync(UserInstrument userInstrument);
        // Obtiene una relación UserInstrument por sus IDs (clave compuesta)
        Task<UserInstrument?> GetByIdAsync(int userId, int instrumentId);
        // Obtiene todas las relaciones UserInstrument de un usuario específico
        Task<IEnumerable<UserInstrument>> GetByUserIdAsync(int userId);
        // Guarda los cambios en el contexto de la base de datos
        Task SaveChangesAsync();
    }
}
