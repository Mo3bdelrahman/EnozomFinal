using EnozomFinal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace EnozomFinal.Persistence.Configurations
{
    public class CopyConfiguration : IEntityTypeConfiguration<Copy>
    {
        public void Configure(EntityTypeBuilder<Copy> builder)
        {
            builder.Property(e => e.CopyStatusId)
                .HasDefaultValue(1);
        }
    }
}
