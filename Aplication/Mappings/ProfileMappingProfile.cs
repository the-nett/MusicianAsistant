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

            //CreateMap<AdminEditProfileDto, Domain.Entities.Profile>()
            //    .ForMember(dest => dest.Id, opt => opt.Ignore()) // ¡Importante! El ID NUNCA se cambia desde el DTO
            //    .ForMember(dest => dest.Role, opt => opt.Ignore()) // Ignorar el mapeo directo de objetos Role, mapearemos RoleId
            //    .ForMember(dest => dest.gender, opt => opt.Ignore()) // Ignorar el mapeo directo de objetos Gender, mapearemos GenderId
            //    .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.Role)) // Mapear Role (int en DTO) a RoleId (int en entidad)
            //    .ForMember(dest => dest.GenderId, opt => opt.MapFrom(src => src.Gender)); // Mapear Gender (int en DTO) a GenderId (int en entidad)

            // Si tu entidad Profile tiene una propiedad UserUniqueId que no está en AdminEditProfileDto
            // y no quieres que se sobreescriba a null o vacío, también deberías ignorarla:
            // .ForMember(dest => dest.UserUniqueId, opt => opt.Ignore());
        
        }
    }
}

