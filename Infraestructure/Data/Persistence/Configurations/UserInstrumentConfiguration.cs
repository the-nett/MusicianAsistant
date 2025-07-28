using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Persistence.Configurations
{
    public class UserInstrumentConfiguration : IEntityTypeConfiguration<UserInstrument>
    {
        public void Configure(EntityTypeBuilder<UserInstrument> builder)
        {
            // Clave compuesta
            builder.HasKey(ui => new { ui.UserId, ui.InstrumentId });

            builder.Property(ui => ui.UserId).IsRequired();
            builder.Property(ui => ui.InstrumentId).IsRequired();

            // Relaciones
            builder.HasOne(ui => ui.User)
                   .WithMany(p => p.UserInstruments)
                   .HasForeignKey(ui => ui.UserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ui => ui.Instrument)
                   .WithMany(i => i.UserInstruments)
                   .HasForeignKey(ui => ui.InstrumentId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
