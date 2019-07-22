using ITechart.Fundamentals.Common.Interfaces;
using System.Threading.Tasks;

namespace ITechart.Fundamentals.CsvToDatabase.Interfaces
{
    public interface IRepository<T> where T : IDbEntity
    {
        Task<T> GetByIdAsync(int id);

        Task CreateAsync(T item);

        Task UpdateAsync(T item);

        Task DeleteAsync(int id);
    }
}
