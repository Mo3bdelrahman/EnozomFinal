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
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(e => e.Email)
                 .HasMaxLength(50);
            builder.Property(e => e.StNumber)
                 .HasMaxLength(50);
            builder.Property(e => e.PhoneNumber)
                 .HasMaxLength(50);
            builder.Property(e => e.Name)
                 .HasMaxLength(50);
        }
    }
}
