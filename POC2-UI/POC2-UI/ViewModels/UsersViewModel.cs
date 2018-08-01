using System.Collections.ObjectModel;
using POC2_UI.Models;
using POC2_UI.Services;
using Xamarin.Forms;

namespace POC2_UI.ViewModels
{
    public class UsersViewModel: BaseViewModel
    {
        public ObservableCollection<User> Users { get; set; }
        private IUSerService _userService;

        public UsersViewModel()
        {
            Title = "Users";
            Users = new ObservableCollection<User>();
            _userService = new UserService();
            ExecuteLoadUserCommand();

            MessagingCenter.Subscribe<UserDetailViewModel, User>(this, "UserAdded", async (obj, item) =>
            {
                var _user = item as User;
                await _userService.SaveUser(_user);
                ExecuteLoadUserCommand();
            });
        }

        private async void ExecuteLoadUserCommand()
        {
            //var _users = new List<User>
            //{
            //    new User{ FirstName = "Narendra", LastName = "Nalluri"},
            //    new User{ FirstName = "Pratap", LastName = "Pesaru"},
            //    new User{ FirstName = "Mani"}
            //};

            var _users = await _userService.GetUserList();
            Users.Clear();
            foreach (var user in _users)
            {
                Users.Add(user);
            }
        }
    }
}
