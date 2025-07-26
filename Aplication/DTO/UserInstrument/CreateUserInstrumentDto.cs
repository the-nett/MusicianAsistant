using System.ComponentModel.DataAnnotations;

namespace Aplication.DTO.UserInstrument
{
    public class CreateUserInstrumentDto
    {
        [Required(ErrorMessage = "User ID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "User ID must be a positive integer.")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Instrument ID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Instrument ID must be a positive integer.")]
        public int InstrumentId { get; set; }
    }
}
