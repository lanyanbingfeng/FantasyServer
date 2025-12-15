using Fantasy;
using Fantasy.Async;
using Fantasy.Network;
using Fantasy.Network.Interface;

namespace Hotfix.MessageHandler;

public class OrdinaryMessageHandler : Message<OrdinaryMessage>
{
    protected override async FTask Run(Session session, OrdinaryMessage message)
    {
        Console.WriteLine($"收到来自{session.RemoteEndPoint}的普通消息：{message.Tag}");
        await FTask.CompletedTask;
    }
}