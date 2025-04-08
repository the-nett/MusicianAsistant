using Domain.Entities;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infraestructure.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly ApplicationDbContext _context;

        public ProfileRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Profile>> GetAllProfiles()
        {
            return await _context.Profiles.ToListAsync();
        }
        public async Task<Profile> VerifyUser(string userUid)
        {
            return await _context.Profiles.FirstOrDefaultAsync(p => p.UserUniqueId == userUid);
        }
        public async Task AddProfile(Profile profile)
        {
            _context.Profiles.Add(profile);
            await _context.SaveChangesAsync();
        }
    }
}
