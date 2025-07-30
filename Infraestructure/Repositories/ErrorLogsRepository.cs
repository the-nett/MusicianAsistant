using Aplication.Common.Interfaces;
using Domain.Entities;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ErrorLogsRepository : IErrorLogsRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ErrorLogsRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddErrorLogAsync(ErrorLogs errorLog)
        {
            await _dbContext.ErrorLogs.AddAsync(errorLog); 
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync(); 
        }
        public async Task<List<ErrorLogs>> GetAllErrorLogsAsync()
        {
            return await _dbContext.ErrorLogs.ToListAsync();
        }

    }
}
