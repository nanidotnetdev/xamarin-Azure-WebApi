using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using POC2_UI.Models;
using POC2_UI.Services;
using Xamarin.Forms;

namespace POC2_UI.ViewModels
{
    public class UserWebapiViewModel: BaseViewModel
    {
        public ObservableCollection<UserWebApiEntity> Users { get; set; }

        public UserWebApiService _userService;

        public UserWebapiViewModel()
        {
            Title = "Users webapi";
            Users = new ObservableCollection<UserWebApiEntity>();
            _userService = new UserWebApiService();
            ExecuteLoadUserCommand();

            MessagingCenter.Subscribe<UserWebApiDetailViewModel, UserWebApiEntity>(this, "UserAdded", async (obj, item) =>
            {
                var _user = item as UserWebApiEntity;
                await _userService.SaveUser(_user);
                ExecuteLoadUserCommand();
            });
        }

        private async void ExecuteLoadUserCommand()
        {
            ICollection<UserWebApiEntity> userList = await _userService.GetAllUsers();
            Users.Clear();
            foreach (var item in userList)
            {
                Users.Add(item);
            }
        }
    }
}
