using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class SongVersionInstrumentText
    {
        [Key]
        public int TextId { get; set; }

        [Required]
        public int VersionId { get; set; }

        [Required]
        public int InstrumentId { get; set; }

        [Required]
        public int UploadedBy { get; set; }

        [Required]
        public string Content { get; set; } = string.Empty;

        public string? Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Relaciones de navegación
        public SongVersion Version { get; set; } = null!;
        public Instrument Instrument { get; set; } = null!;
        public Profile Uploader { get; set; } = null!;
    }

}
