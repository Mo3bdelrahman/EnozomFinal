
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnozomFinal.Domain.Entities
{
    public class Copy
    {
        public int Id { get; set; }
        public  int CopyStatusId { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public CopyStatus CopyStatus { get; set; }
    }
}
