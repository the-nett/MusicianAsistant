using Aplication.DTO.Songs;
using Domain.Entities;

namespace Aplication.Mappings
{
    public class SongMappingProfile : AutoMapper.Profile
    {
        public SongMappingProfile()
        {
            // Create DTO to Entity
            CreateMap<CreateSongDto, Song>();

            // Entity to View DTO
            CreateMap<Song, SongViewDto>()
                .ForMember(dest => dest.CreatorName, opt => opt.MapFrom(src => src.Creator != null ? src.Creator.FullName : "Unknown Creator"));

            // Update DTO to Entity
            CreateMap<UpdateSongDto, Song>()
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore()) // The creator should not be changed by the update
                .ForMember(dest => dest.Creator, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore());
        }
    }
}
