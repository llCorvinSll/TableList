using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TableList.Auth.Core.oauth.vk
{
    public class VkAuthenticationOptions : OAuthOptions
	{
		public VkAuthenticationOptions()
		{
			AuthenticationScheme = VkAuthenticationDefault.AuthenticationScheme;
			DisplayName = VkAuthenticationDefault.DisplayName;
			ClaimsIssuer = VkAuthenticationDefault.Issuer;
			AuthorizationEndpoint = VkAuthenticationDefault.AuthorizationEndpoint;
			TokenEndpoint = VkAuthenticationDefault.TokenEndpoint;
			UserInformationEndpoint = VkAuthenticationDefault.UserInformationEndpoint;
		}

		/// <summary>
		/// Gets the list of fields to retrieve from the user information endpoint.
		/// See https://vk.com/dev/fields for more information.
		/// </summary>
		public ICollection<string> Fields { get; } = new HashSet<string> {
			"uid",
			"first_name",
			"last_name",
			"photo_rec",
			"photo",
			"hash"
		};
	}
}
