using System.Security.Cryptography;
using System.Text;
using Cowsay;
using Discord;
using Discord.WebSocket;
using Serilog;
using Serilog.Events;


namespace CowGoesMoo;

public class MooCowBot
{
    private static readonly ulong AdminId = ulong.Parse(Environment.GetEnvironmentVariable("MOOBOTADMIN") ?? throw new ArgumentNullException($"Missing MOOBOTADMIN environment variable"));
    private static readonly string DiscordToken = Environment.GetEnvironmentVariable("MOOBOTTOKEN") ?? throw new ArgumentException("Missing MOOBOTTOKEN environment variable");
    private static readonly string LogoUrl = Environment.GetEnvironmentVariable("MOOBOTLOGOURL") ?? throw new ArgumentException("Missing MOOBOTLOGO environment variable");
    
    private static DiscordSocketClient? _client;

    private static void Main() => new MooCowBot().MainAsync().GetAwaiter().GetResult();

    private async Task MainAsync()
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Verbose()
            .Enrich.FromLogContext()
            .Enrich.WithProperty("Source", "MooCowBot")
            .WriteTo.Console(outputTemplate: "{Timestamp:HH:mm:ss} [{Level}] [{Source}] {Message}{NewLine}{Exception}")
            .CreateLogger();
        
        var config = new DiscordSocketConfig()
        {
            GatewayIntents = GatewayIntents.AllUnprivileged | GatewayIntents.MessageContent
        };
        _client = new DiscordSocketClient(config);
        _client.Log += LogAsync;

        await _client.LoginAsync(TokenType.Bot, DiscordToken);
        await _client.StartAsync();
        
        _client.MessageReceived += MessageReceived;

        _client.Ready += () =>
        {
            Log.Information("{LoginState}", _client.LoginState);
            return Task.CompletedTask;
        };
        
        await Task.Delay(Timeout.Infinite);
    }

    private static async Task LogAsync(LogMessage message)
    {
        var severity = message.Severity switch
        {
            LogSeverity.Critical => LogEventLevel.Fatal,
            LogSeverity.Error => LogEventLevel.Error,
            LogSeverity.Warning => LogEventLevel.Warning,
            LogSeverity.Info => LogEventLevel.Information,
            LogSeverity.Verbose => LogEventLevel.Verbose,
            LogSeverity.Debug => LogEventLevel.Debug,
            _ => LogEventLevel.Information
        };
        Log.Write(severity, message.Exception, "{Message}", message.Message);
        await Task.CompletedTask;
    }

    private static async Task MessageReceived(SocketMessage message)
    {
        await Task.Run(async () => 
        {
            if (message.Author.Id == AdminId)
            {
                if (message.CleanContent.Equals("ping", StringComparison.CurrentCultureIgnoreCase))
                {
                    var replyMessageChannel = (IMessageChannel)await _client!.GetChannelAsync(message.Channel.Id);
                    var pongCow = await DefaultCattleFarmer.RearCowWithDefaults($"{CowTypesExtensions.GetRandomCowType().GetEnumDescription()}");
                    var pongText = $"```{pongCow.Say("*Pong*")}```";
                    await replyMessageChannel.SendMessageAsync(pongText);
                }

                if (message.CleanContent.Equals("about cow"))
                {
                    var replyMessageChannel = (IMessageChannel)await _client!.GetChannelAsync(message.Channel.Id);
                    var embed = new EmbedBuilder
                    {
                        Title = "About Cow Goes Moo!",
                        Description =
                            "The Cow Goes Moo is just a silly Discord bot made in an afternoon for my own amusement.  More information can be found at the GitHub - https://github.com/nkbooth/cowGoesMooDiscordBot",
                        ImageUrl = LogoUrl,
                        Author = new EmbedAuthorBuilder { Name = message.Author.Username }
                    };
                    embed.AddField("Servers", _client.Guilds.Count)
                        .AddField("Latency", _client.Latency)
                        .WithUrl("https://github.com/nkbooth/cowGoesMooDiscordBot")
                        .WithCurrentTimestamp();
                    
                    await replyMessageChannel.SendMessageAsync(embed: embed.Build());
                    var mooingCow =
                        await DefaultCattleFarmer.RearCowWithDefaults($"{CowTypes.Default.GetEnumDescription()}");
                    await replyMessageChannel.SendMessageAsync($"```{mooingCow.Say("Moo", isThought: false)}```");
                }

                if (message.CleanContent.Equals("list servers", StringComparison.InvariantCultureIgnoreCase))
                {
                    var replyMessageChannel = (IMessageChannel)await _client!.GetChannelAsync(message.Channel.Id);
                    var replyText = new StringBuilder();
                    replyText.AppendLine("The Moo Cow is in the following servers:");
                    foreach (var server in _client.Guilds)
                    {
                        replyText.AppendLine($"* {server.Name} - {server.Description ?? "No Description"}");
                    }
                    
                    await replyMessageChannel.SendMessageAsync(replyText.ToString());
                }
            }

            else if (RandomNumberGenerator.GetInt32(int.MinValue, int.MaxValue) % 2046 == 0 && message.Author.IsBot == false)
            {
                const CowTypes cowType = CowTypes.Default;
                var myCow = await DefaultCattleFarmer.RearCowWithDefaults($"{cowType.GetEnumDescription()}");
            
                var cowReply = (IMessageChannel)await _client!.GetChannelAsync(message.Channel.Id);
                var replyText =
                    $"<@{message.Author.Id}> - the cow heard you and agrees with you.\n```{myCow.Say(message.CleanContent)}```";
                await cowReply.SendMessageAsync(replyText[..Int32.Min(replyText.Length, 1999)]);
            }
        });
    }
}

