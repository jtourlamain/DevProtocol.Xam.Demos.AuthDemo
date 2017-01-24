using System;
using Xamarin.Forms;

namespace DevProtocol.Xam.Demos.AuthDemo.ViewModels
{
	public interface INotifyPropertyChanging
	{
		event EventHandler<PropertyChangingEventArgs> PropertyChanging;
	}
}
