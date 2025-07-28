using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Persistence.Configurations
{
    public class SongConfiguration : IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> builder)
        {
            builder.HasKey(s => s.SongId); // PK: SongId
            builder.Property(s => s.Name).IsRequired();
            builder.Property(s => s.CreatedBy).IsRequired();
            builder.Property(s => s.CreatedAt).IsRequired();

            builder.HasOne(s => s.Creator)
                   .WithMany(p => p.Songs)
                   .HasForeignKey(s => s.CreatedBy)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
