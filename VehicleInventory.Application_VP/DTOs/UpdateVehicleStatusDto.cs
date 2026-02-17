using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleInventory.Domain_VP.Domain.Enums;

namespace VehicleInventory.Application_VP.DTOs
{
    // Data Transfer Object used to update the status of an existing vehicle.
    public class UpdateVehicleStatusDto
    {
        [Required]
        public VehicleStatus Status { get; set; }
    }
}
