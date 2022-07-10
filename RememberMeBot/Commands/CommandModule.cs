using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RememberMeBot.Commands
{
    public class CommandModule : BaseCommandModule
    {
        [Command("alarm")]
        public async Task CreateAlarmCommand(CommandContext context, DateTime date)
        {
            var user = context.Member;

            await context.RespondAsync($"{user?.Mention} set new alarm to {date.ToShortTimeString()}!");
        }
    }
}
