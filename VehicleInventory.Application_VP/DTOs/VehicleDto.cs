using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleInventory.Domain_VP.Domain.Enums;

namespace VehicleInventory.Application_VP.DTOs
{
    //DTO used to send vehicle information from the application layer to the API response
    public class VehicleDto
    {
        public int Id { get; set; }
        public string VehicleCode { get; set; } = string.Empty;
        public int LocationId { get; set; }
        public string VehicleType { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}