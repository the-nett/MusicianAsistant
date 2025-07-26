namespace Aplication.DTO.UserInstrument
{
    public class UserInstrumentViewDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty; // Assuming you want to display the user's name
        public int InstrumentId { get; set; }
        public string InstrumentName { get; set; } = string.Empty; // Assuming you want to display the instrument's name
    }
}
