using System;
using System.Collections.Generic;
using System.Text;
using AOIS2.Data.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AOIS2.Data
{
    public static class DataDependencyResolver
    {
        public static void AddData(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRepositories();
            services.AddContext(configuration);
        }
    }
}
