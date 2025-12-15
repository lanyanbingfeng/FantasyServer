
using System.Numerics;
using Fantasy;
using Fantasy.Async;
using Fantasy.Network;
using Fantasy.Network.Interface;
using Hotfix;
using Hotfix.MessageHandler;

public class PlayerDataMessageHandler : Message<PlayerDataMessage>
{
    protected override async FTask Run(Session session, PlayerDataMessage message)
    {
        Vector3 position = new Vector3(message.Position.x, message.Position.y, message.Position.z);
        ClientData data = new ClientData{ID = message.id,Name = message.name,Position = position};
        BroadcastMessage.UpdateClientData(data);
        BroadcastMessage.Broadcast(message,session);
        await FTask.CompletedTask;
    }
}