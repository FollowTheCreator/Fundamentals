using MongoDB.Driver;
using System;

namespace ITechart.Fundamentals.CsvToDatabase.Contexts
{
    class MongoDbContext
    {
        private readonly IMongoDatabase _db;

        public MongoDbContext(MongoClient client, string dbName)
        {
            client = client ?? throw new ArgumentNullException(nameof(client));
            _db = client.GetDatabase(dbName);
        }

        public IMongoCollection<T> Set<T>()
        {
            return _db.GetCollection<T>(typeof(T).Name);
        }
    }
}
