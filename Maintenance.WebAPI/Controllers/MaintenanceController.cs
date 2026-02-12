using Microsoft.AspNetCore.Mvc;
using Maintenance.WebAPI.Services;

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
    }
}

