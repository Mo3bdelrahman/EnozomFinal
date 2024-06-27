using EnozomFinal.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnozomFinal.Persistence
{
    public static class PersistenceServiceResgistration
    {

        public static IServiceCollection AddPersistanceService(this IServiceCollection services,IConfiguration configuration)
        {
            //add dbcontext and repositories 
            services.AddDbContext<EnozomFinalContext>(options =>
                options.UseMySQL(configuration["ConnectionString"]!)
            );

            return services;
        }

    }
}
