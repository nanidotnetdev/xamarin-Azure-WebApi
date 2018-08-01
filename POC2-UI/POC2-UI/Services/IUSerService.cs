using POC2_UI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace POC2_UI.Services
{
    public interface IUSerService
    {
        Task<int> SaveUser(User user);

        Task<int> DeleteUser(User user);

        Task<User> GetUser(Guid id);

        Task<List<User>> GetUserList();

    }
}
