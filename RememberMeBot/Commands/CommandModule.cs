using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

namespace RememberMeBot.Commands
{
    public class CommandModule : BaseCommandModule
    {
        [Command("alarm"), Description("Create a new alarm")]
        public async Task CreateAlarmCommand(CommandContext context, DateTime date)
        {
            if (!SendAlarm.Send(date.ToShortTimeString()))
            {
                await context.RespondAsync($"Error setting new alarm to {date.ToShortTimeString()}!");
                return;
            }

            var user = context.Member;

            await context.RespondAsync($"{user?.Mention} set new alarm to {date.ToShortTimeString()}!");
        }
    }
}
