using System;
using System.Windows.Input;
using DevProtocol.Xam.Demos.AuthDemo.Configuration;
using Xamarin.Forms;

namespace DevProtocol.Xam.Demos.AuthDemo.ViewModels
{
	public class MainViewModel : BaseViewModel
	{
		
		#region Commands
		private ICommand loginCommand;
		public ICommand LoginCommand
		{
			get { return loginCommand ?? (loginCommand = new Command(() => ExecuteLoginCommand())); }
		}
		#endregion

		private void ExecuteLoginCommand()
		{
			if (IsBusy)
				return;
			MessagingCenter.Send<MainViewModel>(this, MessageKeys.NavigateToLogin);
			IsBusy = false;
		}

	}
}

