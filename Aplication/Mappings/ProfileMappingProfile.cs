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
            CreateMap<AdminEditProfileDto, Domain.Entities.Profile>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()) // Do NOT change the ID from the DTO
                .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.Role)) // Map DTO's 'Role' (int) to Entity's 'RoleId' (int)
                .ForMember(dest => dest.GenderId, opt => opt.MapFrom(src => src.Gender)) // Map DTO's 'Gender' (int) to Entity's 'GenderId' (int)
                .ForMember(dest => dest.Role, opt => opt.Ignore()) // Ignore the navigation property 'Role' when mapping from DTO to entity
                .ForMember(dest => dest.gender, opt => opt.Ignore()); // Ignore the navigation property 'gender' when mapping from DTO to entity

            CreateMap<UserEditProfileDto, Domain.Entities.Profile>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()) // ID will come from auth, not DTO
                .ForMember(dest => dest.GenderId, opt => opt.MapFrom(src => src.Gender)) // Map DTO's 'Gender' (int) to Entity's 'GenderId' (int)
                .ForMember(dest => dest.gender, opt => opt.Ignore()) // Ignore navigation property 'gender'
                                                                     // Ensure other fields not in UserEditProfileDto are not accidentally overwritten
                                                                     // by explicitly ignoring them if they should not be updated by the user:
                .ForMember(dest => dest.RoleId, opt => opt.Ignore()) // User cannot change their role
                .ForMember(dest => dest.Role, opt => opt.Ignore()) // Ignore role navigation property
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore()) // User cannot change creation date
                .ForMember(dest => dest.IsActive, opt => opt.Ignore()) // User cannot change active status
                .ForMember(dest => dest.UserUniqueId, opt => opt.Ignore()) // User's UID cannot be changed via profile edit
                                                                           // Also ignore all collection navigation properties to prevent issues
                .ForMember(dest => dest.UserInstruments, opt => opt.Ignore())
                .ForMember(dest => dest.Songs, opt => opt.Ignore())
                .ForMember(dest => dest.SongVersions, opt => opt.Ignore())
                .ForMember(dest => dest.SongVersionPdfs, opt => opt.Ignore())
                .ForMember(dest => dest.SongVersionInstrumentPdfs, opt => opt.Ignore())
                .ForMember(dest => dest.SongVersionInstrumentVideos, opt => opt.Ignore())
                .ForMember(dest => dest.SongVersionInstrumentTexts, opt => opt.Ignore())
                .ForMember(dest => dest.SongVersionAudios, opt => opt.Ignore());
        }

    }
}

