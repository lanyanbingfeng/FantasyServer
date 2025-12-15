using System.Numerics;
using Fantasy.Network;

namespace Hotfix;

public class ClientObject
{
    public int ID;
    public readonly Session Session;
    public readonly string Name;
    public Vector3 Position;

    public ClientObject(Session session,int id,string name)
    {
        ID = id;
        Session = session;
        Name = name;
    }
}

public class ClientData
{
    public int ID;
    public string Name;
    public Vector3 Position;
}