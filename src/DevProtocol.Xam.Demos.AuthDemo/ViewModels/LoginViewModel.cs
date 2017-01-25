using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Input;
using DevProtocol.Xam.Demos.AuthDemo.Configuration;
using IdentityModel.Client;
using Xamarin.Forms;

namespace DevProtocol.Xam.Demos.AuthDemo.ViewModels
{
	public class LoginViewModel: BaseViewModel
	{
		private string _currentCSRFToken;

		public LoginViewModel()
		{
			AuthUrl = CreateAuthUrl();
			this.PropertyChanged += ViewModel_PropertyChanged;
		}

		private UrlWebViewSource CreateAuthUrl()
		{
			var result = new UrlWebViewSource();
			var authorizeRequest = new AuthorizeRequest(ApiKeys.AuthorizeUrl);

			var dic = new Dictionary<string, string>();
			dic.Add("client_id", ApiKeys.ClientId);
			dic.Add("response_type", "Assertion");
			dic.Add("scope", ApiKeys.Scope);
			dic.Add("redirect_uri", ApiKeys.RedirectUrl);
			_currentCSRFToken = Guid.NewGuid().ToString("N");
			dic.Add("state", _currentCSRFToken);
			result.Url = authorizeRequest.Create(dic);
			return result;
		}



		#region Bindable Properties
		UrlWebViewSource authUrl;
		public UrlWebViewSource AuthUrl
		{
			get { return authUrl; }
			set { SetProperty(ref authUrl, value); }
		}
		#endregion


		private async void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			if (e.PropertyName == nameof(AuthUrl))
			{
				var url = AuthUrl.Url;
				if (url.Contains(ApiKeys.RedirectUrl))
				{
					var authorizeResponse = new AuthorizeResponse(url);
					var state = "";
					authorizeResponse.Values.TryGetValue("state", out state);

					if (state == _currentCSRFToken)
					{
						var keyValues = new Dictionary<string, string>();
						keyValues.Add("client_assertion_type", "urn:ietf:params:oauth:client-assertion-type:jwt-bearer");
						keyValues.Add("client_assertion", ApiKeys.ClientSecret);
						keyValues.Add("grant_type", "urn:ietf:params:oauth:grant-type:jwt-bearer");
						keyValues.Add("assertion", authorizeResponse.Code);
						keyValues.Add("redirect_uri", ApiKeys.RedirectUrl);

						var tokenclient = new TokenClient(ApiKeys.AccessTokenUrl);
						var tokenResponse = await tokenclient.RequestAsync(keyValues);
						App.User.AccessToken = tokenResponse.AccessToken;
						App.User.RefreshToken = tokenResponse.RefreshToken;
					}
					else
					{
						// Log CSRF token doesn't match.
					}
					MessagingCenter.Send<LoginViewModel>(this, MessageKeys.NavigateToMain);
				}
			}
		}
	}
}
