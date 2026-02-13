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

        public MaintenanceController(IRepairHistoryService service)
        {
            _service = service;
        }

        [HttpGet("vehicles/{vehicleId}/repairs")]
        public IActionResult GetByVehicleId(int vehicleId)
        {
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
            if (vehicleId <= 0)
                return BadRequest("Invalid vehicleId.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            repair.VehicleId = vehicleId;

            _service.AddRepair(repair);

            return CreatedAtAction(nameof(GetByVehicleId), new { vehicleId = vehicleId }, repair);
        }


    }
}


