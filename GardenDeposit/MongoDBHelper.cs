using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GardenDeposit
{
    public interface IMongoDBHelper
    {
        Task InsertAsync<T>(string databaseName, string collectionName, T obj);

        Task<long> UpdateAsync<T>(string databaseName, string collectionName, Expression<Func<T, bool>> filter, T obj);

        Task DeleteAsync<T>(string databaseName, string collectionName, Expression<Func<T, bool>> filter);

        Task<List<T>> SelectAsync<T>(string databaseName, string collectionName, Expression<Func<T, bool>> filter = null);
    }


    public class MongoDBHelper : IMongoDBHelper
    {
        private readonly IMongoClient client;

        public MongoDBHelper(
          IConfig config)
        {
            client = new MongoClient(config.ConnectionString);
            ConventionRegistry.Register("IgnoreExtraElements", new ConventionPack { new IgnoreExtraElementsConvention(true) }, type => true);
        }

        public async Task InsertAsync<T>(string databaseName, string collectionName, T obj)
        {
            await GetDatabase(databaseName).GetCollection<T>(collectionName).InsertOneAsync(obj);
        }

        public async Task<List<T>> SelectAsync<T>(string databaseName, string collectionName, Expression<Func<T, bool>> filter = null)
        {
            if (filter == null)
                filter = x => true;

            return await GetDatabase(databaseName).GetCollection<T>(collectionName).Find(filter).ToListAsync();
        }

        public async Task<long> UpdateAsync<T>(string databaseName, string collectionName, Expression<Func<T, bool>> filter, T obj)
        {
            return await GetDatabase(databaseName).GetCollection<T>(collectionName).ReplaceOneAsync(filter, obj).ContinueWith(task => task.Result.ModifiedCount);
        }

        public async Task DeleteAsync<T>(string databaseName, string collectionName, Expression<Func<T, bool>> filter)
        {
            await GetDatabase(databaseName).GetCollection<T>(collectionName).DeleteManyAsync(filter);
        }

        private IMongoDatabase GetDatabase(string databaseName)
        {
            return client.GetDatabase(databaseName);
        }
    }

    public interface IConfig
    {
        string ConnectionString { get; set; }
    }

    public enum SortOrder
    {
        Descending = -1,
        Ascending = 1,
    }
}
