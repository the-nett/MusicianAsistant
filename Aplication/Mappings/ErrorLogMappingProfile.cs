using Aplication.DTO.ErrorLogs;
using Domain.Entities;

namespace Aplication.Mappings
{
    public class ErrorLogMappingProfile : AutoMapper.Profile
    {
        public ErrorLogMappingProfile()
        {
            // Mapeo para la creación de ErrorLogs
            CreateMap<CreateErrorLogDto, ErrorLogs>()
                .ForMember(dest => dest.IdError, opt => opt.Ignore()) // Ignora el IdError al crear
                .ForMember(dest => dest.created_at, opt => opt.MapFrom(src => DateTime.UtcNow)); // Asigna la fecha actual

            CreateMap<ErrorLogs, ErrorLogDto>()
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.created_at))
            .ForMember(dest => dest.Message, opt => opt.MapFrom(src => src.message))
            .ForMember(dest => dest.StackTrace, opt => opt.MapFrom(src => src.stack_trace))
            .ForMember(dest => dest.ContextInfo, opt => opt.MapFrom(src => src.context_info))
            .ForMember(dest => dest.IdUser, opt => opt.MapFrom(src => src.id_user));
        }
    }
}
