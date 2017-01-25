using System;
using System.Collections.Generic;
using DevProtocol.Xam.Demos.AuthDemo.Configuration;
using DevProtocol.Xam.Demos.AuthDemo.ViewModels;
using Xamarin.Forms;

namespace DevProtocol.Xam.Demos.AuthDemo.Pages
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			BindingContext = new MainViewModel();
			InitializeComponent();
		}

		private MainViewModel ViewModel
		{
			get { return BindingContext as MainViewModel; }
		}

		protected override void OnAppearing()
		{
			lblToken.Text = App.User.AccessToken;
			MessagingCenter.Subscribe<MainViewModel>(this, MessageKeys.NavigateToLogin, async _ =>
			  {
				  await Navigation.PushModalAsync(new LoginPage());
			  });
			base.OnAppearing();
		}

		protected override void OnDisappearing()
		{
			MessagingCenter.Unsubscribe<MainViewModel>(this, MessageKeys.NavigateToLogin);
			base.OnDisappearing();
		}
	}
}
