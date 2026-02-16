using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleInventory.Application_VP.DTOs
{
    public class CreateVehicleDto
    {
        public string Make { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int VehicleTypeId { get; set; }
        public int LocationId { get; set; }
    }
}
