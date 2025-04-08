using Application.DTO.Profile;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class ProfileMappingProfile : AutoMapper.Profile
    {
        public ProfileMappingProfile()
        {
           CreateMap<CreateProfileDto, Domain.Entities.Profile>();
        }
    }
}

