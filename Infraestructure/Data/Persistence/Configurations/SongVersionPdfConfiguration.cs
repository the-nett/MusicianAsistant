using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Persistence.Configurations
{
    public class SongVersionPdfConfiguration : IEntityTypeConfiguration<SongVersionPdf>
    {
        public void Configure(EntityTypeBuilder<SongVersionPdf> builder)
        {
            builder.HasKey(svp => svp.PdfId); // PK: PdfId

            builder.Property(svp => svp.VersionId).IsRequired();
            builder.Property(svp => svp.UploadedBy).IsRequired();
            builder.Property(svp => svp.FilePath).IsRequired();
            builder.Property(svp => svp.FileName).IsRequired();
            builder.Property(svp => svp.CreatedAt).IsRequired();
            builder.Property(svp => svp.IsShared).IsRequired();

            // Relación one-to-one con SongVersion ya se configura en SongVersionConfiguration
            builder.HasOne(svp => svp.Uploader)
                   .WithMany(p => p.SongVersionPdfs)
                   .HasForeignKey(svp => svp.UploadedBy)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
