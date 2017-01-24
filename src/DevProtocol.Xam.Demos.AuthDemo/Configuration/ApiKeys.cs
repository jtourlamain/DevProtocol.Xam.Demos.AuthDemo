using System;

namespace DevProtocol.Xam.Demos.AuthDemo.Configuration
{
	public static class ApiKeys
	{
	public const string ClientId = "APP-ID-FROM-VSTS";
	public const string ClientSecret = "APP-SECRET-FROM-VSTS";
	public const string RedirectUrl = "YOUR-REDIRECT-URL";
	public const string Scope = "vso.identity vso.profile";
	public const string AuthorizeUrl = "https://app.vssps.visualstudio.com/oauth2/authorize";
	public const string AccessTokenUrl = "https://app.vssps.visualstudio.com/oauth2/token";
	public const string BaseAuthorizationUrl = "https://app.vssps.visualstudio.com/oauth2";
	public const string ApiVersion = "2.0";
	public const string AccessToken = "access_token";
	}
}
