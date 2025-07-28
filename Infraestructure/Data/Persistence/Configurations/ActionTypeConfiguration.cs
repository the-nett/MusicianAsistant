using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Persistence.Configurations
{
    public class ActionTypeConfiguration : IEntityTypeConfiguration<ActionType>
    {
        public void Configure(EntityTypeBuilder<ActionType> builder)
        {
            builder.HasKey(at => at.ActionTypeId); // PK: ActionTypeId
            builder.Property(at => at.Name).IsRequired();
            builder.Property(at => at.Description).IsRequired();
        }
    }
}
