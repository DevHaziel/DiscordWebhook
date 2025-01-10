using System.Collections.Generic;

namespace DiscordWebhook
{
    public class Embed
    {
        public Embed()
        {
            fields = new List<Field>();
        }
        public void Title(string title)
        {
            this.title = title;
        }
        public void Color(int color)
        {
            this.color = color;
        }
        public void Description(string description)
        {
            this.description = description;
        }
        public void Timestamp(string timestamp)
        {
            this.timestamp = timestamp;
        }
        public void Url(string url)
        {
            this.url = url;
        }
        public void Author(string name, string url = "", string icon_url = "")
        {
            this.author = new Dictionary<string, string>
            {
                { "name", name },
                { "url", url },
                { "icon_url", icon_url }
            };
        }
        public void Image(string url)
        {
            this.image = new Dictionary<string, string>
            {
                { "url", url }
            };
        }
        public void Thumbnail(string url)
        {
            this.thumbnail = new Dictionary<string, string>
            {
                { "url", url }
            };
        }
        public void Footer(string text, string icon_url = "")
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
        public void AddFields(List<Field> fields)
        {
            this.fields.AddRange(fields);
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

        public string name { get; set; }
        public string value { get; set; }
        public bool inline { get; set; }
    }
}
