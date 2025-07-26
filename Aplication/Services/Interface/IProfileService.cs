using Aplication.DTO.Profile;
using Application.DTO.Profile;
using Domain.Entities;

namespace Aplication.Services.Interface
{
    public interface IProfileService
    {
        Task<IEnumerable<AdminProfileViewDto>> GetAllProfiles();
        Task <Profile> VerifyUser(string uid);
        Task AddProfile(CreateProfileDto dto, string uid);
        Task<IEnumerable<AdminProfileViewDto>> GetPendingProfilesAsync();
        Task EditProfile(AdminEditProfileDto editProfileDto);
        Task<AdminProfileViewDto?> GetProfileByIdAsync(int profileId);
        Task EditUserProfile(int userUniqueId, UserEditProfileDto userEditProfileDto);

    }
}
