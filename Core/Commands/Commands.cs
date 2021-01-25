using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SecretBot123.Core.Commands
{
    class Commands : ModuleBase
    {
        [Command("help")]
        public async Task Help()
        {
            EmbedBuilder Embed = new EmbedBuilder();

            Embed.WithColor(40, 200, 150)
                .WithTitle("Help")
                .WithDescription("Work in progress :)\n\n")
                .AddField("**Commands:**",
                "\n**??hello**"
                + "\n**??kaffe**"
                + "\n**??vatten**")
                .WithFooter(footer => footer.Text = "Hej")
                .WithCurrentTimestamp();

            await Context.Channel.SendMessageAsync("", false, Embed.Build());
        }

        [Command("kaffe")]
        public async Task Kafe()
        {
            await ReplyAsync("Killar det finns kaffe nu");
        }

        [Command("vatten")]
        public async Task Vatten()
        {
            await ReplyAsync("Det finns vatten här");
        }
    }
}
