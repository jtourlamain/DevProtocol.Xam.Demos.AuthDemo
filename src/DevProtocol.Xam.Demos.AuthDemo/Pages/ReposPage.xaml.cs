using System;
using System.Collections.Generic;
using DevProtocol.Xam.Demos.AuthDemo.ViewModels;
using Xamarin.Forms;

namespace DevProtocol.Xam.Demos.AuthDemo.Pages
{
	public partial class ReposPage : ContentPage
	{
		public ReposPage()
		{
			BindingContext = new ReposViewModel();
			InitializeComponent();
		}

		private ReposViewModel ViewModel
		{
			get { return BindingContext as ReposViewModel; }
		}
	}
}
