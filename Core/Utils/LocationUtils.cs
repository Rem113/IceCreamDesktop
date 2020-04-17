using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace IceCreamDesktop.Core.Utils
{
	public class LocationUtils
	{
		private static string ApiKey = "hCitUxJK3IW1if9qC1DJ~iRHsZluzm1HBR2I5eu9cAQ~AoqIa1TgYbRM5O8Eux2VQmuJu-IB7qAvQfcPDIGbXYyTEPxyWB2EaTbThjIXs-Dc";

		public static async Task<(double, double)> GetLatLong(string address)
		{
			using (var client = new HttpClient())
			{
				var response = await client.GetAsync("http://dev.virtualearth.net/REST/v1/Locations?key=" + ApiKey + "&query=" + address);
				var content = response.Content;

				var result = await content.ReadAsStringAsync();
				var json = JObject.Parse(result);

				var resourceSets = json["resourceSets"] as JArray;
				var resources = resourceSets[0]["resources"];

				var coordinates = resources[0]["point"]["coordinates"] as JArray;
				return ((double)coordinates[0], (double)coordinates[1]);
			}
		}
	}
}