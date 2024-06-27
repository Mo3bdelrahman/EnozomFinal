using EnozomFinal.Application.Contracts.IRepositories;
using EnozomFinal.Domain.Entities;
using EnozomFinal.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnozomFinal.Persistence.Repositories
{
    public class CopyRepository : ICopyRepository
    {
        private readonly EnozomFinalContext _context;

        public CopyRepository(EnozomFinalContext context)
        {
            _context = context;
        }

        public async Task<List<Copy>> GetAllCopiesWithBookAndStatusAsync()
        {
            return await _context.Copies.Include(e=>e.Book).Include(e=>e.CopyStatus).ToListAsync();
        }

        public async Task<Copy> GetCopyWithStatusByIdAsync(int id)
        {
            return await _context.Copies.FindAsync(id);
        }

        public async Task<bool> UpdateCopyAsync(Copy copy)
        {
            _context.Copies.Update(copy);
            return await _context.SaveChangesAsync() >0;
        }
    }
}
