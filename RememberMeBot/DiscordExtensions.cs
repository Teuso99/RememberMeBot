using DSharpPlus;

namespace RememberMeBot
{
    public static class DiscordExtensions
    {
        private static RememberMeBot? _bot;

        public static DiscordClient AddRememberMeBot(this DiscordClient client)
        {
            _bot = new RememberMeBot();
            _bot.Initialize(client);

            return client;
        }
    }
}
