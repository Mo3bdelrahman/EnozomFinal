using AutoMapper;
using EnozomFinal.Application.Contracts.IRepositories;
using EnozomFinal.Application.Contracts.IServices;
using EnozomFinal.Application.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnozomFinal.Application.Services
{
    public class ReportService : IReportService
    {
        private readonly IMapper _mapper;
        private readonly ICopyRepository _copyRepository;

        public ReportService(IMapper mapper, ICopyRepository copyRepository)
        {
            _mapper = mapper;
            _copyRepository = copyRepository;
        }

        public async Task<List<ReportDto>> GetAllCopies()
        {
            var copies = await _copyRepository.GetAllCopiesWithBookAndStatusAsync();
            var result = _mapper.Map<List<ReportDto>>(copies);
            return result;
        }
    }
}
