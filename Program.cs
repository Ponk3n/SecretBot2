using Discord;
using Discord.WebSocket;
using SecretBot123.Core.Commands;
using System;
using System.IO;
using System.Threading.Tasks;

namespace SecretBot123
{
    class Program
    {
        public DiscordSocketClient Client;
        public CommandHandler Handler;

        static void Main(string[] args) => new Program().MainAsync().GetAwaiter().GetResult();
        string token = "";

        public async Task MainAsync()
        {
            Client = new DiscordSocketClient(new DiscordSocketConfig
            { 
                // Logseverity decides how verbouse the information going to be in the console
                LogLevel = LogSeverity.Info
            });

            Client.Log += Log;
            Client.MessageReceived += MessageRecieved;

            // Creating a stream so the discord token isn't visible in here for security reasons

            try
            {
                StreamReader sr = new StreamReader("Token.txt");
                token = sr.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

            Handler = new CommandHandler();
            await Client.LoginAsync(TokenType.Bot, token, true);

            await Client.StartAsync();
            await Handler.Install(Client);

            Client.Ready += Client_Ready;
            await Task.Delay(-1);

        }

        // msg.Channel.GetType pulls what channel the message was sent in and then DateTime pulls the date/time
        // then the username is conveyed from msg.Author and msg.ToString pulls the message
        private async Task MessageRecieved(SocketMessage msg)
        {
            Console.WriteLine("\n......\n" + msg.Channel.GetType() + $"\n{DateTime.Now} {msg.Author}: " 
                + msg.ToString() + "\n......");
            await Task.CompletedTask;
        }

        private async Task Client_Ready()
        {
            //conveys to the console that the bot is up and running
            Console.WriteLine("\nOnline...\n");

            // put message in the discord client as "playing game ... {message}"
            await Client.SetGameAsync("??help");
        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
    }
}
