using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using DataAccessLayer.Entities;
using SQLite;

namespace DataAccessLayer
{
    public partial class Database
    {
        private static Database database;
        private static SQLiteAsyncConnection _connection;

        public static Database Instance
        {
            get
            {
                if (database == null)
                {
                    database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ShoppingItem.db3"));
                }

                return database;
            }
        }

        private Database(string dbPath)
        {
            _connection = new SQLiteAsyncConnection(dbPath);

            _connection.CreateTableAsync<ShoppingItem>().Wait();
            _connection.CreateTableAsync<User>().Wait();
        }
        public Task<List<ShoppingItem>> GetItemsAsync()
        {
            return _connection.Table<ShoppingItem>().OrderBy(x => x.ItemId).ToListAsync();
        }

        public Task<ShoppingItem> GetItemAsync(int id)
        {
            return _connection.Table<ShoppingItem>().Where(i => i.ItemId == id).FirstOrDefaultAsync();
        }

        public Task<int> InsertItemAsync(ShoppingItem item)
        {
            return _connection.InsertAsync(item);
        }

        public Task<int> DeleteItemAsync(ShoppingItem item)
        {
            return _connection.DeleteAsync(item);
        }

        public Task<User> GetUserAsync(uint userID)
        {
            return _connection.Table<User>().FirstOrDefaultAsync(x => x.UserID == userID);
        }

        public Task<User> GetUserAsync(string userName, string authenticationToken)
        {
            return _connection.Table<User>().FirstOrDefaultAsync(
                x => x.AuthentiCationToken == authenticationToken &&
                x.UserName == userName);
        }

        public Task<int> AddAuthenticatedUser(User givenUser)
        {
            return _connection.InsertAsync(givenUser);
        }
    }
}
