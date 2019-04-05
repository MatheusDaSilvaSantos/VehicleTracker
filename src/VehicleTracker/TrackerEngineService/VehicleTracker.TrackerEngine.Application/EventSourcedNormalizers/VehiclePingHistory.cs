using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using VehicleTracker.Abstract.Domain.Core.Events;

namespace VehicleTracker.TrackerEngine.Application.EventSourcedNormalizers
{
    public class VehiclePingHistory
    {
        public static IList<VehiclePingHistoryData> HistoryData { get; set; }

        public static IList<VehiclePingHistoryData> ToJavaScriptVehiclePingHistory(IList<StoredEvent> storedEvents)
        {
            HistoryData = new List<VehiclePingHistoryData>();
            VehiclePingHistoryDeserializer(storedEvents);

            var sorted = HistoryData.OrderBy(c => c.When);
            var list = new List<VehiclePingHistoryData>();
            var last = new VehiclePingHistoryData();

            foreach (var change in sorted)
            {
                var jsSlot = new VehiclePingHistoryData
                {
                    Id = change.Id == Guid.Empty.ToString() || change.Id == last.Id ? "" : change.Id,
                    VehicleId = string.IsNullOrWhiteSpace(change.VehicleId) || change.VehicleId == last.VehicleId ? "" : change.VehicleId,
                    PingTime = string.IsNullOrWhiteSpace(change.PingTime) || change.PingTime == last.PingTime ? "" : change.PingTime,
                    Action = string.IsNullOrWhiteSpace(change.Action) ? "" : change.Action,
                    When = change.When
                };

                list.Add(jsSlot);
                last = change;
            }
            return list;
        }

        private static void VehiclePingHistoryDeserializer(IEnumerable<StoredEvent> storedEvents)
        {
            foreach (var e in storedEvents)
            {
                var slot = new VehiclePingHistoryData();
                dynamic values;

                switch (e.MessageType)
                {
                    case "CustomerRegisteredEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        slot.PingTime = values["PingTime"];
                        slot.VehicleId = values["VehicleId"];
                        slot.Action = "VehiclePing";
                        slot.When = values["Timestamp"];
                        slot.Id = values["Id"];
                        break;
                }
                HistoryData.Add(slot);
            }
        }
    }
}