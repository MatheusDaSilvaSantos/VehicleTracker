using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VehicleTracker.VehicleData.Application.ViewModels
{
    public class CustomerViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

    }
}
