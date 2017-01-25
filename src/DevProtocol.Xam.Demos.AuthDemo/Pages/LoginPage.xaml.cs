using System;
using System.Collections.Generic;
using DevProtocol.Xam.Demos.AuthDemo.Configuration;
using DevProtocol.Xam.Demos.AuthDemo.ViewModels;
using Xamarin.Forms;

namespace DevProtocol.Xam.Demos.AuthDemo.Pages
{
	public partial class LoginPage : ContentPage
	{
		public LoginPage()
		{
			BindingContext = new LoginViewModel();
			InitializeComponent();
		}

		private LoginViewModel ViewModel
		{
			get { return BindingContext as LoginViewModel; }
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			MessagingCenter.Subscribe<LoginViewModel>(this, MessageKeys.NavigateToMain, async _ =>
			  {
				await Navigation.PopModalAsync();
			  });
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			MessagingCenter.Unsubscribe<LoginViewModel>(this, MessageKeys.NavigateToMain);
		}


	}
}
