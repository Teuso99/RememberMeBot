using DSharpPlus;
using DSharpPlus.EventArgs;

namespace RememberMeBot
{
    public class RememberMeBot
    {
        public void Initialize(DiscordClient client)
        {
            client.MessageCreated += OnMesseageCreated;
        }

        private async Task OnMesseageCreated(DiscordClient client, MessageCreateEventArgs args)
        {
            if (args.Message.Content.StartsWith("--"))
            {
                await client.SendMessageAsync(args.Channel, "teste");
            }
        }
    }
}
