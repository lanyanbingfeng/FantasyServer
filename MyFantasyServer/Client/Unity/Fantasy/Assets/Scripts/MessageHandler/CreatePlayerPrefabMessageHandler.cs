using Fantasy;
using Fantasy.Async;
using Fantasy.Network;
using Fantasy.Network.Interface;
using UnityEngine;

namespace MessageHandler
{
    public class CreatePlayerPrefabMessageHandler : Message<CreatePlayrPrefabMessage>
    {
        protected override async FTask Run(Session session, CreatePlayrPrefabMessage message)
        {
            Vector3 pos = new Vector3(message.CreatePosition.x,message.CreatePosition.y,message.CreatePosition.z);
            GameObject otherPlayerObject = Object.Instantiate(FantasyManager.Instance.playerPrefab, pos, Quaternion.identity);
            PlayerObj playerObj = otherPlayerObject.GetComponent<PlayerObj>();
            playerObj.clientID = message.id;
            FantasyManager.Instance.OtherPlayerDic.Add(message.id,playerObj);
            await FTask.CompletedTask;
        }
    }
}