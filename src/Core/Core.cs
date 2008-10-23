using System.IO;

namespace MillionBeauty
{
    public static class Core
    {
        public static void NewDatabase(string connectionString)
        {
            SQLiteDB.Instance.ConnectionString = connectionString;
            SQLiteDB.Instance.CreateDatabase();
        }

        public static void LoadDatabase(string connectionString)
        {
            SQLiteDB.Instance.ConnectionString = connectionString;
            SQLiteDB.Instance.CreateConnection();
        } 
    }
}
