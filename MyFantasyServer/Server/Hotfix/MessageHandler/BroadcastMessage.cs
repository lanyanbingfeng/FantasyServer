
using Fantasy;
using Fantasy.Entitas;
using Fantasy.Network;
using Fantasy.Network.Interface;

namespace Hotfix.MessageHandler;

public class BroadcastMessage
{
    private const int ClientLength = 100;
    public static readonly Dictionary<int,ClientObject?> ClientDic = new();
    public static readonly HashSet<Session> ClientHashSet = [];

    public static void Init()
    {
        for (int i = 0; i < ClientLength; i++)
        {
            ClientDic.Add(i,null);
        }
    }

    public static void Broadcast(IMessage message)
    {
        foreach (var client in ClientHashSet) client.Send(message);
    }
    /// <summary>
    /// 忽略一个客户端的广播
    /// </summary>
    /// <param name="message"></param>
    /// <param name="session"></param>
    public static void Broadcast(IMessage message,Session session)
    {
        foreach (var client in ClientHashSet)
        {
            if (client == session) continue;
            client.Send(message);
        }
    }
    
    public static void AddSession(Session session,ClientData data)
    {
        ClientObject client = Entity.Create<ClientObject>(session.Scene);
        ClientHashSet.Add(session);
        for (int i = 0; i < ClientLength; i++)
        {
            if (ClientDic[i] != null) continue;
            client.Init(session, i,data.Name);
            ClientDic[i] = client;
            session.AddComponent(client);
            break;
        }
    }

    public static void UpdateClientData(ClientData data)
    {
        ClientDic[data.ID]?.UpdateData(data);
    }
}
