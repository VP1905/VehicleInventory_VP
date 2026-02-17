using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace VehicleInventory.Application_VP.DTOs
{
    public class CreateVehicleDto
    {
        public string VehicleCode { get; set; } = string.Empty;
        public int VehicleTypeId { get; set; }
        public int LocationId { get; set; }
    }
}
