# RememberMeBot


## About
This repo contains the project used to create a discord bot for creating and triggering alarms. This project was created using .NET 6.0 and RabbitMQ 3.10.6.

## How to use
First clone this repo:

```
git clone https://github.com/Teuso99/RememberMeBot.git
```

After that run the restore command on the root folder of the project:

```
dotnet restore
```

After the build, go into the **`RememberMeBot`** project folder and change the connection strings in the **`appsettings.json`** file.

```json
"ConnectionStrings": {
    "DiscordToken": "token",
    "ChannelId": "id",
    "UserId": "id"
  }
```

The first field is the **`DiscordToken`** and that is the token of your bot, which you can get in the **[Discord Developer Portal](https://discord.com/developers/applications)**.

**DO NOT UPLOAD CODE WITH YOUR TOKEN EXPOSED.** Discord has a security measure so your token won't be stolen, however you'll need to generate another token.

In this project, **enviroment variables** was used to create a **`appsettings.prod.json`** and then put this file on **`.gitignore`**, so it will be only avaliable locally. You can use the **`appsettings.dev.json`** for the same purpose, just remember to add the file in the **`.gitignore`**. 

Both the second and the third field are obtainable in the **discord app**, you just need to enable **DEV mode** and then right click on the text channel and your user and you should see an option to get the id.

After that you can run both the **`RememberMeBot`** project and the **`RememberMeBot.Worker`** project using the run command:

```
dotnet run
```

## License
This project is for study purposes only. Feel free to use.