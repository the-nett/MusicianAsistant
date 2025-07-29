using System.ComponentModel.DataAnnotations;

namespace Aplication.DTO.UserInstrument
{
    public class UserInstrumentCreateDto
    {
        // ID del usuario al que se le asignará el instrumento
        public int UserId { get; set; }
        // ID del instrumento que se asignará al usuario
        public int InstrumentId { get; set; }
    }
}
