using System.Collections.Generic;
using System.IO;
using DiscordWebhook;
using Newtonsoft.Json;
using UnityEngine;

namespace LogsProtocolAdvanced
{
    public class Files
    {
        public Config config { get; set; }
        private static Files _instance;
        public static Files Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Files();
                }
                return _instance;
            }
        }
        public void ReloadConfig()
        {
            Debug.Log("Reloading config...");
            var json = File.ReadAllText(Path.Combine("LogsProtocol Advanced", "config.json"));
            config = JsonConvert.DeserializeObject<Config>(json);
            Debug.Log("Config reloaded.");
        }
        public void LoadConfig()
        {
            Debug.Log("Loading config...");
            if (!Directory.Exists(Path.Combine("LogsProtocol Advanced")))
            {
                Directory.CreateDirectory(Path.Combine("LogsProtocol Advanced"));
                Debug.Log("Directory created.");
            }

            if (!File.Exists(Path.Combine("LogsProtocol Advanced", "config.json")))
            {
                var json = JsonConvert.SerializeObject(Config.GetDefault(), Formatting.Indented);
                File.WriteAllText(Path.Combine("LogsProtocol Advanced", "config.json"), json);
                Debug.Log("[LogsProtocol Advanced] Config file created.");
            }
            else
            {
                Debug.Log("Config file already exists.");
            }
        }
        private Files()
        {
            LoadConfig();
            Debug.Log("Config loaded...");
            ReloadConfig();
        }
    }
    public class Config
    {
        public static Config GetDefault()
        {
            Webhook joinWebhook = new Webhook("On Join");
            joinWebhook.Message("The player **{0}** joined the server.");
            Webhook leftWebhook = new Webhook("On Left");
            leftWebhook.Message("The player **{0}** left the server.");

            Webhook localWebhook = new Webhook("Chat Local");
            localWebhook.Message("The player **{0}** said: **{1}**");
            Webhook globalWebhook = new Webhook("Chat Global");
            globalWebhook.Message("The player **{0}** said to all: **{1}**");
            Webhook commandWebhook = new Webhook("Command");
            commandWebhook.Message("The player **{0}** executed the command: **{1}**");

            // Embeds
            Embed killEmbed = new Embed();
            killEmbed.SetTitle("Player kill");
            killEmbed.SetDescription("The player **{0}** killed **{1}**");
            killEmbed.SetColor("#ff8e00");

            Embed deathEmbed = new Embed();
            deathEmbed.SetTitle("Player death");
            deathEmbed.SetDescription("The player **{0}** is death.");
            deathEmbed.SetColor("#FF2121");

            Webhook killWebhook = new Webhook("Kills", new Embed[] {deathEmbed});
            Webhook deathWebhook = new Webhook("Deaths", new Embed[] {killEmbed});

            // Embeds
            Embed startEmbed = new Embed();
            startEmbed.SetTitle("Server Started");
            startEmbed.SetDescription("Server has started at date: **{0}**");
            startEmbed.SetColor("#21FF61");

            Webhook startWebhook = new Webhook("Server Status", new Embed[] {startEmbed});

            var config = new Config()
            {
                events = new Dictionary<string, EventConfig>()
                {
                    {
                        "onJoin",
                        new EventConfig()
                        {
                            url = "",
                            webhook = joinWebhook
                        }
                    },
                    {
                        "onLeft",
                        new EventConfig()
                        {
                            url = "",
                            webhook = leftWebhook
                        }
                    },
                    {
                        "onDeath",
                        new EventConfig()
                        {
                            url = "",
                            webhook = deathWebhook
                        }
                    },
                    {
                        "onKill",
                        new EventConfig()
                        {
                            url = "",
                            webhook = killWebhook
                        }
                    },
                    {
                        "onCommand",
                        new EventConfig()
                        {
                            url = "",
                            webhook = commandWebhook
                        }
                    },
                    {
                        "onChatLocal",
                        new EventConfig()
                        {
                            url = "",
                            webhook = localWebhook
                        }
                    },

                    {
                        "onChatGlobal",
                        new EventConfig()
                        {
                            url = "",
                            webhook = globalWebhook
                        }
                    },
                    {
                        "onStart",
                        new EventConfig()
                        {
                            url = "",
                            webhook = startWebhook
                        }
                    }
                }
            };
            return config;
        }
        public Dictionary<string, EventConfig> events { get; set; }
    }
    public class EventConfig
    {
        public string url { get; set; }
        public Webhook webhook { get; set; }
    }
}
