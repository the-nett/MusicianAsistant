using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Persistence.Configurations
{
    public class SongVersionAudioConfiguration : IEntityTypeConfiguration<SongVersionAudio>
    {
        public void Configure(EntityTypeBuilder<SongVersionAudio> builder)
        {
            builder.HasKey(sva => sva.AudioId); // PK: AudioId

            builder.Property(sva => sva.VersionId).IsRequired();
            builder.Property(sva => sva.AudioUrl).IsRequired();
            builder.Property(sva => sva.CreatedAt).IsRequired();

            // Version puede ser nula
            builder.HasOne(sva => sva.Version)
                   .WithMany(sv => sv.SongVersionAudios)
                   .HasForeignKey(sva => sva.VersionId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Uploader puede ser nulo
            builder.HasOne(sva => sva.Uploader)
                   .WithMany(p => p.SongVersionAudios)
                   .HasForeignKey(sva => sva.UploadedBy)
                   .IsRequired(false) // Permite que UploadedBy sea nulo
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
