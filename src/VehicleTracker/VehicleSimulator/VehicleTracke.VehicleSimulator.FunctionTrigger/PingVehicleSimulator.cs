using System;
using System.Collections.Generic;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using VehicleTracke.VehicleSimulator.FunctionTrigger.PingReceiverServiceClient;
using VehicleTracke.VehicleSimulator.FunctionTrigger.PingReceiverServiceClient.Models;

namespace VehicleTracke.VehicleSimulator.FunctionTrigger
{
    public static class PingVehicleSimulator
    {
        static Random _random = new Random();

        [FunctionName("PingVehicleSimulator")]
        public static void Run([TimerTrigger("*/30 * * * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            var vehicleIdsList = GetVehicleIds();
            var randomCount = _random.Next(vehicleIdsList.Count);
            var apiUrl = new Uri("https://localhost:44301");

            var client = new PingReceiverService(apiUrl);
            for (int i = 0; i < randomCount; i++)
            {
                var randomIndex = _random.Next(vehicleIdsList.Count);
                var vehicleId = vehicleIdsList[randomIndex];

                var pingViewModel = new PingViewModel
                {
                    VehicleId = vehicleId
                };

                client.Post("1", pingViewModel);
            }

        }

        private static IList<string> GetVehicleIds()
        {
            return new List<string>
            {
                "YS2R4X20005399401",
                "VLUR4X20009093588",
                "VLUR4X20009048066",
                "YS2R4X20005388011",
                "YS2R4X20005387949",
                "VLUR4X20009048066",
                "YS2R4X20005387055"
            };
        }

    }



}
