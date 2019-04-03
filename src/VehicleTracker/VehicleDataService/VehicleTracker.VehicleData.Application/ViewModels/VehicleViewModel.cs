using System;
using System.ComponentModel.DataAnnotations;

namespace VehicleTracker.VehicleData.Application.ViewModels
{
    public class VehicleViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string VehicleId { get; set; }
        public string RegNumber { get; set; }
        public Guid CustomerId { get; set; }



    }
}