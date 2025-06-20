using Aplication.DTO.Gender;
using Aplication.DTO.Profile;
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
           CreateMap<Gender, GetGenderDto>();
            CreateMap<Domain.Entities.Profile, AdminProfileViewDto>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role != null ? src.Role.RoleName : ""))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.gender != null ? src.gender.GenderName : ""));
        }
    }
}

