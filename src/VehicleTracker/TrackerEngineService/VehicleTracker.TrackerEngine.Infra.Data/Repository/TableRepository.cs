using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;
using VehicleTracker.Abstract.Domain.Core.Interfaces;
using VehicleTracker.TrackerEngine.Domain.Interfaces;

namespace VehicleTracker.TrackerEngine.Infra.Data.Repository
{
    public class TableRepository<T> : ITableRepository<T> where T : class, ITableEntity, new()

    {
        protected readonly CloudTable _CloudTable;
        public TableRepository(IGetCloudTable tables)
        {
            _CloudTable = tables.GetTable(true);
        }
        public virtual async Task<T> GetAsync(string partitionKey, string rowKey)
        {
            var op = TableOperation.Retrieve<T>(partitionKey, rowKey);
            var r = await _CloudTable.ExecuteAsync(op);
            return r.Result as T;
        }
        public async Task DeleteAsync(string partitionKey, string rowKey)
        {
            var x = await GetAsync(partitionKey, rowKey);
            var del = TableOperation.Delete(x);
            await _CloudTable.ExecuteAsync(del);
        }
        public virtual async Task<IList<T>> GetAllAsync()
        {
            var q = await QueryAllAsync();
            return q;
        }
        public virtual  IList<T> GetAll()
        {
            var q =  QueryAllAsync().Result;
            return q;
        }
        public virtual async Task<IList<T>> GetAllAsync(string partitionKey)
        {
            var q = await QuerybyPkAsync(partitionKey);
            return q;
        }
        private async Task<IList<T>> QueryAllAsync()
        {
            var query = new TableQuery<T>();

            var items = new List<T>();
            TableContinuationToken continuationToken = null;
            do
            {
                // Execute the query async until there is no more result
                var queryResult = await _CloudTable.ExecuteQuerySegmentedAsync(query, continuationToken);
                foreach (var entity in queryResult)
                {
                    items.Add(entity);
                }

                continuationToken = queryResult.ContinuationToken;
            } while (continuationToken != null);
            return items;


        }
        private async Task<IList<T>> QuerybyPkAsync(string partitionKey)
        {

            var filterPk = TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, partitionKey);
            var query = new TableQuery<T>().Where(filterPk);

            var items = new List<T>();
            TableContinuationToken continuationToken = null;
            do
            {
                // Execute the query async until there is no more result
                var queryResult = await _CloudTable.ExecuteQuerySegmentedAsync(query, continuationToken);
                foreach (var entity in queryResult)
                {
                    items.Add(entity);
                }

                continuationToken = queryResult.ContinuationToken;
            } while (continuationToken != null);
            return items;
        }
        public virtual async Task SaveAsync(T entity)
        {
            var op = TableOperation.InsertOrMerge(entity);
            //var op = TableOperation.InsertOrReplace(entity);
            await _CloudTable.ExecuteAsync(op);
        }

    }
}