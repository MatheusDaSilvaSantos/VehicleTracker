using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;

namespace VehicleTracker.Abstract.Domain.Core.Interfaces
{
    public interface ITableRepository<T> where T : class, ITableEntity, new()
    {
        Task SaveAsync(T entity);
        Task<T> GetAsync(string partitionKey, string rowKey);
        Task DeleteAsync(string partitionKey, string rowKey);
        Task<IList<T>> GetAllAsync();
        Task<IList<T>> GetAllAsync(string partitionKey);
    }
}