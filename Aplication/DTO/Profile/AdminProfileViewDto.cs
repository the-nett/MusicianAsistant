namespace Aplication.DTO.Profile
{
    public class AdminProfileViewDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public DateOnly BirthDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }

        public string Role { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
    }
}
