using System;
using System.Collections.Generic;
using SQLite;
using System.Threading.Tasks;

namespace ProjectNASA
{
    public class Database
    {
        private readonly SQLiteAsyncConnection database;
        public Database(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<myListObject>().Wait();
        }
        public Task<List<myListObject>> GetMyFavSpaceObjects()
        {
            return database.Table<myListObject>().ToListAsync();
        }
        public Task<int> SaveObjectToList(myListObject mlo)
        {
            return database.InsertAsync(mlo);
        }
    }
}
