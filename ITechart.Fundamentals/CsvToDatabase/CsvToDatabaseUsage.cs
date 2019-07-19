using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITechart.Fundamentals.CsvEnumerable.Data;
using ITechart.Fundamentals.CsvEnumerable.Implementations;
using ITechart.Fundamentals.CsvEnumerable.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ITechart.Fundamentals.CsvToDatabase
{
    class CsvToDatabaseUsage
    {
        public static void UseCsvToDatabase()
        {
            string connection = ConfigurationManager.ConnectionStrings["MongoDb"].ConnectionString;
            var client = new MongoClient(connection);
            var database = client.GetDatabase("TestDB");
            var collection = database.GetCollection<Record>("Records");

            const string path = @"file.csv";
            CreateCsv.Create(path);
            var records = new CsvEnumerableWithHelper<Record>(new StreamReader(path));
            foreach(var record in records)
            {
                SaveDocs(record, collection).Wait();
            }

            Console.WriteLine("end");
        }

        private static async Task SaveDocs(Record record, IMongoCollection<Record> collection)
        {
            await collection.InsertOneAsync(record);
        }
    }
}
