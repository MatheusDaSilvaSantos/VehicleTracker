using System.Threading.Tasks;

namespace VehicleTracker.TrackerEngine.Domain.Interfaces
{
    public interface IReceiveMessagesService
    {
        Task DequeueMessageAsync();

    }
}
