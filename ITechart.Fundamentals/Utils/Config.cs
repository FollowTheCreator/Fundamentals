using System.Configuration;

namespace ITechart.Fundamentals.Utils
{
    static class Config
    {
        public static string MongoDbConnectionString => ConfigurationManager.ConnectionStrings["MongoDb"].ConnectionString;

        public static string CsvFilePath => ConfigurationManager.AppSettings["csvFilePath"];

        public static string DbName => ConfigurationManager.AppSettings["dbName"];
    }
}
