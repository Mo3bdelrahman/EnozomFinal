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
    public class StudentCopyConfiguration : IEntityTypeConfiguration<StudentCopy>
    {
        public void Configure(EntityTypeBuilder<StudentCopy> builder)
        {
            builder.Property(e => e.BorrowDate)
                .IsRequired();
            builder.Property(e => e.ExpectedReturnDate)
                .IsRequired();
        }
    }
}
