using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleInventory.Application_VP.DTOs;
using VehicleInventory.Application_VP.Interfaces;
using VehicleInventory.Domain_VP.Domain.Enums;
using VehicleInventory.Domain_VP.Entites;

namespace VehicleInventory.Application_VP.Services
{
    public class VehicleService
    {
        private readonly IVehicleRepository _repository;

        public VehicleService(IVehicleRepository repository)
        {
            _repository = repository;
        }

        // CREATE
        public async Task<int> CreateVehicleAsync(CreateVehicleDto dto)
        {
            var vehicle = new Vehicle(
                dto.Make,
                dto.Model,
                (VehicleType)dto.VehicleTypeId,
                dto.LocationId);

            await _repository.AddAsync(vehicle);
            await _repository.SaveChangesAsync();

            return vehicle.Id;
        }

        // READ (ALL)
        public async Task<IEnumerable<VehicleDto>> GetAllVehiclesAsync()
        {
            var vehicles = await _repository.GetAllAsync();
            return vehicles.Select(MapToDto);
        }

        // READ (BY ID)
        public async Task<VehicleDto?> GetVehicleByIdAsync(int id)
        {
            var vehicle = await _repository.GetByIdAsync(id);
            return vehicle == null ? null : MapToDto(vehicle);
        }

        // UPDATE STATUS
        public async Task UpdateVehicleStatusAsync(int id, VehicleStatus status)
        {
            var vehicle = await _repository.GetByIdAsync(id)
                ?? throw new Exception("Vehicle not found");

            switch (status)
            {
                case VehicleStatus.Available:
                    vehicle.MarkAvailable();
                    break;
                case VehicleStatus.Reserved:
                    vehicle.MarkReserved();
                    break;
                case VehicleStatus.Rented:
                    vehicle.MarkRented();
                    break;
                case VehicleStatus.Maintenance:
                    vehicle.SendToMaintenance();
                    break;
            }

            await _repository.SaveChangesAsync();
        }

        // DELETE
        public async Task DeleteVehicleAsync(int id)
        {
            var vehicle = await _repository.GetByIdAsync(id)
                ?? throw new Exception("Vehicle not found");

            await _repository.DeleteAsync(vehicle);
            await _repository.SaveChangesAsync();
        }

        private static VehicleDto MapToDto(Vehicle vehicle)
        {
            return new VehicleDto
            {
                Id = vehicle.Id,
                Make = vehicle.Make,
                Model = vehicle.Model,
                VehicleType = vehicle.VehicleType,
                LocationId = vehicle.LocationId,
                Status = vehicle.Status
            };
        }
    }
}
