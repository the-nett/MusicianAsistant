using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Persistence.Configurations
{
    public class SongVersionInstrumentTextConfiguration : IEntityTypeConfiguration<SongVersionInstrumentText>
    {
        public void Configure(EntityTypeBuilder<SongVersionInstrumentText> builder)
        {
            builder.HasKey(svit => svit.TextId); // PK: TextId

            builder.Property(svit => svit.VersionId).IsRequired();
            builder.Property(svit => svit.InstrumentId).IsRequired();
            builder.Property(svit => svit.UploadedBy).IsRequired();
            builder.Property(svit => svit.Content).IsRequired();
            builder.Property(svit => svit.CreatedAt).IsRequired();

            builder.HasOne(svit => svit.Version)
                   .WithMany(sv => sv.SongVersionInstrumentTexts)
                   .HasForeignKey(svit => svit.VersionId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(svit => svit.Instrument)
                   .WithMany(i => i.SongVersionInstrumentTexts)
                   .HasForeignKey(svit => svit.InstrumentId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(svit => svit.Uploader)
                   .WithMany(p => p.SongVersionInstrumentTexts)
                   .HasForeignKey(svit => svit.UploadedBy)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
