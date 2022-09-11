using DSharpPlus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
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
    TokenType = TokenType.Bot,
    MinimumLogLevel = LogLevel.Debug
});

client.AddRememberMeBot();

await client.ConnectAsync();

var channelId = Config.GetSection("ConnectionStrings")["ChannelId"];
var channel = await client.GetChannelAsync(ulong.Parse(channelId));

var userId = Config.GetSection("ConnectionStrings")["UserId"];
var user = await client.GetUserAsync(ulong.Parse(userId));

Console.WriteLine($"Bots onlines!");

while (true)
{
    var msg = ReceiveAlarmTrigger.TriggerAlarm(user);

    if (msg != null)
    {
        await client.SendMessageAsync(channel, msg);
    }
}