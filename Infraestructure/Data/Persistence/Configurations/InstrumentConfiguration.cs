using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure.Data.Persistence.Configurations
{
    public class InstrumentConfiguration : IEntityTypeConfiguration<Instrument>
    {
        public void Configure(EntityTypeBuilder<Instrument> builder)
        {
            builder.HasKey(i => i.InstrumentId); // PK: InstrumentId
            builder.Property(i => i.NameInstrument).IsRequired(); // NameInstrument es required en la entidad

            // Seed Data
            builder.HasData(
                new Instrument { InstrumentId = 1, NameInstrument = "Trompeta" },
                new Instrument { InstrumentId = 2, NameInstrument = "Guitarra" },
                new Instrument { InstrumentId = 3, NameInstrument = "Bateria" },
                new Instrument { InstrumentId = 4, NameInstrument = "Otro" }
            );
        }
    }
}
