using System.Collections.Generic;
using Maintenance.WebAPI.Models;

namespace Maintenance.WebAPI.Services
{
    public interface IRepairHistoryService
    {
        List<RepairHistoryDto> GetByVehicleId(int vehicleId);
        void AddRepair(RepairHistoryDto repair);

        void UpdateRepair(int id, RepairHistoryDto repair);

        void DeleteRepair(int id);
    }
}
