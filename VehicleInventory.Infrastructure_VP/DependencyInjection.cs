using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;
using VehicleInventory.Application_VP.Interfaces;
using VehicleInventory.Infrastructure_VP.Data;
using VehicleInventory.Infrastructure_VP.Repositories;

namespace VehicleInventory.Infrastructure_VP
{
    public static class DependencyInjection
    {
        //Registers database context and repository implementations
        //The IServiceCollection used to resigster application services.
        public static IServiceCollection AddInfrastruture(
            this IServiceCollection services,
            string connectionString)
        {
            //Configured to use SQL Server with the provided connection string
            services.AddDbContext<InventoryDbContext>(options => options.UseSqlServer(connectionString));
            
            //Register the Vehicle repository
            services.AddScoped<IVehicleRepository, VehicleRepository>();
            
            //Return the service collection
            return services;
        }

    }
}