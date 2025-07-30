using Aplication.Common.Interfaces;
using Aplication.DTO.ErrorLogs;
using Aplication.Services.Interface;
using AutoMapper;
using Domain.Entities;

namespace Aplication.Services.Implementation
{
    public class ErrorLogService : IErrorLogService
    {
        // Ahora inyectamos IErrorLogsRepository, no IGenericRepository<ErrorLogs>
        private readonly IErrorLogsRepository _errorLogsRepository;
        private readonly IMapper _mapper;

        public ErrorLogService(IErrorLogsRepository errorLogsRepository, IMapper mapper)
        {
            _errorLogsRepository = errorLogsRepository;
            _mapper = mapper;
        }

        public async Task<int> CreateErrorLogAsync(CreateErrorLogDto errorLogDto)
        {
            var errorLog = _mapper.Map<ErrorLogs>(errorLogDto);

            // Llamamos al método específico del repositorio
            await _errorLogsRepository.AddErrorLogAsync(errorLog);
            await _errorLogsRepository.SaveChangesAsync(); // Persistimos los cambios

            return errorLog.IdError;
        }
        public async Task<List<ErrorLogDto>> GetAllErrorLogsAsync()
        {
            var errorLogs = await _errorLogsRepository.GetAllErrorLogsAsync();
            return _mapper.Map<List<ErrorLogDto>>(errorLogs);
        }
    }
}
