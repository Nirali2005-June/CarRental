using System;
using System.ComponentModel.DataAnnotations;

namespace Maintenance.WebAPI.Models
{
    public class RepairHistoryDto
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public DateTime RepairDate { get; set; }
        
        [Required]
        public string Description { get; set; }

        [Range(0.01, 100000)]
        public decimal Cost { get; set; }

        [Required]
        public string PerformedBy { get; set; }
    }
}
