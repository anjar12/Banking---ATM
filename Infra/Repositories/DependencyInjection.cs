using Infra.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddTransient<IMaster, MastersRepository>();
            services.AddTransient<ITransactional, TransactionalRepository>();
            services.AddTransient<IReport, ReportRepository>();
            // Adding the Unit of work to the DI container
            services.AddTransient<IUnitOfWorks, UnitOfWorks>();

            return services;
        }
    }
}
