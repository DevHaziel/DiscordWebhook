using System.Net.Http;
using Newtonsoft.Json;

namespace DiscordWebhook
{
    public class WebhookSender
    { 
        public static async void Send(Webhook webhookData, string url)
        {
            var json = JsonConvert.SerializeObject(webhookData);
            using (var httpClient = new HttpClient())
            {
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(url, content);

                if (!response.IsSuccessStatusCode)
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    throw new System.Exception($"Webhook failed with status code: {response.StatusCode}, message: {errorMessage}");
                }
            }
        }
        public static void SendFormatted(Webhook webhookData, string url, object[] args)
        {
            if(webhookData.content != null)
                webhookData.Message(string.Format(webhookData.content, args));
            foreach (var embed in webhookData.embeds)
            {
                foreach(var field in embed.fields)
                {
                    field.SetFormattedValue(field.value, args);
                }
                embed.SetFormattedDescription(embed.description, args);
            }

            Send(webhookData, url);
        }
    }
}

