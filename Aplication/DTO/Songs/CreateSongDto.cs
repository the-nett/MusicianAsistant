using System.ComponentModel.DataAnnotations;

namespace Aplication.DTO.Songs
{
    public class CreateSongDto
    {
        [Required(ErrorMessage = "Song name is required.")]
        [StringLength(100, ErrorMessage = "Song name cannot exceed 100 characters.")]
        public required string Name { get; set; }
    }
}
