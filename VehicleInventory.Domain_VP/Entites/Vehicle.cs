using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleInventory.Domain_VP.Domain.Enums;
using VehicleInventory.Domain_VP.Exceptions;

namespace VehicleInventory.Domain_VP.Entites
{
    // Vehicle is the core aggregate root of the Inventory bounded context.
    public class Vehicle
    {
        public int Id { get; private set; }
        public string VehicleCode { get; private set; }
        public int LocationId { get; private set; }
        public VehicleType VehicleType { get; private set; }
        public VehicleStatus Status { get; private set; }

        // Private parameterless constructor required by EF Core
        private Vehicle() { }

        // Creates a new vehicle with the required business properties.
        public Vehicle(string vehicleCode, int locationId, VehicleType vehicleType)
        {
            VehicleCode = vehicleCode;
            LocationId = locationId;
            VehicleType = vehicleType;
            Status = VehicleStatus.Available;
        }

        // Marks the vehicle as available.
        public void MarkAvailable()
        {
            if (Status == VehicleStatus.Reserved)
                throw new InvalidOperationException("Reserved vehicle cannot be made available directly.");

            Status = VehicleStatus.Available;
        }

        // Marks the vehicle as rented.
        public void MarkRented()
        {
            if (Status != VehicleStatus.Available)
                throw new InvalidOperationException("Only available vehicles can be rented.");

            Status = VehicleStatus.Rented;
        }

        // Marks the vehicle as reserved.
        public void MarkReserved()
        {
            if (Status != VehicleStatus.Available)
                throw new InvalidOperationException("Only available vehicles can be reserved.");

            Status = VehicleStatus.Reserved;
        }

        // Marks the vehicle as under maintenance.
        public void MarkServiced()
        {
            Status = VehicleStatus.Maintenance;
        }
    }

}