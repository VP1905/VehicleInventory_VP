using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace VehicleInventory.Application_VP.DTOs
{
    //Data Transfer Object used when creating a new vehicle.
    public class CreateVehicleDto
    {
        [Required]
        public string VehicleCode { get; set; } = string.Empty;

        [Required]
        public int VehicleTypeId { get; set; }

        [Required]
        public int LocationId { get; set; }
    }
}