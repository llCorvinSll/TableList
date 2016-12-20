using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Http.Authentication;


namespace TableList.Auth.Core.oauth.vk
{
	public class VkOauthProvider : OAuthHandler<VkAuthenticationOptions>
	{
		public VkOauthProvider(HttpClient backchannel) : base(backchannel)
		{
			core_client = new VkOauthProviderCore(Context.RequestAborted);
		}

		protected override async Task<AuthenticationTicket> CreateTicketAsync(ClaimsIdentity identity, AuthenticationProperties properties, OAuthTokenResponse tokens)
		{
			var user = await core_client.getUser(Options.UserInformationEndpoint, tokens.AccessToken, Options.Fields);
			
			var ticket = new AuthenticationTicket(new ClaimsPrincipal(identity), properties, Options.AuthenticationScheme);
			var context = new OAuthCreatingTicketContext(ticket, Context, Options, Backchannel, tokens, user);

			AddClaim(identity, ClaimTypes.NameIdentifier, VkAuthenticationHelper.GetId(user), Options.ClaimsIssuer);
			AddClaim(identity, ClaimTypes.GivenName, VkAuthenticationHelper.GetFirstName(user), Options.ClaimsIssuer);
			AddClaim(identity, ClaimTypes.Surname, VkAuthenticationHelper.GetLastName(user), Options.ClaimsIssuer);
			AddClaim(identity, ClaimTypes.Hash, VkAuthenticationHelper.GetHash(user), Options.ClaimsIssuer);
			AddClaim(identity, "urn:vkontakte:photo:link", VkAuthenticationHelper.GetPhoto(user), Options.ClaimsIssuer);
			AddClaim(identity, "urn:vkontakte:photo_thumb:link", VkAuthenticationHelper.GetPhotoThumbnail(user), Options.ClaimsIssuer);

			await Options.Events.CreatingTicket(context);

			return context.Ticket;
		}

		protected static void AddClaim(ClaimsIdentity identity, string type, string value, string claimsIssuer)
		{
			if (!string.IsNullOrEmpty(value))
			{
				identity.AddClaim(new Claim(type, value, ClaimValueTypes.String, claimsIssuer));
			}
		}

		private VkOauthProviderCore core_client;
	}
}
