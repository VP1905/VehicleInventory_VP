using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleInventory.Domain_VP.Domain.Enums
{
    public enum VehicleType
    {
        //It is used by the Vehicle aggregate to describe the type of vehicle being managed.
        Sedan = 1,
        SUV = 2,
        Truck = 3,
        Van = 4
    }
}
