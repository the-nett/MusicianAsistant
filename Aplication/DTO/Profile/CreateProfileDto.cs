using System.ComponentModel.DataAnnotations;

namespace Application.DTO.Profile
{
    public class CreateProfileDto
    {
        [Required]

        public Guid? StatusInvitationId { get; set; }

        [Required]
        public string FullName { get; set; } = null!;

        [Required]
        public int GenderId { get; set; }

        [Required]
        public DateOnly BirthDate { get; set; }
    }
}
