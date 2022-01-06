using Newtonsoft.Json;

namespace CodewarsBot.Models
{
    public class UserList
    {
        [JsonProperty("users")]
        public string[] Users { get; set; }
    }
}
