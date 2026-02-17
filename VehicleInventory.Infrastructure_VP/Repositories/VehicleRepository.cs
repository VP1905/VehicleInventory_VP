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
    // This class belongs to the Infrastructure layer and is responsible
    // only for data access logic. It does NOT contain any business rules
    // or domain logic.
    public class VehicleRepository: IVehicleRepository
    {
        // Injects the InventoryDbContext for database access.
        private readonly InventoryDbContext _dbContext;

        public VehicleRepository(InventoryDbContext context)
        {
            _dbContext = context;
        }
        // Adds a new Vehicle aggregate to the database context.
        public async Task AddAsync(Vehicle vehicle)
        {
            await _dbContext.Vehicles.AddAsync(vehicle);
        }
        // Retrieves all vehicles from the database.
        public async Task<IEnumerable<Vehicle>> GetAllAsync()
        {
            return await _dbContext.Vehicles.AsNoTracking().ToListAsync();
        }
        // Retrieves a single Vehicle aggregate by its id.
        public async Task<Vehicle> GetByIdAsync(int id)
        {
            return await _dbContext.Vehicles.FindAsync(id);
        }
        // Removes a Vehicle aggregate from the database context.
        public async Task DeleteAsync(Vehicle vehicle)
        {
            _dbContext.Vehicles.Remove(vehicle);
        }
        // Save changes in the database
        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
