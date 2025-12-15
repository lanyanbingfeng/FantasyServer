using Fantasy;
using Fantasy.Async;
using Fantasy.Network;
using Fantasy.Network.Interface;
using UnityEngine;

namespace MessageHandler
{
    public class OrdinaryMessageHandler : Message<OrdinaryMessage>
    {
        protected override async FTask Run(Session session, OrdinaryMessage message)
        {
            Debug.Log(message.Tag);
            await FTask.CompletedTask;
        }
    }
}