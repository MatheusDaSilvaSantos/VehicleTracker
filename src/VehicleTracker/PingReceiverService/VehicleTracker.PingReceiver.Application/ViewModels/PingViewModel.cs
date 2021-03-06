﻿using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleTracker.PingReceiver.Application.ViewModels
{
    public class PingViewModel
    {
        public PingViewModel()
        {
            Id = Guid.NewGuid();
            PingTime = DateTime.Now; 
        }
        public Guid Id { get; set; }

        public string VehicleId { get; set; }

        public DateTime PingTime { get; set; }
    }
}
