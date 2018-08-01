using POC2_UI.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace POC2_UI.Repository
{
    public interface IUserRepository : IDisposable
    {
        Task<int> SaveUser(User user);

        Task<int> DeleteUser(User user);

        Task<User> GetUser(Guid id);

        Task<List<User>> GetUserList();

    }
}
