using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace TableList.Auth.Core.oauth.vk
{
	public class VkOauthProviderCore
    {
		public VkOauthProviderCore(CancellationToken cancelToken)
		{
			this.cancelToken = cancelToken;

		}

		public async Task<JObject> getUser(string url, string accessToken, ICollection<string> fields)
		{
			using (var client = new HttpClient())
			{
				var address = QueryHelpers.AddQueryString(url, "access_token", accessToken);

				if (fields.Count != 0)
				{
					address = QueryHelpers.AddQueryString(address, "fields", string.Join(",", fields));
				}

				var response = await client.GetAsync(address, cancelToken);
				if (!response.IsSuccessStatusCode)
				{
					throw new HttpRequestException("An error occurred while retrieving the user profile.");
				}

				var payload = JObject.Parse(await response.Content.ReadAsStringAsync());
				var user = (JObject)payload["response"][0];

				return user;
			}
		}

		private CancellationToken cancelToken;
	}
}
