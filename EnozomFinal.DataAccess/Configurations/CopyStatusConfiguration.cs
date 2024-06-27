using EnozomFinal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnozomFinal.Persistence.Configurations
{
    public class CopyStatusConfiguration : IEntityTypeConfiguration<CopyStatus>
    {
        public void Configure(EntityTypeBuilder<CopyStatus> builder)
        {
            builder.Property(e => e.Name)
                .HasMaxLength(50);
        }
    }
}
