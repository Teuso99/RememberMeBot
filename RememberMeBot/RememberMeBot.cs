using DSharpPlus;
using DSharpPlus.CommandsNext;
using RememberMeBot.Commands;

namespace RememberMeBot
{
    public class RememberMeBot
    {
        public void Initialize(DiscordClient client)
        {
            var commands = client.UseCommandsNext(new CommandsNextConfiguration()
            {
                StringPrefixes = new[] { "!" }
            });

            commands.RegisterCommands<CommandModule>();

            commands.SetHelpFormatter<CustomHelpFormatter>();
        }
    }
}
