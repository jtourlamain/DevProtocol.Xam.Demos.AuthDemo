using Xamarin.Forms;

namespace DevProtocol.Xam.Demos.AuthDemo
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			MainPage = new DevProtocol_Xam_Demos_AuthDemoPage();
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
