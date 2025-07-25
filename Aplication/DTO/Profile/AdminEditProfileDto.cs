namespace Aplication.DTO.Profile
{
    public class AdminEditProfileDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public DateOnly BirthDate { get; set; }
        public bool IsActive { get; set; }
        public int Role { get; set; }
        public int Gender { get; set; }
    }
}
