namespace CodewarsBot
{
    public class Program
    {
        static void Main(string[] args)
        {
            CodewarsBot bot = new CodewarsBot();

            var leaderboard = bot.GenerateClanLeaderboard();
            bot.SendClanLeaderboard(leaderboard);

        }
    }
}
