using AOIS2.Core.Mapping;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOIS2.Core.Extensions
{
    public static class MapperDependencyResolver
    {
        public static void AddMapper(this IServiceCollection services)
        {
            MapperConfiguration mappingConfig = new MapperConfiguration(mc =>
                    mc.AddProfile(new MappingProfile())
            );
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
