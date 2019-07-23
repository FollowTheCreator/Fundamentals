using ITechart.Fundamentals.Common.Interfaces;

namespace ITechart.Fundamentals.Common.Models
{
    public class Record : IDbEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Age: {Age}";
        }
    }
}
