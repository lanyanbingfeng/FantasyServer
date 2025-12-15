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

        foreach (var client in BroadcastMessage.ClientHashSet)
        {
            ClientObject clientObject = client.GetComponent<ClientObject>();
            session.Send(new CreatePlayrPrefabMessage{
                id = clientObject.ID,
                CreatePosition = new Vector3_Position{x = clientObject.Position.X, y = clientObject.Position.Y, z = clientObject.Position.Z}});
        }
        
        BroadcastMessage.AddSession(session,data);
        Console.WriteLine($"玩家 {request.name} 加入世界");
        response.id = session.GetComponent<ClientObject>().ID;
        response.isLogin = true;
        reply.Invoke();
        BroadcastMessage.Broadcast(new CreatePlayrPrefabMessage()
        {
            id = response.id,CreatePosition = new Vector3_Position(){x = 0, y = 1, z = 0},
        },session);
        await FTask.CompletedTask;
    }
}