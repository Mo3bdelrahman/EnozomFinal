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
    public class StudentCopyProfile : Profile
    {
        public StudentCopyProfile()
        {
            CreateMap<BorrowDto, StudentCopy>();
        }
    }
}
