using BrokeProtocol.API;
using BrokeProtocol.Entities;
using UnityEngine;

namespace LogsProtocolAdvanced.Types
{
    public class Player : PlayerEvents
    {
        [Execution(ExecutionMode.PostEvent)]
        public override bool Initialize(ShEntity entity)
        {
            Debug.Log("Initialize event triggered.");
            if (entity is ShPlayer player)
            {
                if (!player.isHuman) return true;
                var config = Utils.getEvent("onJoin");
                if (config == null) return true;
                player.StartCoroutine(Utils.sendWebhook(config, new object[] { player.username, player.ID }));
            }
            return true;
        }

        [Execution(ExecutionMode.PostEvent)]
        public override bool Destroy(ShEntity entity)
        {
            Debug.Log("Destroy event triggered.");
            if (entity is ShPlayer player)
            {
                if (!player.isHuman) return true;
                var config = Utils.getEvent("onLeft");
                if (config == null) return true;
                player.StartCoroutine(Utils.sendWebhook(config, new object[] { player.username, player.ID }));
            }
            return true;
        }

        [Execution(ExecutionMode.PostEvent)]
        public override bool Death(ShDestroyable destroyable, ShPlayer attacker)
        {
            Debug.Log("Death event triggered.");
            if (destroyable is ShPlayer player)
            {
                if (!player.isHuman) return true;
                var config = Utils.getEvent("onDeath");
                if (config == null) return true;
                player.StartCoroutine(Utils.sendWebhook(config, new object[] { player.username, attacker?.username ?? "null" }));
                if (attacker != null)
                {
                    var config2 = Utils.getEvent("onKill");
                    if (config2 == null) return true;
                    attacker.StartCoroutine(Utils.sendWebhook(config2, new object[] { attacker.username, player.username }));
                }
            }
            return true;
        }

        [Execution(ExecutionMode.PostEvent)]
        public override bool ChatLocal(ShPlayer player, string message)
        {
            Debug.Log("ChatLocal event triggered.");
            if (player == null) return true;
            var config = Utils.getEvent("onChatLocal");
            if (config == null) return true;
            player.StartCoroutine(Utils.sendWebhook(config, new object[] { player.username, message, player.ID }));
            return true;
        }

        [Execution(ExecutionMode.PostEvent)]
        public override bool ChatGlobal(ShPlayer player, string message)
        {
            Debug.Log("ChatGlobal event triggered.");
            if (player == null) return true;
            var config = Utils.getEvent("onChatGlobal");
            if (config == null) return true;
            player.StartCoroutine(Utils.sendWebhook(config, new object[] { player.username, message, player.ID }));
            return true;
        }

        [Execution(ExecutionMode.PostEvent)]
        public override bool Command(ShPlayer player, string message)
        {
            Debug.Log("Command event triggered.");
            if (player == null) return true;
            var config = Utils.getEvent("onCommand");
            if (config == null) return true;
            player.StartCoroutine(Utils.sendWebhook(config, new object[] { player.username, message, player.ID }));
            return true;
        }
    }
}
