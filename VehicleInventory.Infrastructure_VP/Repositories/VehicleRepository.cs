using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleInventory.Application_VP.Interfaces;
using VehicleInventory.Domain_VP.Entites;
using VehicleInventory.Infrastructure_VP.Data;

namespace VehicleInventory.Infrastructure_VP.Repositories
{
    public class VehicleRepository: IVehicleRepository
    {
        private readonly InventoryDbContext _dbContext;

        public VehicleRepository(InventoryDbContext context)
        {
            _dbContext = context;
        }
        public async Task AddAsync(Vehicle vehicle)
        {
            await _dbContext.Vehicles.AddAsync(vehicle);
        }
        public async Task<IEnumerable<Vehicle>> GetAllAsync()
        {
            return await _dbContext.Vehicles.AsNoTracking().ToListAsync();
        }
        public async Task<Vehicle> GetByIdAsync(int id)
        {
            return await _dbContext.Vehicles.FindAsync(id);
        }
        public async Task DeleteAsync(Vehicle vehicle)
        {
            _dbContext.Vehicles.Remove(vehicle);
        }
    }
}
