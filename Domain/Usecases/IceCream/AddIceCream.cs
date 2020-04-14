using IceCreamDesktop.Core.Entities;
using IceCreamDesktop.Core.Failures;
using IceCreamDesktop.Domain.Interfaces;
using Monad;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace IceCreamDesktop.Domain.Usecases
{
	public class AddIceCream : IUsecase<Either<Failure, IceCream>, AddIceCreamArgs>
	{
		private readonly IIceCreamRepository Repository;

		public AddIceCream(IIceCreamRepository repository)
		{
			Repository = repository;
		}

		private static readonly List<string> ValidTags = new List<string> { "ice", "cream", "food" };

		private async Task<bool> CheckImage(string imageUrl)
		{
			string apiKey = "acc_ae1dfdc132382d6";
			string apiSecret = "0f236e11c14a4e160f679b32e998f5cb";

			string basicAuthValue = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(string.Format("{0}:{1}", apiKey, apiSecret)));

			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri("https://api.imagga.com/v2/");
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				client.DefaultRequestHeaders.Add("Authorization", string.Format("Basic {0}", basicAuthValue));

				HttpResponseMessage response = await client.GetAsync(string.Format("tags?image_url={0}", imageUrl));

				HttpContent content = response.Content;
				string result = await content.ReadAsStringAsync();
				var res = JObject.Parse(result);

				if (!res.ContainsKey("result")) return false;

				var tags = res["result"]["tags"] as JArray;

				foreach (var tag in tags)
					if (ValidTags.Contains(tag["tag"]["en"].ToString())) return true;
			}

			return false;
		}

		private async Task<object> GetNutritionalInfo(string iceCreamName)
		{
			string apiKey = "Rh3Mgm9Ej6Cf2Gu2uq4AdTRs8OXVtoUKYzRwKZIC";

			using (var client = new HttpClient())
			{
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
				var builder = new UriBuilder("https://api.nal.usda.gov/fdc/v1/foods/search");
				builder.Query = "api_key=" + apiKey + "&query=" + iceCreamName;

				HttpResponseMessage response = await client.GetAsync(builder.Uri);

				HttpContent content = response.Content;
				string result = await content.ReadAsStringAsync();

				Debug.WriteLine(result);

				return result;
			}
		}

		public async Task<Either<Failure, IceCream>> Call(AddIceCreamArgs args)
		{
			var isValidImage = await CheckImage(args.IceCream.ImageUrl);
			// TODO: Change Failure type
			if (!isValidImage) return () => new DataAccessFailure("Please enter a valid image url");

			var info = await GetNutritionalInfo(args.IceCream.Name);

			return await Repository.AddIceCream(args.IceCream);
		}
	}

	public class AddIceCreamArgs : IArgs
	{
		public IceCream IceCream { get; }

		public AddIceCreamArgs(IceCream iceCream)
		{
			IceCream = iceCream;
		}
	}
}