using Aplication.Common.Interfaces;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UserInstrumentRepository : IUserInstrumentRepository
    {
        private readonly ApplicationDbContext _context;

        public UserInstrumentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(UserInstrument userInstrument)
        {
            await _context.UserInstruments.AddAsync(userInstrument);
        }

        public Task DeleteAsync(UserInstrument userInstrument)
        {
            _context.UserInstruments.Remove(userInstrument);
            return Task.CompletedTask;
        }

        public async Task<UserInstrument?> GetByIdAsync(int userId, int instrumentId)
        {
            return await _context.UserInstruments
                                 .Include(ui => ui.User)
                                 .Include(ui => ui.Instrument)
                                 .FirstOrDefaultAsync(ui => ui.UserId == userId && ui.InstrumentId == instrumentId);
        }

        public async Task<IEnumerable<UserInstrument>> GetByUserIdAsync(int userId)
        {
            return await _context.UserInstruments
                                 .Where(ui => ui.UserId == userId)
                                 .Include(ui => ui.User)
                                 .Include(ui => ui.Instrument)
                                 .ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
