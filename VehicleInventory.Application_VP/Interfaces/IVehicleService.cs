using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleInventory.Application_VP.DTOs;
using VehicleInventory.Domain_VP.AggregatesModel.VehicleAggregate;

namespace VehicleInventory.Application_VP.Interfaces
{
    public interface IVehicleService
    {
        Task<VehicleDto> CreateVehicleAsync(CreateVehicleDto dto);
        Task<VehicleDto?> GetVehicleByIdAsync(int id);
        Task<List<VehicleDto>> GetAllVehiclesAsync();
        Task<bool> UpdateVehicleStatusAsync(int id, UpdateVehicleStatusDto dto);
        Task<bool> DeleteVehicleAsync(int id);
    }
}