namespace Aplication.DTO.Profile
{
    public class UserEditProfileDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public DateOnly BirthDate { get; set; }
        public int Gender { get; set; }
    }
}
