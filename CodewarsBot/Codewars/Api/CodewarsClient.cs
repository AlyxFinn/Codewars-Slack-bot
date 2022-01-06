using CodewarsBot.Codewars.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Configuration;

namespace CodewarsBot.Codewars.Api
{
    public class CodewarsClient : ICodewarsClient
    {
        private readonly IRestClient _client;

        public CodewarsClient()
        {
            string baseUrl = ConfigurationManager.AppSettings["CodewarsApiUrl"];
            _client = new RestClient(baseUrl);
        }

        public CodewarsUser GetCodewarsUser(string username)
        {
            string endpoint = $"/users/{username}";

            RestRequest request = new RestRequest(endpoint, Method.GET);

            request.AddHeader("Accept", "application/json");
            CodewarsUser jsonResponse;

            try
            {
                var response = _client.Execute(request);
                jsonResponse = JsonConvert.DeserializeObject<CodewarsUser>(response.Content);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return jsonResponse;
        }
    }

    public interface ICodewarsClient
    {
        CodewarsUser GetCodewarsUser(string username);
    }
}
