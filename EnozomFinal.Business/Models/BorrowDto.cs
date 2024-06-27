using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnozomFinal.Application.Models
{
    public class BorrowDto
    {
        public int StudentId { get; set; }
        public int CopyId { get; set; }
        public DateTime ExpectedReturnDate { get; set; }
    }
}
