using Aplication.DTO.Gender;
using Aplication.Services.Interface;
using Application.DTO.Profile;
using AutoMapper;
using Domain.Entities;
using System;
using System.Security.Cryptography;
namespace Aplication.Services.Implementation
{
    public class GenderService : IGenderService
    {
        private readonly IGenderRepository _genderRepository;
        private readonly IMapper _mapper;

        public GenderService(IGenderRepository genderRepository, IMapper mapper)
        {
            _genderRepository = genderRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetGenderDto>> GetAllGenders()
        {
            var gender = await _genderRepository.GetAllGenders();
            return _mapper.Map<IEnumerable<GetGenderDto>>(gender);
        }
        //public async Task<Domain.Entities.Profile> VerifyUser(string userUid)
        //{
        //    return await _profileRepository.VerifyUser(userUid);
        //}
        //public async Task AddProfile(CreateProfileDto Createprofile, string uid)
        //{
        //    var profile = _mapper.Map<Domain.Entities.Profile>(Createprofile);
        //    profile.UserUniqueId = uid;
        //    await _profileRepository.AddProfile(profile);

        //}
    }
}
