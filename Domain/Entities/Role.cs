namespace Domain.Entities
{
    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; } = null!;

        // Propiedad de navegación
        public ICollection<Profile> Profiles { get; set; } = new List<Profile>();
    }
}
