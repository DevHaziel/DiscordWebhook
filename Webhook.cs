using System.Linq;

namespace DiscordWebhook
{
    public class Webhook
    {
        public Webhook(string username = "Discord Webhook", Embed[] embeds = null)
        {
            this.username = username;
            this.avatar_url = avatar_url;
            this.embeds = embeds;
            this.content = "";
        }
        public void Message(string content)
        {
            this.content = content;
        }
        public void SetAvatar(string avatar_url)
        {
            this.avatar_url = avatar_url;
        }
        public void AddEmbed(Embed embed)
        {
            this.embeds.Append(embed);
        }
        public string username { get; private set; }
        public string avatar_url { get; private set; }
        public string content { get; private set; }
        public Embed[] embeds { get; private set; }
    }
}
