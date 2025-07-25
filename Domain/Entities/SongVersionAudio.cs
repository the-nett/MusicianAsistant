using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class SongVersionAudio
    {
        [Key]
        public int AudioId { get; set; }

        [Required]
        public int VersionId { get; set; }

        public int? UploadedBy { get; set; }

        [Required]
        public string AudioUrl { get; set; } = string.Empty;

        public string? Title { get; set; }

        public string? Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Propiedades de navegación (opcional si las usas)
        public SongVersion? Version { get; set; }
        public Profile? Uploader { get; set; }
    }
}
