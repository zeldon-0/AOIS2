using AOIS2.Core.Repositories.Contracts;
using AOIS2.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOIS2.Data.Extensions
{
    public static class RepositoryDependencyResolver
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IKanjiRepository, KanjiRepository>();
            services.AddScoped<IRadicalRepository, RadicalRepository>();
        }
    }
}
