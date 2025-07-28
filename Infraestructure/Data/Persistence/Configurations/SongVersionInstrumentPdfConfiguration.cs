using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Persistence.Configurations
{
    public class SongVersionInstrumentPdfConfiguration : IEntityTypeConfiguration<SongVersionInstrumentPdf>
    {
        public void Configure(EntityTypeBuilder<SongVersionInstrumentPdf> builder)
        {
            builder.HasKey(svip => svip.PdfId); // PK: PdfId

            builder.Property(svip => svip.VersionId).IsRequired();
            builder.Property(svip => svip.InstrumentId).IsRequired();
            builder.Property(svip => svip.UploadedBy).IsRequired();
            builder.Property(svip => svip.FilePath).IsRequired();
            builder.Property(svip => svip.FileName).IsRequired();
            builder.Property(svip => svip.CreatedAt).IsRequired();
            builder.Property(svip => svip.IsShared).IsRequired();

            builder.HasOne(svip => svip.Version)
                   .WithMany(sv => sv.SongVersionInstrumentPdfs)
                   .HasForeignKey(svip => svip.VersionId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(svip => svip.Instrument)
                   .WithMany(i => i.SongVersionInstrumentPdfs)
                   .HasForeignKey(svip => svip.InstrumentId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(svip => svip.Uploader)
                   .WithMany(p => p.SongVersionInstrumentPdfs)
                   .HasForeignKey(svip => svip.UploadedBy)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
