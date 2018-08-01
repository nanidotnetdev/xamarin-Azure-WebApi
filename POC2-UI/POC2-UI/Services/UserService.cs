using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using POC2_UI.Models;
using POC2_UI.Repository;

namespace POC2_UI.Services
{
    public class UserService : IUSerService
    {

        private UserRepository _repo;

        public UserService() => _repo = App.UserDb;

        public Task<int> DeleteUser(User user)
        {
            return _repo.DeleteUser(user);
        }

        public Task<List<User>> GetUserList()
        {
            return _repo.GetUserList();
        }

        public Task<User> GetUser(Guid id)
        {
            return _repo.GetUser(id);
        }

        public Task<int> SaveUser(User user)
        {
            return _repo.SaveUser(user);
        }
    }
}
