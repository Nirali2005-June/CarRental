using Maintenance.WebAPI.Models;
using System.Threading.Tasks;
using Maintenance.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Maintenance.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MaintenanceController : ControllerBase
    {
        private readonly IRepairHistoryService _service;

        private readonly ILogger<MaintenanceController> _logger;

        public MaintenanceController(
        IRepairHistoryService service,
        ILogger<MaintenanceController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet("vehicles/{vehicleId}/repairs")]
        public async Task<IActionResult> GetByVehicleId(int vehicleId)
        {
            if (vehicleId <= 0)
                return BadRequest("VehicleId must be greater than zero.");

            var result = await _service.GetByVehicleIdAsync(vehicleId);

            if (result == null || result.Count == 0)
                return NotFound("No repair history found for this vehicle.");

            return Ok(result);
        }

        [HttpPost("vehicles/{vehicleId}/repairs")]
        public async Task<IActionResult> AddRepair(int vehicleId, [FromBody] RepairHistoryDto repair)
        {
            if (vehicleId <= 0)
                return BadRequest("Invalid vehicleId.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            repair.VehicleId = vehicleId;

            await _service.AddRepairAsync(repair);

            return CreatedAtAction(nameof(GetByVehicleId), new { vehicleId = vehicleId }, repair);
        }

        [HttpPut("repairs/{id}")]
        public async Task<IActionResult> UpdateRepair(int id, [FromBody] RepairHistoryDto repair)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _service.UpdateRepairAsync(id, repair);

            if (!updated)
                return NotFound($"Repair with id {id} not found.");

            return NoContent();
        }

        [HttpDelete("repairs/{id}")]
        public async Task<IActionResult> DeleteRepair(int id)
        {
            var deleted = await _service.DeleteRepairAsync(id);

            if (!deleted)
                return NotFound($"Repair with id {id} not found.");

            return NoContent();
        }



    }
}


