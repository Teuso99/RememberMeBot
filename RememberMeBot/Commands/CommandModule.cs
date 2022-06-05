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
        [Command("teste")]
        public async Task TestCommand(CommandContext context, DateTime date)
        {
            await context.RespondAsync($"vai toma no cu tranquilo falo {date.ToShortTimeString()}");
        }
    }
}
