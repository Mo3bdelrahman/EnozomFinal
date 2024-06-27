using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnozomFinal.Domain.Entities
{
    public class StudentCopy
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CopyId { get; set; }
        public int CopyStatusId { get; set; }
        public DateOnly BorrowDate { get; set; }
        public DateOnly ExpectedReturnDate { get; set; }
        public DateOnly? ReturnDate { get; set; }

        public Student Student { get; set; }
        public Copy Copy { get; set; }
        public CopyStatus CopyStatus { get; set; }

    }
}
