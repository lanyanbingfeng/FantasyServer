using ProtoBuf;
using System;
using MemoryPack;
using System.Collections.Generic;
using Fantasy;
using Fantasy.Network.Interface;
using Fantasy.Serialize;
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8618
// ReSharper disable InconsistentNaming
// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable RedundantTypeArgumentsOfMethod
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PreferConcreteValueOverDefault
// ReSharper disable RedundantNameQualifier
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable CheckNamespace
// ReSharper disable FieldCanBeMadeReadOnly.Global
// ReSharper disable RedundantUsingDirective
namespace Fantasy
{
    [Serializable]
    [ProtoContract]
    public partial class Vector3_Position : AMessage
    {
        public static Vector3_Position Create(Scene scene)
        {
            return scene.MessagePoolComponent.Rent<Vector3_Position>();
        }

        public override void Dispose()
        {
            x = default;
            y = default;
            z = default;
#if FANTASY_NET || FANTASY_UNITY
            GetScene().MessagePoolComponent.Return<Vector3_Position>(this);
#endif
        }
        [ProtoMember(1)]
        public float x { get; set; }
        [ProtoMember(2)]
        public float y { get; set; }
        [ProtoMember(3)]
        public float z { get; set; }
    }
    [Serializable]
    [ProtoContract]
    public partial class OrdinaryMessage : AMessage, IMessage
    {
        public static OrdinaryMessage Create(Scene scene)
        {
            return scene.MessagePoolComponent.Rent<OrdinaryMessage>();
        }

        public override void Dispose()
        {
            Tag = default;
#if FANTASY_NET || FANTASY_UNITY
            GetScene().MessagePoolComponent.Return<OrdinaryMessage>(this);
#endif
        }
public uint OpCode() { return OuterOpcode.OrdinaryMessage; } 
        [ProtoMember(1)]
        public string Tag { get; set; }
    }
    [Serializable]
    [ProtoContract]
    public partial class LoginRequest : AMessage, IRequest
    {
        public static LoginRequest Create(Scene scene)
        {
            return scene.MessagePoolComponent.Rent<LoginRequest>();
        }

        public override void Dispose()
        {
            name = default;
#if FANTASY_NET || FANTASY_UNITY
            GetScene().MessagePoolComponent.Return<LoginRequest>(this);
#endif
        }
public uint OpCode() { return OuterOpcode.LoginRequest; } 
        [ProtoIgnore]
        public LoginResponse ResponseType { get; set; }
        [ProtoMember(1)]
        public string name { get; set; }
    }
    [Serializable]
    [ProtoContract]
    public partial class LoginResponse : AMessage, IResponse
    {
        public static LoginResponse Create(Scene scene)
        {
            return scene.MessagePoolComponent.Rent<LoginResponse>();
        }

        public override void Dispose()
        {
            id = default;
            isLogin = default;
#if FANTASY_NET || FANTASY_UNITY
            GetScene().MessagePoolComponent.Return<LoginResponse>(this);
#endif
        }
public uint OpCode() { return OuterOpcode.LoginResponse; } 
        [ProtoMember(1)]
        public uint ErrorCode { get; set; }
        [ProtoMember(2)]
        public int id { get; set; }
        [ProtoMember(3)]
        public bool isLogin { get; set; }
    }
    [Serializable]
    [ProtoContract]
    public partial class PlayerDataMessage : AMessage, IMessage
    {
        public static PlayerDataMessage Create(Scene scene)
        {
            return scene.MessagePoolComponent.Rent<PlayerDataMessage>();
        }

        public override void Dispose()
        {
            id = default;
            name = default;
            Position = default;
#if FANTASY_NET || FANTASY_UNITY
            GetScene().MessagePoolComponent.Return<PlayerDataMessage>(this);
#endif
        }
public uint OpCode() { return OuterOpcode.PlayerDataMessage; } 
        [ProtoMember(1)]
        public int id { get; set; }
        [ProtoMember(2)]
        public string name { get; set; }
        [ProtoMember(3)]
        public Vector3_Position Position { get; set; }
    }
    [Serializable]
    [ProtoContract]
    public partial class CreatePlayrPrefabMessage : AMessage, IMessage
    {
        public static CreatePlayrPrefabMessage Create(Scene scene)
        {
            return scene.MessagePoolComponent.Rent<CreatePlayrPrefabMessage>();
        }

        public override void Dispose()
        {
            id = default;
            CreatePosition = default;
#if FANTASY_NET || FANTASY_UNITY
            GetScene().MessagePoolComponent.Return<CreatePlayrPrefabMessage>(this);
#endif
        }
public uint OpCode() { return OuterOpcode.CreatePlayrPrefabMessage; } 
        [ProtoMember(1)]
        public int id { get; set; }
        [ProtoMember(2)]
        public Vector3_Position CreatePosition { get; set; }
    }
    [Serializable]
    [ProtoContract]
    public partial class DelectPlayerPrefabMessage : AMessage, IMessage
    {
        public static DelectPlayerPrefabMessage Create(Scene scene)
        {
            return scene.MessagePoolComponent.Rent<DelectPlayerPrefabMessage>();
        }

        public override void Dispose()
        {
            id = default;
#if FANTASY_NET || FANTASY_UNITY
            GetScene().MessagePoolComponent.Return<DelectPlayerPrefabMessage>(this);
#endif
        }
public uint OpCode() { return OuterOpcode.DelectPlayerPrefabMessage; } 
        [ProtoMember(1)]
        public int id { get; set; }
    }
    [Serializable]
    [ProtoContract]
    public partial class OrdinaryRequest : AMessage, IRequest
    {
        public static OrdinaryRequest Create(Scene scene)
        {
            return scene.MessagePoolComponent.Rent<OrdinaryRequest>();
        }

        public override void Dispose()
        {
            Tag = default;
#if FANTASY_NET || FANTASY_UNITY
            GetScene().MessagePoolComponent.Return<OrdinaryRequest>(this);
#endif
        }
public uint OpCode() { return OuterOpcode.OrdinaryRequest; } 
        [ProtoIgnore]
        public OrdinaryResponse ResponseType { get; set; }
        [ProtoMember(1)]
        public string Tag { get; set; }
    }
    [Serializable]
    [ProtoContract]
    public partial class OrdinaryResponse : AMessage, IResponse
    {
        public static OrdinaryResponse Create(Scene scene)
        {
            return scene.MessagePoolComponent.Rent<OrdinaryResponse>();
        }

        public override void Dispose()
        {
            Tag = default;
#if FANTASY_NET || FANTASY_UNITY
            GetScene().MessagePoolComponent.Return<OrdinaryResponse>(this);
#endif
        }
public uint OpCode() { return OuterOpcode.OrdinaryResponse; } 
        [ProtoMember(1)]
        public uint ErrorCode { get; set; }
        [ProtoMember(2)]
        public string Tag { get; set; }
    }
}