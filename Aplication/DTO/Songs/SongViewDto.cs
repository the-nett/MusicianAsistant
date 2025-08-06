namespace Aplication.DTO.Songs
{
    public class SongViewDto
    {
        public int SongId { get; set; }
        public required string Name { get; set; }
        public int CreatedBy { get; set; }
        public string CreatorName { get; set; } = string.Empty; 
        public DateTime CreatedAt { get; set; }
    }
}
