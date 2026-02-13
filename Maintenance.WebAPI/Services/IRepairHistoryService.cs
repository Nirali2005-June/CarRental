using System.Collections.Generic;
using System.Threading.Tasks;
using Maintenance.WebAPI.Models;

namespace Maintenance.WebAPI.Services
{
    public interface IRepairHistoryService
    {
        Task<List<RepairHistoryDto>> GetByVehicleIdAsync(int vehicleId,int pageNumber,int pageSize);

        Task AddRepairAsync(RepairHistoryDto repair);
        Task<bool> UpdateRepairAsync(int id, RepairHistoryDto repair);
        Task<bool> DeleteRepairAsync(int id);


    }
}
