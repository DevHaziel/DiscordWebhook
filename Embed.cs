using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace DiscordWebhook
{
    public class Embed
    {
        public Embed()
        {
            fields = new List<Field>();
        }
        public void SetTitle(string title)
        {
            this.title = title;
        }
        public void SetColor(string color)
        {
            this.color = Color.FromHex(color);
        }
        public void SetDescription(string description)
        {
            this.description = description;
        }
        public void SetFormattedDescription(string description, object[] args)
        {
            if(this.description != null)
                this.description = string.Format(description, args);
        }
        public void SetTimestamp(string timestamp)
        {
            this.timestamp = timestamp;
        }
        public void SetUrl(string url)
        {
            this.url = url;
        }
        public void SetAuthor(string name, string url = "", string icon_url = "")
        {
            this.author = new Dictionary<string, string>
            {
                { "name", name },
                { "url", url },
                { "icon_url", icon_url }
            };
        }
        public void SetImage(string url)
        {
            this.image = new Dictionary<string, string>
            {
                { "url", url }
            };
        }
        public void SetThumbnail(string url)
        {
            this.thumbnail = new Dictionary<string, string>
            {
                { "url", url }
            };
        }
        public void SetFooter(string text, string icon_url = "")
        {
            this.footer = new Dictionary<string, string>
            {
                { "text", text },
                { "icon_url", icon_url }
            };
        }
        public void AddField(string name, string value, bool inline = false)
        {
            this.fields.Add(new Field(name, value, inline));
        }
        public void AddFields(Field[] fields)
        {
            this.fields.AddRange(fields.ToList());
        }
        public string title { get; private set; }
        public int color { get; private set; }
        public string description { get; private set; }
        public string timestamp { get; private set; }
        public string url { get; private set; }
        public Dictionary<string, string> author { get; private set; }
        public Dictionary<string, string> image { get; private set; }
        public Dictionary<string, string> thumbnail { get; private set; }
        public Dictionary<string, string> footer { get; private set; }
        public List<Field> fields { get; private set; }
    }
    public class Field
    {
        public Field(string name, string value, bool inline)
        {
            this.name = name;
            this.value = value;
            this.inline = inline;
        }
        public void SetFormattedValue(string value, object[] args)
        {
            if(this.value != null)
                this.value = string.Format(value, args);
        }

        public string name { get; set; }
        public string value { get; set; }
        public bool inline { get; set; }
    }
}
