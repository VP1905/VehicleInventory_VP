using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleInventory.Domain_VP.Domain.Enums
{
    //Represent the operational lifecycle states of a vehicle.
    public enum VehicleStatus
    {
        //This defines all valid status a vehicle can have.
        Available = 1,
        Reserved = 2,
        Rented = 3,
        Maintenance = 4
    }
}