using System;
using System.Collections.Generic;
using System.Linq;
using Maintenance.WebAPI.Models;

namespace Maintenance.WebAPI.Services
{
    public class FakeRepairHistoryService : IRepairHistoryService
    {
        private readonly List<RepairHistoryDto> _repairs = new();

        public List<RepairHistoryDto> GetByVehicleId(int vehicleId)
        {
            return _repairs
        .Where(r => r.VehicleId == vehicleId)
        .ToList();
        }
        public void AddRepair(RepairHistoryDto repair)
        {
            repair.Id = _repairs.Count + 1;
            _repairs.Add(repair);

        }

        public void UpdateRepair(int id, RepairHistoryDto repair)
        {
            var existing = _repairs.FirstOrDefault(r => r.Id == id);

            if (existing != null)
            {
                existing.Description = repair.Description;
                existing.Cost = repair.Cost;
                existing.PerformedBy = repair.PerformedBy;
                existing.RepairDate = repair.RepairDate;
            }
        }

        public void DeleteRepair(int id)
        {
            var repair = _repairs.FirstOrDefault(r => r.Id == id);

            if (repair != null)
            {
                _repairs.Remove(repair);
            }
        }


    }
}
