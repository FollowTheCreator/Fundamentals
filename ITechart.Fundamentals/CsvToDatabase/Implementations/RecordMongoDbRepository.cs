using ITechart.Fundamentals.Common.Interfaces;
using ITechart.Fundamentals.Common.Models;
using ITechart.Fundamentals.CsvToDatabase.Contexts;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITechart.Fundamentals.CsvToDatabase.Implementations
{
    class RecordMongoDbRepository : MongoDbRepository<Record>
    {
        public RecordMongoDbRepository(MongoDbContext context)
            : base(context) { }

        public async Task DeleteAll()
        {
            await _context.Set<Record>().DeleteManyAsync(_ => true);
        } 
    }
}
