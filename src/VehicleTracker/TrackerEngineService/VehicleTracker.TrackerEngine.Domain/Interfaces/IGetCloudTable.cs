using Microsoft.WindowsAzure.Storage.Table;

namespace VehicleTracker.TrackerEngine.Domain.Interfaces
{
    public interface IGetCloudTable
    {
        CloudTable GetTable(bool createIfNotExists = false);
    }
}