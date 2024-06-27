using AutoMapper;
using EnozomFinal.Application.Models;
using EnozomFinal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnozomFinal.Application.Profiles
{
    public class ReportProfile : Profile
    {
        public ReportProfile()
        {
            CreateMap<Copy, ReportDto>()
                .ForMember(dest => dest.BookName, src => src.MapFrom(src => src.Book.Name))
                .ForMember(dest => dest.Status, src => src.MapFrom(src => src.CopyStatus.Name));
        }
    }
}
