using EnozomFinal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnozomFinal.Application.Contracts.IRepositories
{
    public interface ICopyRepository
    {
        Task<List<Copy>> GetAllCopiesWithBookAndStatusAsync();
        Task<bool> UpdateCopyAsync(Copy copy);
        Task<Copy> GetCopyWithStatusByIdAsync(int id);
    }
}
