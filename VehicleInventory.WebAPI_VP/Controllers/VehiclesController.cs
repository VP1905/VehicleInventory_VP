using Microsoft.AspNetCore.Mvc;
using VehicleInventory.Application_VP.Services;
using VehicleInventory.Application_VP.DTOs;

namespace VehicleInventory.WebAPI_VP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        //Register Application service in the controller
        private readonly VehicleService _vehicleService;

        public VehiclesController(VehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }
        // GET /api/vehicles
        [HttpGet]
        public async Task<IActionResult> GetAllVehicles()
        {
            return Ok(await _vehicleService.GetAllVehiclesAsync());
        }

        // GET /api/vehicles/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicleById(int id)
        {
            return Ok(await _vehicleService.GetVehicleByIdAsync(id));
        }

        // POST /api/vehicles
        [HttpPost]
        public async Task<IActionResult> CreateVehicle(CreateVehicleDto dto)
        {
            await _vehicleService.CreateVehicleAsync(dto);
            return Ok();
        }

        // PUT /api/vehicles/{id}/status
        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateVehicleStatus(
            int id,
            UpdateVehicleStatusDto dto)
        {
            await _vehicleService.UpdateVehicleStatusAsync(id, dto.Status);
            return NoContent();
        }

        // DELETE /api/vehicles/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            await _vehicleService.DeleteVehicleAsync(id);
            return NoContent();
        }
    }
}