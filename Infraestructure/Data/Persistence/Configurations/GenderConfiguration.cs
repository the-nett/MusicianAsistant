using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Persistence.Configurations
{
    public class GenderConfiguration : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder.HasKey(g => g.IdGender); // PK: IdGender
            builder.Property(g => g.GenderName).IsRequired();

            builder.HasMany(g => g.Profiles)
                   .WithOne(p => p.gender)
                   .HasForeignKey(p => p.GenderId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Seed Data
            builder.HasData(
                new Gender { IdGender = 1, GenderName = "Masculino" },
                new Gender { IdGender = 2, GenderName = "Femenino" },
                new Gender { IdGender = 3, GenderName = "Otro" }
            );
        }
    }
}
