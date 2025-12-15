using Fantasy;
using Fantasy.Async;
using Fantasy.Network;
using Fantasy.Network.Interface;
using UnityEngine;

namespace MessageHandler
{
    public class DelectPlayerPrefabMessageHandler : Message<DelectPlayerPrefabMessage>
    {
        protected override async FTask Run(Session session, DelectPlayerPrefabMessage message)
        {
            Object.Destroy(FantasyManager.Instance.OtherPlayerDic[message.id].gameObject);
            FantasyManager.Instance.OtherPlayerDic.Remove(message.id);
            await FTask.CompletedTask;
        }
    }
}