using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleInventory.Domain_VP.Domain.Enums;

namespace VehicleInventory.Application_VP.DTOs
{
    public class UpdateVehicleStatusDto
    {
        public VehicleStatus Status { get; set; }
    }
}
