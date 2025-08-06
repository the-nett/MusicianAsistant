using Aplication.Common.Interfaces;
using Domain.Entities;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class SongRepository : ISongRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public SongRepository(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public async Task<IEnumerable<Song>> GetAllAsync()
        {
            return await _dbContext.Songs
                                 .Include(s => s.Creator) // Eager load the Creator for the View DTO
                                 .ToListAsync();
        }

        public async Task<Song?> GetByIdAsync(int id)
        {
            return await _dbContext.Songs
                                 .Include(s => s.Creator) // Eager load the Creator
                                 .FirstOrDefaultAsync(s => s.SongId == id);
        }

        public async Task AddAsync(Song song)
        {
            await _dbContext.Songs.AddAsync(song);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Song song)
        {
            _dbContext.Entry(song).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var songToDelete = await _dbContext.Songs.FindAsync(id);
            if (songToDelete != null)
            {
                _dbContext.Songs.Remove(songToDelete);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
