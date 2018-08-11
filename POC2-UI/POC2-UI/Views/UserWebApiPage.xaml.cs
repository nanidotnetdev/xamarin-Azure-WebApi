using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using POC2_UI.ViewModels;
using POC2_UI.Models;

namespace POC2_UI.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UserWebApiPage : ContentPage
	{
        private UserWebApiDetailViewModel viewModel;

		public UserWebApiPage (UserWebApiEntity user = null)
		{
			InitializeComponent();

            viewModel = new UserWebApiDetailViewModel(user ?? new UserWebApiEntity());

            BindingContext = viewModel;
		}

        private async void Clicked_SaveUser(object sender, EventArgs e)
        {
            var u = BindingContext as UserWebApiDetailViewModel;

            viewModel.Saveuser(u);

            await Navigation.PopAsync();
        }
    }
}