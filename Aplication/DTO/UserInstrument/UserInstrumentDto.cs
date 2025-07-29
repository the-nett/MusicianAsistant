namespace Aplication.DTO.UserInstrument
{
    public class UserInstrumentDto
    {
        // ID del usuario
        public int UserId { get; set; }
        // Nombre del usuario (opcional, para facilitar la visualización)
        public string? UserName { get; set; }
        // ID del instrumento
        public int InstrumentId { get; set; }
        // Nombre del instrumento (opcional, para facilitar la visualización)
        public string? InstrumentName { get; set; }
    }
}
