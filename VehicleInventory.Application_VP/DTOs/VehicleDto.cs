using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleInventory.Domain_VP.Domain.Enums;

namespace VehicleInventory.Application_VP.DTOs
{
    public class VehicleDto
    {
        public int Id { get; set; }
        public string VehicleCode { get; set; } = string.Empty;
        public int LocationId { get; set; }
        public VehicleType VehicleType { get; set; }
        public VehicleStatus Status { get; set; }
    }
}
