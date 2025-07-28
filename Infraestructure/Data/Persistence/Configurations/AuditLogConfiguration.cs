using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Persistence.Configurations
{
    public class AuditLogConfiguration : IEntityTypeConfiguration<AuditLog>
    {
        public void Configure(EntityTypeBuilder<AuditLog> builder)
        {
            builder.HasKey(al => al.AuditId); // PK: AuditId

            builder.Property(al => al.UserId).IsRequired();
            builder.Property(al => al.ActionTypeId).IsRequired();
            builder.Property(al => al.EntityType).IsRequired(); // Es required en la entidad
            builder.Property(al => al.Timestamp).IsRequired();

            // Relación con ActionType
            builder.HasOne(al => al.ActionType)
                   .WithMany() // No hay colección inversa en ActionType
                   .HasForeignKey(al => al.ActionTypeId)
                   .OnDelete(DeleteBehavior.Restrict); // Comportamiento por defecto

            // Nota: La propiedad de navegación 'User' está comentada en la entidad AuditLog,
            // por lo que no se configura una relación explícita aquí con Profile.
            // Si necesitas esta relación en el futuro, deberías descomentar 'public Profile? User { get; set; }'
            // en la entidad AuditLog y luego añadir su configuración aquí.
        }
    }
}
