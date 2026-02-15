using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleInventory.Domain_VP.Domain.Enums;
using VehicleInventory.Domain_VP.Exceptions;

namespace VehicleInventory.Domain_VP.Entites
{
    public class Vehicle
    {
        public int Id { get; private set; }
        public string Make { get; private set; }      
        public string Model { get; private set; }     
        public VehicleType VehicleType { get; private set; } 
        public int LocationId { get; private set; }   
        public VehicleStatus Status { get; private set; } 
        public DateTime LastUpdated { get; private set; }
        
        private Vehicle() { }

        public Vehicle(
            string make,
            string model,
            VehicleType vehicleType,
            int locationId)
        {
            if (string.IsNullOrWhiteSpace(make))
                throw new DomainException("Vehicle make is required.");

            if (string.IsNullOrWhiteSpace(model))
                throw new DomainException("Vehicle model is required.");

            if (locationId <= 0)
                throw new DomainException("Invalid vehicle location.");

            Make = make;
            Model = model;
            VehicleType = vehicleType;
            LocationId = locationId;

            Status = VehicleStatus.Available;
            LastUpdated = DateTime.UtcNow;
        }


        public void MarkAvailable()
        {
            if (Status == VehicleStatus.Reserved)
                throw new DomainException("Reserved vehicle must be explicitly released.");

            Status = VehicleStatus.Available;
            LastUpdated = DateTime.UtcNow;
        }

        public void MarkReserved()
        {
            if (Status != VehicleStatus.Available)
                throw new DomainException("Only available vehicles can be reserved.");

            Status = VehicleStatus.Reserved;
            LastUpdated = DateTime.UtcNow;
        }

        public void MarkRented()
        {
            if (Status == VehicleStatus.Rented)
                throw new DomainException("Vehicle is already rented.");

            if (Status == VehicleStatus.Reserved || Status == VehicleStatus.Maintenance)
                throw new DomainException("Vehicle cannot be rented in its current state.");

            Status = VehicleStatus.Rented;
            LastUpdated = DateTime.UtcNow;
        }

        public void SendToMaintenance()
        {
            Status = VehicleStatus.Maintenance;
            LastUpdated = DateTime.UtcNow;
        }
    }
}