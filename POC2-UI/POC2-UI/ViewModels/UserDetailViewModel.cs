using System;
using System.Collections.Generic;
using System.Text;
using POC2_UI.Models;
using Xamarin.Forms;

namespace POC2_UI.ViewModels
{
    public class UserDetailViewModel: BaseViewModel
    {
        public User User { get; set; }

        public UserDetailViewModel(User user = null)
        {
            Title = user != null ? user.FirstName: "ADD new";
            User = user;
        }

        public void SaveUser(UserDetailViewModel viewModel)
        {
            MessagingCenter.Send(this, "UserAdded", viewModel.User);
            
            //db call.
        }
    }
}
