using DSharpPlus;
using Microsoft.Extensions.Configuration;
using RememberMeBot;

var enviroment = Environment.GetEnvironmentVariable("NETCORE_ENVIROMENT");

IConfiguration Config = new ConfigurationBuilder()
                        .AddJsonFile($"appsettings.json")
                        .AddJsonFile($"appsettings.{enviroment}.json")
                        .AddEnvironmentVariables().Build();

var token = Config.GetSection("ConnectionStrings")["DiscordToken"];

var client = new DiscordClient(new DiscordConfiguration
{
    Token = token,
    TokenType = TokenType.Bot
});

client.AddRememberMeBot();

await client.ConnectAsync();

Console.WriteLine($"Bots onlines!");

await Task.Delay(-1);