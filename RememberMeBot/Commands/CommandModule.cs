using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

namespace RememberMeBot.Commands
{
    public class CommandModule : BaseCommandModule
    {
        [Command("alarm"), Description("Create a new alarm")]
        public async Task CreateAlarmCommand(CommandContext context, DateTime date)
        {
            var user = context.Member;

            await context.RespondAsync($"{user?.Mention} set new alarm to {date.ToShortTimeString()}!");
        }
    }
}
