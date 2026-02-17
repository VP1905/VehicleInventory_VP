using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleInventory.Application_VP.Services;

namespace VehicleInventory.Application_VP
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(
             this IServiceCollection services)
        {
            // Register application services (use cases)
            services.AddScoped<VehicleService>();

            return services;
        }
    }
}
