using AOIS2.Core.Services;
using AOIS2.Core.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOIS2.Core.Extensions
{
    public static class ServicesDependencyResolver
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IDataFetchService, DataFetchService>();
            services.AddScoped<ISearchService, SearchService>();
        }
    }
}
