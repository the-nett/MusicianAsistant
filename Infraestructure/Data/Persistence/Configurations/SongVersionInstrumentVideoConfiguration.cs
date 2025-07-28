using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Persistence.Configurations
{
    public class SongVersionInstrumentVideoConfiguration : IEntityTypeConfiguration<SongVersionInstrumentVideo>
    {
        public void Configure(EntityTypeBuilder<SongVersionInstrumentVideo> builder)
        {
            builder.HasKey(sviv => sviv.VideoId); // PK: VideoId

            builder.Property(sviv => sviv.VideoName).IsRequired();
            builder.Property(sviv => sviv.VersionId).IsRequired();
            builder.Property(sviv => sviv.InstrumentId).IsRequired();
            builder.Property(sviv => sviv.UploadedBy).IsRequired();
            builder.Property(sviv => sviv.VideoUrl).IsRequired();
            builder.Property(sviv => sviv.CreatedAt).IsRequired();
            builder.Property(sviv => sviv.IsShared).IsRequired();

            builder.HasOne(sviv => sviv.Version)
                   .WithMany(sv => sv.SongVersionInstrumentVideos)
                   .HasForeignKey(sviv => sviv.VersionId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(sviv => sviv.Instrument)
                   .WithMany(i => i.SongVersionInstrumentVideos)
                   .HasForeignKey(sviv => sviv.InstrumentId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(sviv => sviv.Uploader)
                   .WithMany(p => p.SongVersionInstrumentVideos)
                   .HasForeignKey(sviv => sviv.UploadedBy)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
