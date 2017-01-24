using System;
using System.Collections.Generic;
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
			webAuth.Navigated += WebAuth_Navigated;
		}

		void WebAuth_Navigated(object sender, WebNavigatedEventArgs e)
		{
			ViewModel.VerifyLoginCommand.Execute(e.Url);
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			webAuth.Navigated -= WebAuth_Navigated;
		}
	}
}
