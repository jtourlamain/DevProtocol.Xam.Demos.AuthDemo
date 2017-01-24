using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace DevProtocol.Xam.Demos.AuthDemo.Models
{
	public class VstsToken
	{
		[JsonProperty("access_token")]
		public string AccessToken { get; set; }

		[JsonProperty("refresh_token")]
		public string RefreshToken { get; set; }

		[JsonProperty("expires_in")]
		public int ExpiresIn { get; set; }

		[JsonProperty("token_type")]
		public string TokenType { get; set; }


		public string Scope { get; set; }
	}
}
