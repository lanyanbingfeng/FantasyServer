
using Fantasy;
using Fantasy.Network;
using Fantasy.Network.Interface;

namespace Hotfix.MessageHandler;

public class BroadcastMessage
{
    public static int ClientIdNum = 0;
    public static readonly Dictionary<int,ClientObject> ClientDic = new();

    public static void Broadcast(IMessage message)
    {
        foreach (var client in ClientDic.Values) client.Session.Send(message);
    }
    /// <summary>
    /// 忽略一个客户端的广播
    /// </summary>
    /// <param name="message"></param>
    /// <param name="session"></param>
    public static void Broadcast(IMessage message,Session session)
    {
        foreach (var client in ClientDic.Values)
        {
            if (client.Session == session) continue;
            client.Session.Send(message);
        }
    }
    
    public static void AddSession(Session session,ClientData data)
    {
        ClientIdNum++;
        ClientObject client = new ClientObject(session, ClientIdNum,data.Name);
        ClientDic.Add(ClientIdNum,client);
    }

    public static async void ListenClientDisConnect()
    {
        while (true)
        {
            await Task.Delay(1000);
            foreach (var clientDicKey in ClientDic.Keys)
            {
                if (ClientDic[clientDicKey].Session.IsDisposed)
                {
                    Broadcast(new OrdinaryMessage{Tag = $"玩家 {ClientDic[clientDicKey].Name} 退出世界"});
                    Broadcast(new DelectPlayerPrefabMessage{id = ClientDic[clientDicKey].ID});
                    Console.WriteLine($"玩家 {ClientDic[clientDicKey].Name} 退出世界");
                    ClientIdNum--;
                    ClientDic.Remove(clientDicKey);
                }
            }
        }
    }

    public static void UpdateClientData(ClientData data)
    {
        ClientDic[data.ID].Position = data.Position;
    }
}
