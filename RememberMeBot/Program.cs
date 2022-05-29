using DSharpPlus;
using Microsoft.Extensions.Hosting;

using IHost host = Host.CreateDefaultBuilder(args).Build();

var client = new DiscordClient(new DiscordConfiguration
{
    Token = "",
    TokenType = TokenType.Bot
});

await host.RunAsync();