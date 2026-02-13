using System.Collections.Generic;
using System.Threading.Tasks;
using Maintenance.WebAPI.Models;

namespace Maintenance.WebAPI.Services
{
    public interface IRepairHistoryService
    {
        Task<List<RepairHistoryDto>> GetByVehicleIdAsync(int vehicleId);
        Task AddRepairAsync(RepairHistoryDto repair);
        Task UpdateRepairAsync(int id, RepairHistoryDto repair);
        Task DeleteRepairAsync(int id);

    }
}
