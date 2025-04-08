using Application.DTO.Profile;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Services.Interface
{
    public interface IProfileService
    {
        Task<IEnumerable<Profile>> GetAllProfiles();
        Task <Profile> VerifyUser(string uid);
        Task AddProfile(CreateProfileDto dto, string uid);
    }
}
