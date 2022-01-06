using CodewarsBot.Codewars.Api;
using CodewarsBot.Codewars.Models;
using CodewarsBot.Models;
using CodewarsBot.Slack.Api;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodewarsBot
{
    public class CodewarsBot
    {
        private readonly string[] _users;
        private readonly ICodewarsClient _codewarsClient;
        private readonly ISlackClient _slackClient;

        public CodewarsBot()
        {
            var usersFile = File.ReadAllText("App_Data/users.json");
            var usersList = JsonConvert.DeserializeObject<UserList>(usersFile);

            _users = usersList.Users;
            _codewarsClient = new CodewarsClient();
            _slackClient = new SlackClient();
        }

        // Need to refactor return type maybe?
        public string GenerateClanLeaderboard()
        {
            List<CodewarsUser> users = new List<CodewarsUser>();

            foreach(var user in _users)
            {
                var userDetails = _codewarsClient.GetCodewarsUser(user);
                users.Add(userDetails);
            }

            CodewarsUser[] leaderboard = users.OrderByDescending(u => u.Honour).ToArray();

            var result = string.Empty;
            for (var i = 0; i <= _users.Length - 1; i++)
            {
                result += $"{i + 1}. {leaderboard[i].Username} - {leaderboard[i].Honour}\n";
            }

            return result;
        }

        public void SendClanLeaderboard(string leaderboard)
        {
            var success = _slackClient.PostLeaderboardToSlack(leaderboard);

            if (!success)
            {
                throw new Exception("There was an error posting the leaderboard to Slack.");
            }
        }
    }
}
