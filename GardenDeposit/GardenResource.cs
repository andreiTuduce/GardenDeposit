using GardenDeposit.Contract;
using System;
using System.Linq;

namespace GardenDeposit
{
    internal class GardenResource
    {
        private static readonly string database = "Garden";
        private static readonly string collection = "Plants";

        private readonly IMongoDBHelper mongoDBHelper;

        public GardenResource(IMongoDBHelper mongoDBHelper)
        {
            this.mongoDBHelper = mongoDBHelper;
        }

        public void Insert(Plant plant)
        {
            mongoDBHelper.InsertAsync(database, collection, plant).Wait();
        }

        public Plant Select(Guid plantID)
        {
            return mongoDBHelper.SelectAsync<Plant>(database, collection, details => details.ID == plantID).Result.FirstOrDefault();
        }

        public Plant[] SelectMany()
        {
            return mongoDBHelper.SelectAsync<Plant>(database, collection, null).Result.ToArray();
        }

        public void Update(Plant plant)
        {
            mongoDBHelper.UpdateAsync(database, collection, filter => filter.ID == plant.ID, plant);
        }

        public void Delete(Guid plantID)
        {
            mongoDBHelper.DeleteAsync<Plant>(database, collection, filter => filter.ID == plantID).Wait();
        }
    }
}