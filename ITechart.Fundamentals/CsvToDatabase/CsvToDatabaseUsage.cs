using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ITechart.Fundamentals.Common.Models;
using ITechart.Fundamentals.CsvEnumerable.Implementations;
using ITechart.Fundamentals.CsvToDatabase.Contexts;
using ITechart.Fundamentals.CsvToDatabase.Implementations;
using ITechart.Fundamentals.CsvToDatabase.Interfaces;
using ITechart.Fundamentals.Logger;
using ITechart.Fundamentals.LoggingProxy.Implementations;
using ITechart.Fundamentals.Utils;
using MongoDB.Driver;

namespace ITechart.Fundamentals.CsvToDatabase
{

    class CsvToDatabaseUsage
    {
        public static async Task UseCsvToDatabaseAsync()
        {
            var client = new MongoClient(Config.MongoDbConnectionString);
            var context = new MongoDbContext(client, Config.DbName);
            await RemoveAllDocuments(context);

            var logger = new Logger.Implementations.Logger(LogLevel.Info);
            using (var loggingProxy = new LoggingProxy<IRepository<Record>>(logger))
            {
                var mongoDbRepository = loggingProxy.CreateInstance(new RecordMongoDbRepository(context));

                await Task.WhenAll(
                    new CsvEnumerableWithHelper<Record>(new StreamReader(Config.CsvFilePath))
                    .Select(async row => await mongoDbRepository.CreateAsync(row))
                );

                var record = await mongoDbRepository.GetByIdAsync(2);

                record.Name = "Updated name";

                await mongoDbRepository.UpdateAsync(record);

                await mongoDbRepository.DeleteAsync(3);
            }
        }

        private static async Task RemoveAllDocuments(MongoDbContext context)
        {
            var mongoDbRepository = new RecordMongoDbRepository(context);
            await mongoDbRepository.DeleteAll();
        }
    }
}
