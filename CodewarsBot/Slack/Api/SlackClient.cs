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
        private readonly string _webhookDetailsUrl;

        public SlackClient()
        {
            var webhookBaseUrl = ConfigurationManager.AppSettings["SlackWebHookBaseUrl"];
            _webhookDetailsUrl = ConfigurationManager.AppSettings["SlackWebHookDetailsUrl"];
            _client = new RestClient(webhookBaseUrl);
        }

        public bool PostLeaderboardToSlack(string leaderboard)
        {
            RestRequest request = new RestRequest(_webhookDetailsUrl, Method.POST);

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
