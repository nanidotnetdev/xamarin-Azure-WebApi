using POC2_UI.Models;
using POC2_UI.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace POC2_UI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserPage : ContentPage
    {
        private UserDetailViewModel viewModel;

        public UserPage(User user = null)
        {
            InitializeComponent();

            viewModel = new UserDetailViewModel(user ?? new User());

            BindingContext = viewModel;
        }

        private async void Clicked_SaveUser(object sender, EventArgs e)
        {
            var u = BindingContext as UserDetailViewModel;

            viewModel.SaveUser(u);

            await Navigation.PopAsync();
        }
    }
}