using ITechart.Fundamentals.CsvToDatabase.Interfaces;
using System.Threading.Tasks;
using MongoDB.Driver;
using ITechart.Fundamentals.Common.Interfaces;
using ITechart.Fundamentals.CsvToDatabase.Contexts;

namespace ITechart.Fundamentals.CsvToDatabase.Implementations
{
    class MongoDbRepository<T> : IRepository<T>
        where T : IDbEntity
    {
        protected MongoDbContext _context;

        public MongoDbRepository(MongoDbContext context)
        {
            _context = context;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context
                .Set<T>()
                .Find(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task CreateAsync(T item)
        {
            await _context.Set<T>().InsertOneAsync(item);
        }

        public async Task DeleteAsync(int id)
        {
            await _context.Set<T>().DeleteOneAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(T item)
        {
            var filter = Builders<T>.Filter.Eq(x => x.Id, item.Id);
            await _context.Set<T>().ReplaceOneAsync(filter, item);
        }
    }
}
