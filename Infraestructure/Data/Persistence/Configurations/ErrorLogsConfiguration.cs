using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Persistence.Configurations
{
    public class ErrorLogsConfiguration : IEntityTypeConfiguration<ErrorLogs>
    {
        public void Configure(EntityTypeBuilder<ErrorLogs> builder)
        {
            builder.HasKey(el => el.IdError); // PK: IdError

            // Propiedades con nombres no convencionales, se mapean a nombres de columna
            builder.Property(el => el.message).HasColumnName("message").IsRequired();
            builder.Property(el => el.stack_trace).HasColumnName("stack_trace").IsRequired();
            builder.Property(el => el.context_info).HasColumnName("context_info").IsRequired();
            builder.Property(el => el.id_user).HasColumnName("id_user").IsRequired();
            builder.Property(el => el.created_at).HasColumnName("created_at").IsRequired();
        }
    }
}
