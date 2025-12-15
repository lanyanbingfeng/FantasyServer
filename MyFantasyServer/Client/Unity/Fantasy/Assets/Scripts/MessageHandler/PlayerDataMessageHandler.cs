
using Fantasy;
using Fantasy.Async;
using Fantasy.Network;
using Fantasy.Network.Interface;
using UnityEngine;

namespace MessageHandler
{
    public class PlayerDataMessageHandler : Message<PlayerDataMessage>
    {
        protected override async FTask Run(Session session, PlayerDataMessage message)
        {
            Vector3 playerPos = new Vector3(message.Position.x, message.Position.y, message.Position.z);
            FantasyManager.Instance.OtherPlayerDic[message.id].transform.position = playerPos;
            await FTask.CompletedTask;
        }
    }
}