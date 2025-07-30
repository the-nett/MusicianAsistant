using Domain.Entities;

namespace Aplication.Common.Interfaces
{
    public interface IErrorLogsRepository
    {
        Task AddErrorLogAsync(ErrorLogs errorLog);
        Task<int> SaveChangesAsync(); // Este método es crucial para persistir los cambios en la DB

        Task<List<ErrorLogs>> GetAllErrorLogsAsync();
    }

}
