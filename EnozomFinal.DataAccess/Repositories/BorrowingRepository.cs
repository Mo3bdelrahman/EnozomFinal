using EnozomFinal.Application.Contracts.IRepositories;
using EnozomFinal.Domain.Entities;
using EnozomFinal.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnozomFinal.Persistence.Repositories
{
    public class BorrowingRepository : IBorrowingRepository
    {
        private readonly EnozomFinalContext _context;
        public BorrowingRepository(EnozomFinalContext context)
        {
            _context = context;
        }
        public async Task<bool> AddBorrowingAsync(StudentCopy studentCopy)
        {
            await _context.AddAsync(studentCopy);   
             return await _context.SaveChangesAsync() > 0;
        }

        public async Task<StudentCopy> GetBorrowingByIdAsync(int id)
        {
            return await _context.StudentSCopies.FindAsync(id);
        }

        public async Task<bool> UpdateBorrowingAsync(StudentCopy studentCopy)
        {
            _context.StudentSCopies.Update(studentCopy);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
