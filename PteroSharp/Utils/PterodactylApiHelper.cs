using System;

using Newtonsoft.Json;
using RestSharp;

namespace PteroSharp.Utils
{
	public class PterodactylApiHelper
	{
		public static T Get<T>(string apiKey, string url, string route, object body, out int statuscode)
		{
			RestClient client = new();

			string requrl = "NONSET";

			if (url.EndsWith("/"))
				requrl = url + route;
			else
				requrl = url + "/" + route;

			RestRequest request = new(requrl);

			request.AddHeader("Authorization", "Bearer " + apiKey);

			request.AddHeader("Content-Type", "application/json");
			request.AddHeader("Accept", "Application/vnd.pterodactyl.v1+json");

			if (body != null)
				request.AddJsonBody(body);

			var response = client.Get(request);

			statuscode = ((int)response.StatusCode);

			if (!response.IsSuccessful)
			{
				if (response.StatusCode != 0)
				{
					throw new System.Exception($"An error occured: ({response.StatusCode}) {response.Content}");
				}
				else
				{
					throw new System.Exception($"An internal error occured: {response.ErrorMessage}");
				}
			}

			return JsonConvert.DeserializeObject<T>(response.Content);
		}

		public static T Post<T>(string apiKey, string url, string route, object body, out int statuscode)
		{
			RestClient client = new();

			string requrl = "NONSET";

			if (url.EndsWith("/"))
				requrl = url + route;
			else
				requrl = url + "/" + route;

			RestRequest request = new(requrl);

			request.AddHeader("Authorization", "Bearer " + apiKey);

			request.AddHeader("Content-Type", "application/json");
			request.AddHeader("Accept", "Application/vnd.pterodactyl.v1+json");

			request.AddParameter("text/plain", JsonConvert.SerializeObject(body), ParameterType.RequestBody);

			var response = client.Post(request);

			statuscode = ((int)response.StatusCode);

			if (!response.IsSuccessful)
			{
				if (response.StatusCode != 0)
				{
					throw new System.Exception($"An error occured: ({response.StatusCode}) {response.Content}");
				}
				else
				{
					throw new System.Exception($"An internal error occured: {response.ErrorMessage}");
				}
			}

			return JsonConvert.DeserializeObject<T>(response.Content);
		}

		public static void Post(string apiKey, string url, string route, object body, out int statuscode)
		{
			RestClient client = new();

			string requrl = "NONSET";

			if (url.EndsWith("/"))
				requrl = url + route;
			else
				requrl = url + "/" + route;

			RestRequest request = new(requrl);

			request.AddHeader("Authorization", "Bearer " + apiKey);

			request.AddHeader("Content-Type", "application/json");
			request.AddHeader("Accept", "Application/vnd.pterodactyl.v1+json");

			request.AddParameter("text/plain", JsonConvert.SerializeObject(body), ParameterType.RequestBody);

			var response = client.Post(request);

			statuscode = ((int)response.StatusCode);

			if (!response.IsSuccessful)
			{
				if (response.StatusCode != 0)
				{
					throw new System.Exception($"An error occured: ({response.StatusCode}) {response.Content}");
				}
				else
				{
					throw new System.Exception($"An internal error occured: {response.ErrorMessage}");
				}
			}
		}

		public static void Delete(string apiKey, string url, string route, object body, out int statuscode)
		{
			RestClient client = new();

			string requrl = "NONSET";

			if (url.EndsWith("/"))
				requrl = url + route;
			else
				requrl = url + "/" + route;

			RestRequest request = new(requrl);

			request.AddHeader("Authorization", "Bearer " + apiKey);

			request.AddHeader("Content-Type", "application/json");
			request.AddHeader("Accept", "Application/vnd.pterodactyl.v1+json");

			request.AddParameter("text/plain", JsonConvert.SerializeObject(body), ParameterType.RequestBody);

			var response = client.Delete(request);

			statuscode = ((int)response.StatusCode);

			if (!response.IsSuccessful)
			{
				if (response.StatusCode != 0)
				{
					throw new System.Exception($"An error occured: ({response.StatusCode}) {response.Content}");
				}
				else
				{
					throw new System.Exception($"An internal error occured: {response.ErrorMessage}");
				}
			}
		}

		public static void Put(string apiKey, string url, string route, object body, out int statuscode)
		{
			RestClient client = new();

			string requrl = "NONSET";

			if (url.EndsWith("/"))
				requrl = url + route;
			else
				requrl = url + "/" + route;

			RestRequest request = new(requrl);

			request.AddHeader("Authorization", "Bearer " + apiKey);

			request.AddHeader("Content-Type", "application/json");
			request.AddHeader("Accept", "Application/vnd.pterodactyl.v1+json");

			request.AddParameter("text/plain", JsonConvert.SerializeObject(body), ParameterType.RequestBody);

			var response = client.Put(request);

			statuscode = ((int)response.StatusCode);

			if (!response.IsSuccessful)
			{
				if (response.StatusCode != 0)
				{
					throw new System.Exception($"An error occured: ({response.StatusCode}) {response.Content}");
				}
				else
				{
					throw new System.Exception($"An internal error occured: {response.ErrorMessage}");
				}
			}
		}

		public static T Patch<T>(string apiKey, string url, string route, object body, out int statuscode)
		{
			RestClient client = new();

			string requrl = "NONSET";

			if (url.EndsWith("/"))
				requrl = url + route;
			else
				requrl = url + "/" + route;

			RestRequest request = new(requrl);

			request.AddHeader("Authorization", "Bearer " + apiKey);

			request.AddHeader("Content-Type", "application/json");
			request.AddHeader("Accept", "Application/vnd.pterodactyl.v1+json");

			request.AddParameter("text/plain", JsonConvert.SerializeObject(body), ParameterType.RequestBody);

			var response = client.Patch(request);

			statuscode = ((int)response.StatusCode);

			if (!response.IsSuccessful)
			{
				if (response.StatusCode != 0)
				{
					throw new System.Exception($"An error occured: ({response.StatusCode}) {response.Content}");
				}
				else
				{
					throw new System.Exception($"An internal error occured: {response.ErrorMessage}");
				}
			}

			return JsonConvert.DeserializeObject<T>(response.Content);
		}
	}
}
