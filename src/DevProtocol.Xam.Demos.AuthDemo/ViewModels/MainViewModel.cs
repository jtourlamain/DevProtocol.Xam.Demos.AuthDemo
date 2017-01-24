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
		private ICommand gitHubReposCommand;
		public ICommand GitHubReposCommand
		{
			get { return gitHubReposCommand ?? (gitHubReposCommand = new Command(() => ExecuteGoToReposCommand())); }
		}
		#endregion

		private void ExecuteLoginCommand()
		{
			if (IsBusy)
				return;
			MessagingCenter.Send<MainViewModel>(this, MessageKeys.NavigateToLogin);
			IsBusy = false;
		}

		private void ExecuteGoToReposCommand()
		{
			if (IsBusy)
				return;
			IsBusy = true;
			MessagingCenter.Send<MainViewModel>(this, MessageKeys.NavigateToRepos);
			IsBusy = false;
		}
	}
}

