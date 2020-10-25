using AOIS2.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOIS2.Data.Extensions
{
    public static class ContextDependencyResolver
    {
        public static void AddContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataStorageContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DataStorageContext"),
                b => b.MigrationsAssembly("AOIS2.Data"));
                options.EnableDetailedErrors();
            });
        }
    }
}
