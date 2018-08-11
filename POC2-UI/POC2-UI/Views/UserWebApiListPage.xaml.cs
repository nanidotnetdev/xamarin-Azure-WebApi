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
	public partial class UserWebApiListPage : ContentPage
	{
        private UserWebapiViewModel viewModel;

		public UserWebApiListPage ()
		{
			InitializeComponent();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //your code here;

            BindingContext = viewModel = new UserWebapiViewModel();
        }

        private async void AddUser_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UserWebApiPage());
        }

        private async void OnUserSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var user = e.SelectedItem as UserWebApiEntity;
            if (user == null)
                return;

            await Navigation.PushAsync(new UserWebApiPage(user));

            UserWebApiListView.SelectedItem = null;
        }
    }
}