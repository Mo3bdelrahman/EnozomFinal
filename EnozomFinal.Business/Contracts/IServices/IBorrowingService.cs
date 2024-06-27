using EnozomFinal.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnozomFinal.Application.Contracts.IServices
{
    public interface IBorrowingService
    {
        Task<string> BorrowBookCopy(BorrowDto borrowDto);
        Task<string> ReturnBookCopy(ReturnDto returnDto);
    }
}
