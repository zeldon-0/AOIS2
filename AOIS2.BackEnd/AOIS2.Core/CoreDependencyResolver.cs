using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using AOIS2.Core.Extensions;

namespace AOIS2.Core
{
    public static class CoreDependencyResolver
    {
        public static void AddCore(this IServiceCollection services)
        {
            services.AddServices();
            services.AddMapper();
        }
    }
}
