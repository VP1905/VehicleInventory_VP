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
        public string VehicleCode { get; private set; }
        public int LocationId { get; private set; }
        public VehicleType VehicleType { get; private set; }
        public VehicleStatus Status { get; private set; }

        private Vehicle() { } // EF Core

        public Vehicle(string vehicleCode, int locationId, VehicleType vehicleType)
        {
            VehicleCode = vehicleCode;
            LocationId = locationId;
            VehicleType = vehicleType;
            Status = VehicleStatus.Available;
        }

        public void MarkAvailable()
        {
            if (Status == VehicleStatus.Reserved)
                throw new InvalidOperationException("Reserved vehicle cannot be made available directly.");

            Status = VehicleStatus.Available;
        }

        public void MarkRented()
        {
            if (Status != VehicleStatus.Available)
                throw new InvalidOperationException("Only available vehicles can be rented.");

            Status = VehicleStatus.Rented;
        }

        public void MarkReserved()
        {
            if (Status != VehicleStatus.Available)
                throw new InvalidOperationException("Only available vehicles can be reserved.");

            Status = VehicleStatus.Reserved;
        }

        public void MarkServiced()
        {
            Status = VehicleStatus.Maintenance;
        }
    }

}