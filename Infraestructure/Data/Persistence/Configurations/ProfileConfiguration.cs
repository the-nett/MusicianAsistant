using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure.Data.Persistence.Configurations
{
    public class ProfileConfiguration : IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            builder.HasKey(p => p.Id); // PK: Id

            builder.Property(p => p.RoleId).IsRequired();
            builder.Property(p => p.UserUniqueId).IsRequired();
            builder.Property(p => p.FullName).IsRequired();
            builder.Property(p => p.GenderId).IsRequired();
            builder.Property(p => p.BirthDate).IsRequired();
            builder.Property(p => p.CreatedAt).IsRequired();
            builder.Property(p => p.IsActive).IsRequired();


            builder.Property(e => e.BirthDate)
                .HasConversion(
                    v => v.ToDateTime(TimeOnly.MinValue),
                    v => DateOnly.FromDateTime(v));

            builder.HasOne(p => p.gender)
                   .WithMany(g => g.Profiles)
                   .HasForeignKey(p => p.GenderId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Role)
                   .WithMany(r => r.Profiles)
                   .HasForeignKey(p => p.RoleId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Seed Data
            builder.HasData(
                new Profile
                {
                    Id = 1,
                    UserUniqueId = "user-unique-001",
                    FullName = "Ricardo Rodriguez",
                    GenderId = 1,
                    BirthDate = new DateOnly(1990, 05, 20),
                    CreatedAt = new DateTime(2025, 04, 07, 12, 0, 0, DateTimeKind.Utc),
                    IsActive = true,
                    RoleId = 2
                },
                new Profile
                {
                    Id = 2,
                    UserUniqueId = "user-unique-002",
                    FullName = "María López",
                    GenderId = 2,
                    BirthDate = new DateOnly(1992, 08, 15),
                    CreatedAt = new DateTime(2025, 04, 07, 12, 0, 0, DateTimeKind.Utc),
                    IsActive = true,
                    RoleId = 2
                },
                new Profile
                {
                    Id = 3,
                    UserUniqueId = "user-unique-003",
                    FullName = "Carlos Martínez",
                    GenderId = 1,
                    BirthDate = new DateOnly(1985, 11, 10),
                    CreatedAt = new DateTime(2025, 04, 07, 12, 0, 0, DateTimeKind.Utc),
                    IsActive = true,
                    RoleId = 1
                }
            );
        }
    }
}
