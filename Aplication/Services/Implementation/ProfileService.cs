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

        public async Task<IEnumerable<Domain.Entities.Profile>> GetAllProfiles()
        {
            return await _profileRepository.GetAllProfiles();
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
    }
}
