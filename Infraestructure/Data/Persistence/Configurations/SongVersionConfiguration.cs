using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Persistence.Configurations
{
    public class SongVersionConfiguration : IEntityTypeConfiguration<SongVersion>
    {
        public void Configure(EntityTypeBuilder<SongVersion> builder)
        {
            builder.HasKey(sv => sv.VersionId); // PK: VersionId

            builder.Property(sv => sv.VersionName).IsRequired();
            builder.Property(sv => sv.SongId).IsRequired();
            builder.Property(sv => sv.Album).IsRequired();
            builder.Property(sv => sv.AlbumCoverPath).IsRequired();
            builder.Property(sv => sv.Author).IsRequired();
            builder.Property(sv => sv.Compas).IsRequired();
            builder.Property(sv => sv.Tempo).IsRequired();
            builder.Property(sv => sv.Rhythm).IsRequired();
            builder.Property(sv => sv.CreatedBy).IsRequired();
            builder.Property(sv => sv.IsShared).IsRequired();
            builder.Property(sv => sv.CreatedAt).IsRequired();

            builder.HasOne(sv => sv.Song)
                   .WithMany(s => s.Versions)
                   .HasForeignKey(sv => sv.SongId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(sv => sv.Creator)
                   .WithMany(p => p.SongVersions)
                   .HasForeignKey(sv => sv.CreatedBy)
                   .OnDelete(DeleteBehavior.Restrict);

            // Relación one-to-one con SongVersionPdf
            builder.HasOne(sv => sv.SongVersionn) // Nombre de la propiedad en SongVersion
                   .WithOne(svp => svp.Version) // Nombre de la propiedad en SongVersionPdf
                   .HasForeignKey<SongVersionPdf>(svp => svp.VersionId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
