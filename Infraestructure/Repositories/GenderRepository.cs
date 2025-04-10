using Domain.Entities;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infraestructure.Repositories
{
    public class GenderRepository : IGenderRepository
    {
        private readonly ApplicationDbContext _context;

        public GenderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Gender>> GetAllGenders()
        {
            return await _context.Genders.ToListAsync();
        }
        //public async Task<Profile> VerifyUser(string userUid)
        //{
        //    return await _context.Profiles.FirstOrDefaultAsync(p => p.UserUniqueId == userUid);
        //}
        //public async Task AddProfile(Profile profile)
        //{
        //    _context.Profiles.Add(profile);
        //    await _context.SaveChangesAsync();
        //}
    }
}
