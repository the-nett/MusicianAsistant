using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Song
    {
        [Key]
        public int SongId { get; set; }
        public required string Name { get; set; } = string.Empty;
        public required int CreatedBy { get; set; }
        public Profile Creator { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<SongVersion> Versions { get; set; }
    }

}
