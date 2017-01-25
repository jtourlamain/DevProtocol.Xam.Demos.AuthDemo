using DevProtocol.Xam.Demos.AuthDemo.Domain;
using DevProtocol.Xam.Demos.AuthDemo.Pages;
using Xamarin.Forms;

namespace DevProtocol.Xam.Demos.AuthDemo
{
	public partial class App : Application
	{
		public static User User = new User();

		public App()
		{
			InitializeComponent();
			MainPage = new NavigationPage(new MainPage());
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
