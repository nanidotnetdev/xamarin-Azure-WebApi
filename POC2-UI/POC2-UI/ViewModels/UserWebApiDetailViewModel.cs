using System;
using System.Collections.Generic;
using System.Text;
using POC2_UI.Models;
using Xamarin.Forms;

namespace POC2_UI.ViewModels
{
    public class UserWebApiDetailViewModel: BaseViewModel
    {
        public UserWebApiEntity User { get; set; }

        public UserWebApiDetailViewModel(UserWebApiEntity user = null)
        {
            Title = User != null ? user.EmpName : "Add New";
            User = user;
        }

        public void Saveuser(UserWebApiDetailViewModel viewModel)
        {
            MessagingCenter.Send(this, "UserAdded", viewModel.User);
        }

    }
}
