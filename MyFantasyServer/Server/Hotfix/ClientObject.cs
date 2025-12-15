using System.Numerics;
using Fantasy;
using Fantasy.Entitas;
using Fantasy.Entitas.Interface;
using Fantasy.Network;
using Hotfix.MessageHandler;

namespace Hotfix;

public class ClientObject : Entity
{
    public int ID;
    public Session Session;
    public string Name;
    public Vector3 Position;

    public void Init(Session session,int id,string name)
    {
        ID = id;
        Session = session;
        Name = name;
    }

    public void UpdateData(ClientData data)
    {
        Position = data.Position;
    }
}

public class ClientUpdateSystem : DestroySystem<ClientObject>
{
    protected override void Destroy(ClientObject self)
    {
        BroadcastMessage.Broadcast(new OrdinaryMessage{Tag = $"玩家 {self.Name} 退出世界"});
        BroadcastMessage.Broadcast(new DelectPlayerPrefabMessage{id = self.ID});
        BroadcastMessage.ClientHashSet.Remove(self.Session);
        Console.WriteLine($"玩家 {self.Name} 退出世界");
    }
}

public class ClientData
{
    public int ID;
    public string Name;
    public Vector3 Position;
}