
namespace fgstm
{
    internal class SQLiteConnection
    {
        private string databasePath;

        public SQLiteConnection(string databasePath)
        {
            this.databasePath = databasePath;
        }

        internal void CreateTable<T>()
        {
            throw new NotImplementedException();
        }

        internal object Table<T>()
        {
            throw new NotImplementedException();
        }
    }
}