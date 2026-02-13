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

        public async Task UpdateRepairAsync(int id, RepairHistoryDto repair)
        {
            var existing = _repairs.FirstOrDefault(r => r.Id == id);

            if (existing != null)
            {
                existing.Description = repair.Description;
                existing.Cost = repair.Cost;
                existing.PerformedBy = repair.PerformedBy;
                existing.RepairDate = repair.RepairDate;
            }

            await Task.CompletedTask;
        }

        public async Task DeleteRepairAsync(int id)
        {
            var repair = _repairs.FirstOrDefault(r => r.Id == id);

            if (repair != null)
            {
                _repairs.Remove(repair);
            }

            await Task.CompletedTask;
        }

    }
}
