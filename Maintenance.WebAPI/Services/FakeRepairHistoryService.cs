using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maintenance.WebAPI.Models;

namespace Maintenance.WebAPI.Services
{
    public class FakeRepairHistoryService : IRepairHistoryService
    {
        private readonly List<RepairHistoryDto> _repairs = new();

        public async Task<List<RepairHistoryDto>> GetByVehicleIdAsync(int vehicleId)
        {
            return await Task.FromResult(
                _repairs
                    .Where(r => r.VehicleId == vehicleId)
                    .ToList());
        }
        public async Task AddRepairAsync(RepairHistoryDto repair)
        {
            repair.Id = _repairs.Count + 1;
            _repairs.Add(repair);

            await Task.CompletedTask;
        }

        public async Task<bool> UpdateRepairAsync(int id, RepairHistoryDto repair)
        {
            var existing = _repairs.FirstOrDefault(r => r.Id == id);

            if (existing == null)
                return await Task.FromResult(false);

            existing.Description = repair.Description;
            existing.Cost = repair.Cost;
            existing.PerformedBy = repair.PerformedBy;
            existing.RepairDate = repair.RepairDate;

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteRepairAsync(int id)
        {
            var repair = _repairs.FirstOrDefault(r => r.Id == id);

            if (repair == null)
                return await Task.FromResult(false);

            _repairs.Remove(repair);

            return await Task.FromResult(true);
        }


    }
}
