using Aplication.DTO.Profile;
using Aplication.Services.Interface;
using Application.DTO.Profile;
using AutoMapper;
using Domain.Entities;
using System;
namespace Aplication.Services.Implementation
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository _profileRepository;
        private readonly IMapper _mapper;

        public ProfileService(IProfileRepository profileRepository, IMapper mapper)
        {
            _profileRepository = profileRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AdminProfileViewDto>> GetAllProfiles()
        {
            var profiles = await _profileRepository.GetAllProfiles();
            return _mapper.Map<IEnumerable<AdminProfileViewDto>>(profiles);
        }
        public async Task<AdminProfileViewDto?> GetProfileByIdAsync(int profileId)
        {
            
            var profile = await _profileRepository.GetProfileById(profileId); 

            if (profile == null)
            {
                return null; 
            }

            return _mapper.Map<AdminProfileViewDto>(profile);
        }
        public async Task<Domain.Entities.Profile> VerifyUser(string userUid)
        {
            return await _profileRepository.VerifyUser(userUid);
        }
        public async Task AddProfile(CreateProfileDto Createprofile, string uid)
        {
            var profile = _mapper.Map<Domain.Entities.Profile>(Createprofile);
            profile.UserUniqueId = uid;
            await _profileRepository.AddProfile(profile);

        }
        public async Task<IEnumerable<AdminProfileViewDto>> GetPendingProfilesAsync()
        {
            var profiles = await _profileRepository.GetPendingProfilesAsync();
            return _mapper.Map<IEnumerable<AdminProfileViewDto>>(profiles);
        }

        public async Task AcceptPendingProfile(int profileId)
        {
            var foundProfile = await _profileRepository.GetProfileById(profileId); // Usamos el nuevo método GetById

            if (foundProfile == null)
            {
                throw new KeyNotFoundException($"Profile with ID {profileId} not found.");
            }

            foundProfile.IsActive = true; // Actualiza el estado del perfil

            await _profileRepository.UpdateProfile(foundProfile); // Llama al nuevo método UpdateProfile
        }

        public async Task EditProfile(AdminEditProfileDto editProfileDto)
        {
            var existingProfile = await _profileRepository.GetProfileById(editProfileDto.Id);

            if (existingProfile == null)
            {
                throw new KeyNotFoundException($"Profile with ID {editProfileDto.Id} not found.");
            }

            _mapper.Map(editProfileDto, existingProfile);

            await _profileRepository.UpdateProfile(existingProfile);
        }

        public async Task EditUserProfile(int userUniqueId, UserEditProfileDto userEditProfileDto)
        {

            var existingProfile = await _profileRepository.GetProfileById(userUniqueId);

            if (existingProfile == null)
            {
                throw new KeyNotFoundException($"Profile not found for user with Unique ID: {userUniqueId}.");
            }

            // Optional: If the DTO includes an ID, you might want to validate it matches the found profile's ID.
            // This adds an extra layer of security to prevent a user from trying to update another user's profile
            // by manipulating the DTO's Id field.
            if (userEditProfileDto.Id != 0 && userEditProfileDto.Id != existingProfile.Id)
            {
                throw new InvalidOperationException("Profile ID in DTO does not match authenticated user's profile ID.");
            }


            // 3. Map changes from DTO to the existing entity
            // AutoMapper will update the properties of 'existingProfile'
            // based on the 'UserEditProfileDto' and the defined mapping rules.
            _mapper.Map(userEditProfileDto, existingProfile);

            // 4. Save changes via the repository
            await _profileRepository.UpdateProfile(existingProfile); // Reusing the UpdateProfile method
        }
    }
}
