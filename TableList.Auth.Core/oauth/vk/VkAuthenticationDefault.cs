﻿namespace TableList.Auth.Core.oauth.vk
{
	public class VkAuthenticationDefault
	{
		/// <summary>
		/// Default value for <see cref="AuthenticationOptions.AuthenticationScheme"/>.
		/// </summary>
		public const string AuthenticationScheme = "Vkontakte";

		/// <summary>
		/// Default value for <see cref="RemoteAuthenticationOptions.DisplayName"/>.
		/// </summary>
		public const string DisplayName = "Vkontakte";

		/// <summary>
		/// Default value for <see cref="AuthenticationOptions.ClaimsIssuer"/>.
		/// </summary>
		public const string Issuer = "Vkontakte";

		/// <summary>
		/// Default value for <see cref="RemoteAuthenticationOptions.CallbackPath"/>.
		/// </summary>
		public const string CallbackPath = "/signin-vkontakte";

		/// <summary>
		/// Default value for <see cref="OAuthOptions.AuthorizationEndpoint"/>.
		/// </summary>
		public const string AuthorizationEndpoint = "https://oauth.vk.com/authorize";

		/// <summary>
		/// Default value for <see cref="OAuthOptions.TokenEndpoint"/>.
		/// </summary>
		public const string TokenEndpoint = "https://oauth.vk.com/access_token";

		/// <summary>
		/// Default value for <see cref="OAuthOptions.UserInformationEndpoint"/>.
		/// </summary>
		public const string UserInformationEndpoint = "https://api.vk.com/method/users.get.json";
	}
}
