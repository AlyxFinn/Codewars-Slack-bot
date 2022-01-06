using CodewarsBot.Slack.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Configuration;
using System.Net;

namespace CodewarsBot.Slack.Api
{
    public class SlackClient : ISlackClient
    {
        private readonly IRestClient _client;

        public SlackClient()
        {
            var webhook = ConfigurationManager.AppSettings["SlackWebHook"];
            _client = new RestClient(webhook);
        }

        public bool PostLeaderboardToSlack(string leaderboard)
        {
            const string endpoint = "/T02T116NZTM/B02TQNED7U0/8kvEzRyUjtXQSP6No9CeRUAV";
            RestRequest request = new RestRequest(endpoint, Method.POST);

            request.AddHeader("Content-Type", "application/json");

            var message = new SlackMessage
            {
                Text = leaderboard
            };

            var requestBody = JsonConvert.SerializeObject(message);
            request.AddParameter("application/json", requestBody, ParameterType.RequestBody);

            try
            {
                var response = _client.Execute(request);

                if (response.StatusCode == HttpStatusCode.OK && response.Content == "ok")
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return false;
        }
    }

    public interface ISlackClient
    {
        bool PostLeaderboardToSlack(string leaderboard);
    }
}
