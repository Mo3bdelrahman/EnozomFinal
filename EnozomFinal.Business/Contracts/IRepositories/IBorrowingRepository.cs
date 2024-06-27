using EnozomFinal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnozomFinal.Application.Contracts.IRepositories
{
    public interface IBorrowingRepository
    {
        Task<StudentCopy> GetBorrowingByIdAsync(int id);
        Task<bool> AddBorrowingAsync(StudentCopy studentCopy);
        Task<bool> UpdateBorrowingAsync(StudentCopy studentCopy);
    }
}
