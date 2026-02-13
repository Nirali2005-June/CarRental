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
            var result = _service.GetByVehicleId(vehicleId);
            return Ok(result);
        }

        [HttpPost("vehicles/{vehicleId}/repairs")]
        public IActionResult AddRepair(int vehicleId, [FromBody] RepairHistoryDto repair)
        {
            repair.VehicleId = vehicleId;

            _service.AddRepair(repair);

            return Ok(repair);
        }


    }
}


