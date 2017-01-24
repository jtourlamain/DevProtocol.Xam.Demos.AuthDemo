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
			//dic.Add("nonce", Guid.NewGuid().ToString("N"));
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

		#region Commands
		private ICommand verifyLoginCommand;
		public ICommand VerifyLoginCommand
		{
			get { return verifyLoginCommand ?? (verifyLoginCommand = new Command(async (url) => await ExecuteVerifyLoginCommand(url))); }
		}

		#endregion

		private async Task ExecuteVerifyLoginCommand(object urlToVerify)
		{
			var url = urlToVerify as string;
			if (url.Contains(ApiKeys.RedirectUrl))
			{
				var authorizeResponse = new AuthorizeResponse(url);
				var keyValues = new List<KeyValuePair<string, string>>();
				keyValues.Add(new KeyValuePair<string, string>("client_assertion_type", "urn:ietf:params:oauth:client-assertion-type:jwt-bearer"));
				keyValues.Add(new KeyValuePair<string, string>("client_assertion", ApiKeys.ClientSecret));
				keyValues.Add(new KeyValuePair<string, string>("grant_type", "urn:ietf:params:oauth:grant-type:jwt-bearer"));
				keyValues.Add(new KeyValuePair<string, string>("assertion", authorizeResponse.Code));
				keyValues.Add(new KeyValuePair<string, string>("redirect_uri", ApiKeys.RedirectUrl));


				using (var client = new HttpClient())
				{
					//client.BaseAddress = new Uri(ApiKeys.AccessTokenUrl);
					client.DefaultRequestHeaders.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));
					var r = await client.PostAsync(ApiKeys.AccessTokenUrl, new FormUrlEncodedContent(keyValues));
					var t = await r.Content.ReadAsStringAsync();


				}

			}

			await Task.FromResult(0);
		}
	}
}
