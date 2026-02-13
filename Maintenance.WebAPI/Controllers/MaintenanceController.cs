using Maintenance.WebAPI.Models;
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
        public IActionResult GetByVehicleId(int vehicleId)
        {
            _logger.LogInformation("Fetching repair history for vehicle {VehicleId}", vehicleId);

            if (vehicleId <= 0)
                return BadRequest("VehicleId must be greater than zero.");

            var result = _service.GetByVehicleId(vehicleId);

            if (result == null || result.Count == 0)
                return NotFound("No repair history found for this vehicle.");

            return Ok(result);
        }

        [HttpPost("vehicles/{vehicleId}/repairs")]
        public IActionResult AddRepair(int vehicleId, [FromBody] RepairHistoryDto repair)
        {
            _logger.LogInformation("Adding repair record for vehicle {VehicleId}", vehicleId);

            if (vehicleId <= 0)
                return BadRequest("Invalid vehicleId.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            repair.VehicleId = vehicleId;

            _service.AddRepair(repair);

            return CreatedAtAction(nameof(GetByVehicleId), new { vehicleId = vehicleId }, repair);
        }

        [HttpPut("repairs/{id}")]
        public IActionResult UpdateRepair(int id, [FromBody] RepairHistoryDto repair)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _service.UpdateRepair(id, repair);

            return NoContent();
        }

        [HttpDelete("repairs/{id}")]
        public IActionResult DeleteRepair(int id)
        {
            _service.DeleteRepair(id);
            return NoContent();
        }


    }
}


