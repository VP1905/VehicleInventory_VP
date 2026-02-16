using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleInventory.Domain_VP.Entites;

namespace VehicleInventory.Application_VP.Interfaces
{
    public interface IVehicleRepository
    {
        Task AddAsync(Vehicle vehicle);
        Task<Vehicle?> GetByIdAsync(int id);
        Task<IEnumerable<Vehicle>> GetAllAsync();
        Task DeleteAsync(Vehicle vehicle);
        Task SaveChangesAsync();
    }
}