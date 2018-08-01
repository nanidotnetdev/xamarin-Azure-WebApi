using Xamarin.Forms;
using POC2_UI.Views;
using POC2_UI.Repository;
using POC2_UI.Helpers;

namespace POC2_UI
{
    public partial class App : Application
	{

        static UserRepository userDB;

        public App ()
		{
			InitializeComponent();


			MainPage = new MainPage();
		}

        public static UserRepository UserDb
        {
            get
            {
                if(userDB == null)
                {
                    userDB = new UserRepository(DependencyService.Get<IFileHelper>().GetLocalFilePath("userdb.db3"));

                }

                return userDB;
            }
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
