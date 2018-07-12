using System.Collections.Generic;
using System.Collections.ObjectModel;
using POC2_UI.Models;
using POC2_UI.Views;
using Xamarin.Forms;

namespace POC2_UI.ViewModels
{
    public class UsersViewModel: BaseViewModel
    {
        public ObservableCollection<User> Users { get; set; }

        public UsersViewModel()
        {
            Title = "Users";
            Users = new ObservableCollection<User>();
            ExecuteLoadUserCommand();

            MessagingCenter.Subscribe<UserDetailViewModel, User>(this, "UserAdded", async (obj, item) =>
            {
                var _user = item as User;
                Users.Add(_user);
            });
        }

        private void ExecuteLoadUserCommand()
        {
            var _users = new List<User>
            {
                new User{ FirstName = "Narendra", LastName = "Nalluri"},
                new User{ FirstName = "Pratap", LastName = "Pesaru"},
                new User{ FirstName = "Mani"}
            };

            foreach (var user in _users)
            {
                Users.Add(user);
            }
        }
    }
}
