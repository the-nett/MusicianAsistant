using Aplication.DTO.UserInstrument;
using AutoMapper;

namespace Aplication.Mappings
{
    public class UserInstrumentProfile : Profile
    {
        public UserInstrumentProfile()
        {
            // Mapeo de DTO a Entidad
            CreateMap<UserInstrumentCreateDto, UserInstrument>();

            // Mapeo de Entidad a DTO
            // Configura el mapeo de UserInstrument a UserInstrumentDto.
            // Se mapean las propiedades UserId, InstrumentId directamente.
            // Para UserName e InstrumentName, se utiliza ForMember para acceder
            // a las propiedades de navegación 'User' e 'Instrument' y obtener sus nombres.
            // Se asume que Profile tiene una propiedad 'Name' y Instrument tiene una propiedad 'Name'.
            CreateMap<UserInstrument, UserInstrumentDto>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.FullName))
                .ForMember(dest => dest.InstrumentName, opt => opt.MapFrom(src => src.Instrument.NameInstrument));

        }
    }
}
