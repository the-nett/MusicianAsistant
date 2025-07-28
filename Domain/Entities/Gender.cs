using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Gender
    {
        [Key]
        public int IdGender { get; set; }
        public required string GenderName { get; set; } = string.Empty;
        public ICollection<Profile> Profiles { get; set; } = new List<Profile>();

    }
}
