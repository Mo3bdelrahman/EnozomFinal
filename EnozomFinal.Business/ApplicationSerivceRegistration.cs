using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnozomFinal.Application.Contracts.IServices;
using EnozomFinal.Application.Services;
using EnozomFinal.Application.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;


namespace EnozomFinal.Application
{
    public static class ApplicationSerivceRegistration
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            // add mappers, validators,middelwares and services
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddValidatorsFromAssemblyContaining(typeof(BorrowDtoValidator));

            services.AddScoped<IReportService, ReportService>();
            services.AddScoped<IBorrowingService,BorrowingService>();

            return services;

        }
    }
}
