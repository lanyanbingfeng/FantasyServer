using Fantasy;
using Fantasy.Async;
using Fantasy.Network;
using Fantasy.Network.Interface;

namespace Hotfix.MessageHandler;

public class LoginRequestHandler : MessageRPC<LoginRequest,LoginResponse>
{
    protected override async FTask Run(Session session, LoginRequest request, LoginResponse response, Action reply)
    {
        ClientData data = new ClientData{Name = request.name};

        foreach (var client in BroadcastMessage.ClientDic.Values)
        {
            session.Send(new CreatePlayrPrefabMessage{
                id = client.ID,
                CreatePosition = new Vector3_Position{x = client.Position.X, y = client.Position.Y, z = client.Position.Z}});
        }
        
        BroadcastMessage.AddSession(session,data);
        Console.WriteLine($"玩家 {request.name} 加入世界");
        response.id = BroadcastMessage.ClientIdNum;
        response.isLogin = true;
        reply.Invoke();
        BroadcastMessage.Broadcast(new CreatePlayrPrefabMessage()
        {
            id = BroadcastMessage.ClientIdNum,CreatePosition = new Vector3_Position(){x = 0, y = 1, z = 0},
        },session);
        await FTask.CompletedTask;
    }
}