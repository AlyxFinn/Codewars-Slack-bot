using Newtonsoft.Json;

namespace CodewarsBot.Slack.Models
{
    public class SlackMessage
    {
        [JsonProperty("text")]
        public string Text { get; set; }
    }
}
