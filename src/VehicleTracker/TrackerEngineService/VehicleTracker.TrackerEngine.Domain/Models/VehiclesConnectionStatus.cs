using System;
using Microsoft.WindowsAzure.Storage.Table;

namespace VehicleTracker.TrackerEngine.Domain.Models
{
    public class VehiclesConnectionStatus : TableEntity
    {

        public const string PKey = "VehiclePing";

        public VehiclesConnectionStatus()
        {
                
        }
        public VehiclesConnectionStatus(string vehicleId, string pingTime)
        {
            VehicleId = vehicleId;
            PingTime = pingTime;

            PartitionKey = PKey;
            RowKey = vehicleId;
        }

        public string VehicleId { get; set; }

        public string PingTime { get; set; }
    }
}