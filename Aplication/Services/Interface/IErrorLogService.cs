using Aplication.DTO.ErrorLogs;

namespace Aplication.Services.Interface
{
    public interface IErrorLogService
    {
        Task<int> CreateErrorLogAsync(CreateErrorLogDto errorLogDto);
        Task<List<ErrorLogDto>> GetAllErrorLogsAsync();
    }
}
