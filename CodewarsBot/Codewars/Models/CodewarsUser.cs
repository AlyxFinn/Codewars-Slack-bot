using Newtonsoft.Json;

namespace CodewarsBot.Codewars.Models
{
    public class CodewarsUser
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("honor")]
        public long Honour { get; set; }

        [JsonProperty("clan")]
        public string Clan { get; set; }

        [JsonProperty("leaderboardPosition")]
        public long? LeaderboardPosition { get; set; }

        [JsonProperty("skills")]
        public string[] Skills { get; set; }

        [JsonProperty("ranks")]
        public RankModel Ranks { get; set; }

        [JsonProperty("codeChallenges")]
        public CodeChallengesModel CodeChallenges { get; set; }
    }

    public class RankModel
    {
        [JsonProperty("overall")]
        public RankDetails Overall { get; set; }

        [JsonProperty("languages")]
        public LanguagesModel Languages { get; set; }
    }

    public class LanguagesModel
    {
        [JsonProperty("csharp")]
        public RankDetails CSharp { get; set; }

        [JsonProperty("javascript")]
        public RankDetails Javascript { get; set; }
    }

    public class RankDetails
    {
        [JsonProperty("rank")]
        public int Rank { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("color")]
        public string Colour { get; set; }

        [JsonProperty("score")]
        public long Score { get; set; }
    }

    public class CodeChallengesModel
    {
        [JsonProperty("totalAuthored")]
        public long TotalAuthored { get; set; }

        [JsonProperty("totalCompleted")]
        public long TotalCompleted { get; set; }
    }
}
