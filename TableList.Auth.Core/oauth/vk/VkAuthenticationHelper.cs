using Newtonsoft.Json.Linq;

namespace TableList.Auth.Core.oauth.vk
{
	public class VkAuthenticationHelper
    {
		/// <summary>
		/// Gets the identifier associated with the logged in user.
		/// </summary>
		public static string GetId(JObject user) => user.Value<string>("uid");

		/// <summary>
		/// Gets the hash for checking authorization on the remote client.
		/// </summary>
		public static string GetHash(JObject user) => user.Value<string>("hash");

		/// <summary>
		/// Gets the first name associated with the logged in user.
		/// </summary>
		public static string GetFirstName(JObject user) => user.Value<string>("first_name");

		/// <summary>
		/// Gets the last name associated with the logged in user.
		/// </summary>
		public static string GetLastName(JObject user) => user.Value<string>("last_name");

		/// <summary>
		/// Gets the URL of the user profile picture.
		/// </summary>
		public static string GetPhoto(JObject user) => user.Value<string>("photo");

		/// <summary>
		/// Gets the URL of the user profile thumbnail.
		/// </summary>
		public static string GetPhotoThumbnail(JObject user) => user.Value<string>("photo_rec");
	}
}
