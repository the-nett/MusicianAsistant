using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Persistence.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(r => r.RoleId); // PK: RoleId
            builder.Property(r => r.RoleName).IsRequired(); // RoleName es required en la entidad

            builder.HasMany(r => r.Profiles)
                   .WithOne(p => p.Role)
                   .HasForeignKey(p => p.RoleId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Seed Data
            builder.HasData(
                new Role { RoleId = 1, RoleName = "Músico" },
                new Role { RoleId = 2, RoleName = "Administrador" }
            );
        }
    }
}
