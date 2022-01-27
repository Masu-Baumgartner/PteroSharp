using System;

using Newtonsoft.Json;
using RestSharp;

namespace PteroSharp.Utils
{
	public class PterodactylApiHelper
	{
		public static T Get<T>(PteroApiKeyPool pool, string url, string route, object body, out int statuscode)
		{
			RestClient client = new();

			string requrl = "NONSET";

			if (url.EndsWith("/"))
				requrl = url + route;
			else
				requrl = url + "/" + route;

			RestRequest request = new(requrl);
			var apiKey = pool.Get();
			request.AddHeader("Authorization", "Bearer " + apiKey);

			request.AddHeader("Content-Type", "application/json");
			request.AddHeader("Accept", "Application/vnd.pterodactyl.v1+json");

			if (body != null)
				request.AddJsonBody(body);

			var response = client.Get(request);

			foreach(var head in response.Headers)
            {
				if(head.Name.ToLower() == "x-ratelimit-remaining")
                {
					if(head.Value.ToString() == "1")
                    {
						pool.SetTimeout(apiKey);
                    }
                }
            }

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

		public static T Post<T>(PteroApiKeyPool pool, string url, string route, object body, out int statuscode)
		{
			RestClient client = new();

			string requrl = "NONSET";

			if (url.EndsWith("/"))
				requrl = url + route;
			else
				requrl = url + "/" + route;

			RestRequest request = new(requrl);
			var apiKey = pool.Get();
			request.AddHeader("Authorization", "Bearer " + apiKey);

			request.AddHeader("Content-Type", "application/json");
			request.AddHeader("Accept", "Application/vnd.pterodactyl.v1+json");

			request.AddParameter("text/plain", JsonConvert.SerializeObject(body), ParameterType.RequestBody);

			var response = client.Post(request);

			foreach (var head in response.Headers)
			{
				if (head.Name.ToLower() == "x-ratelimit-remaining")
				{
					if (head.Value.ToString() == "1")
					{
						pool.SetTimeout(apiKey);
					}
				}
			}

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

		public static void Post(PteroApiKeyPool pool, string url, string route, object body, out int statuscode)
		{
			RestClient client = new();

			string requrl = "NONSET";

			if (url.EndsWith("/"))
				requrl = url + route;
			else
				requrl = url + "/" + route;

			RestRequest request = new(requrl);
			var apiKey = pool.Get();
			request.AddHeader("Authorization", "Bearer " + apiKey);

			request.AddHeader("Content-Type", "application/json");
			request.AddHeader("Accept", "Application/vnd.pterodactyl.v1+json");

			request.AddParameter("text/plain", JsonConvert.SerializeObject(body), ParameterType.RequestBody);

			var response = client.Post(request);

			foreach (var head in response.Headers)
			{
				if (head.Name.ToLower() == "x-ratelimit-remaining")
				{
					if (head.Value.ToString() == "1")
					{
						pool.SetTimeout(apiKey);
					}
				}
			}

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

		public static void Delete(PteroApiKeyPool pool, string url, string route, object body, out int statuscode)
		{
			RestClient client = new();

			string requrl = "NONSET";

			if (url.EndsWith("/"))
				requrl = url + route;
			else
				requrl = url + "/" + route;

			RestRequest request = new(requrl);
			var apiKey = pool.Get();
			request.AddHeader("Authorization", "Bearer " + apiKey);

			request.AddHeader("Content-Type", "application/json");
			request.AddHeader("Accept", "Application/vnd.pterodactyl.v1+json");

			request.AddParameter("text/plain", JsonConvert.SerializeObject(body), ParameterType.RequestBody);

			var response = client.Delete(request);

			foreach (var head in response.Headers)
			{
				if (head.Name.ToLower() == "x-ratelimit-remaining")
				{
					if (head.Value.ToString() == "1")
					{
						pool.SetTimeout(apiKey);
					}
				}
			}

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

		public static void Put(PteroApiKeyPool pool, string url, string route, object body, out int statuscode)
		{
			RestClient client = new();

			string requrl = "NONSET";

			if (url.EndsWith("/"))
				requrl = url + route;
			else
				requrl = url + "/" + route;

			RestRequest request = new(requrl);
			var apiKey = pool.Get();
			request.AddHeader("Authorization", "Bearer " + apiKey);

			request.AddHeader("Content-Type", "application/json");
			request.AddHeader("Accept", "Application/vnd.pterodactyl.v1+json");

			request.AddParameter("text/plain", JsonConvert.SerializeObject(body), ParameterType.RequestBody);

			var response = client.Put(request);

			foreach (var head in response.Headers)
			{
				if (head.Name.ToLower() == "x-ratelimit-remaining")
				{
					if (head.Value.ToString() == "1")
					{
						pool.SetTimeout(apiKey);
					}
				}
			}

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

		public static T Patch<T>(PteroApiKeyPool pool, string url, string route, object body, out int statuscode)
		{
			RestClient client = new();

			string requrl = "NONSET";

			if (url.EndsWith("/"))
				requrl = url + route;
			else
				requrl = url + "/" + route;

			RestRequest request = new(requrl);
			var apiKey = pool.Get();
			request.AddHeader("Authorization", "Bearer " + apiKey);

			request.AddHeader("Content-Type", "application/json");
			request.AddHeader("Accept", "Application/vnd.pterodactyl.v1+json");

			request.AddParameter("text/plain", JsonConvert.SerializeObject(body), ParameterType.RequestBody);

			var response = client.Patch(request);

			foreach (var head in response.Headers)
			{
				if (head.Name.ToLower() == "x-ratelimit-remaining")
				{
					if (head.Value.ToString() == "1")
					{
						pool.SetTimeout(apiKey);
					}
				}
			}

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

		public static void Patch(PteroApiKeyPool pool, string url, string route, object body, out int statuscode)
		{
			RestClient client = new();

			string requrl = "NONSET";

			if (url.EndsWith("/"))
				requrl = url + route;
			else
				requrl = url + "/" + route;

			RestRequest request = new(requrl);
			var apiKey = pool.Get();
			request.AddHeader("Authorization", "Bearer " + apiKey);

			request.AddHeader("Content-Type", "application/json");
			request.AddHeader("Accept", "Application/vnd.pterodactyl.v1+json");

			request.AddParameter("text/plain", JsonConvert.SerializeObject(body), ParameterType.RequestBody);

			var response = client.Patch(request);

			foreach (var head in response.Headers)
			{
				if (head.Name.ToLower() == "x-ratelimit-remaining")
				{
					if (head.Value.ToString() == "1")
					{
						pool.SetTimeout(apiKey);
					}
				}
			}

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
	}
}
