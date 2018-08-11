using System;
using POC2_UI.Models;
using POC2_UI.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace POC2_UI.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UsersListPage : ContentPage
	{
	    private UsersViewModel viewModel;

		public UsersListPage ()
		{
			InitializeComponent();

		    BindingContext = viewModel = new UsersViewModel();
		}

		private async void AddUser_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new UserPage());
		}

		private async void OnUserSelected(object sender, SelectedItemChangedEventArgs e)
		{
			var user = e.SelectedItem as User;
			if (user == null)
				return;

			await Navigation.PushAsync(new UserPage(user));

			UserListView.SelectedItem = null;
		}
	}
}