using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using POC2_UI.Helpers;
using POC2_UI.Models;
using SQLite;

namespace POC2_UI.Repository
{
    public class UserRepository : IUserRepository
    {
        private SQLiteAsyncConnection _connection;
        private bool disposed = false;

        public UserRepository(string dbpath)
        {
            //TODO: can refactor 
        //    string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal),
        //"userdb.db3");

            //TODO: use dependency injection for initialization.
            var fileHelper = new AndroidFileHelper();

            //_connection = new SQLiteAsyncConnection(fileHelper.GetLocalFilePath("testdb.db3"));
            _connection = new SQLiteAsyncConnection(dbpath);

            _connection.CreateTableAsync<User>().Wait();
        }

        public Task<int> DeleteUser(User user)
        {
            return _connection.DeleteAsync(user);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called. 
            if (!this.disposed)
            {
                // If disposing equals true, dispose all managed 
                // and unmanaged resources. 
                if (disposing)
                {
                    // Dispose managed resources.
                    this.Dispose();
                }

                // Note disposing has been done.
                disposed = true;

            }
        }

        ~UserRepository()
        {
            Dispose(false);
        }

        public Task<User> GetUser(Guid id)
        {
            return _connection.Table<User>().Where(u => u.Id == id).FirstOrDefaultAsync();
        }

        public Task<List<User>> GetUserList()
        {
            return _connection.Table<User>().ToListAsync();
        }

        public Task<int> SaveUser(User user)
        {
            if (user.Id != Guid.Empty)
            {
                return _connection.UpdateAsync(user);
            }
            else
            {
                user.Id = Guid.NewGuid();
                return _connection.InsertAsync(user);
            }
        }
    }
}
