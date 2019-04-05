using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using Microsoft.WindowsAzure.Storage.Table;
using VehicleTracker.TrackerEngine.Domain.Interfaces;

namespace VehicleTracker.TrackerEngine.Infra.Data.StorageTableService
{
    public class GetCloudTable : IGetCloudTable
    {
        private readonly CloudTableClient _client;
        private readonly string _tableName;
        private readonly IConfiguration _configuration;
        public GetCloudTable(IConfiguration configuration)
        {
            _configuration = configuration;

            var connectionString = _configuration.GetSection("StorageConnectionString").Value;
            _tableName = _configuration.GetSection("TableName").Value;

            var storageAccount = CloudStorageAccount.Parse(connectionString);
            _client = storageAccount.CreateCloudTableClient();

        }

        public CloudTable GetTable(bool createIfNotExists = false)
        {
            var table = _client.GetTableReference(_tableName);

            if (createIfNotExists)
            {
                table.CreateIfNotExistsAsync();
            }

            return table;
        }




    }
}