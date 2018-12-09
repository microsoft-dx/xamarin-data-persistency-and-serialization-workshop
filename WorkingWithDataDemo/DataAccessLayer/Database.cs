using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using DataTransferObjects.Entities;
using DataTransferObjects.Users;
using SQLite;

namespace DataAccessLayer
{
    public partial class Database
    {
        private static Database _dataBase;
        private static SQLiteAsyncConnection _connection;

        public static Database Instance
        {
            get
            {
                if (_dataBase == null)
                {
                    _dataBase = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), $"ShoppingItem_{Core.AuthenticatedUserID}.db3"));
                }

                return _dataBase;
            }
        }

        private Database(string dbPath)
        {
            _connection = new SQLiteAsyncConnection(dbPath); // open database file or create database file if it doesn't exist

            _connection.CreateTableAsync<ShoppingItem>().Wait();
            _connection.CreateTableAsync<User>().Wait();
        }

        public void LogOut()
        {
            // close database connection and invalidate database object
            _connection.CloseAsync().Wait();
            _dataBase = null;
        }

        public Task<List<ShoppingItem>> GetItemsAsync()
        {
            return _connection.Table<ShoppingItem>().OrderBy(x => x.ItemID).ToListAsync();
        }

        public Task<ShoppingItem> GetItemAsync(uint id)
        {
            return _connection.Table<ShoppingItem>().Where(i => i.ItemID == id).FirstOrDefaultAsync();
        }

        public Task<int> UpdateItemData(ShoppingItem item)
        {
            return _connection.InsertOrReplaceAsync(item);
        }

        public Task<int> DeleteItemAsync(ShoppingItem item)
        {
            return _connection.DeleteAsync(item);
        }

        public Task<User> GetUserAsync(uint userID)
        {
            return _connection.Table<User>().FirstOrDefaultAsync(x => x.UserID == userID);
        }

        public Task<User> GetUserAsync(string userName, byte[] authenticationToken)
        {
            return _connection.Table<User>().FirstOrDefaultAsync(
                x => x.AuthenticationToken == authenticationToken &&
                x.UserName == userName);
        }

        public async Task AddAuthenticatedUser(User givenUser)
        {
            await _connection.InsertOrReplaceAsync(givenUser);

            return;
        }
    }
}
