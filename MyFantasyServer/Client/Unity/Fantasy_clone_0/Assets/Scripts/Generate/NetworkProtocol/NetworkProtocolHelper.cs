using System.Runtime.CompilerServices;
using Fantasy;
using Fantasy.Async;
using Fantasy.Network;
using System.Collections.Generic;
#pragma warning disable CS8618
namespace Fantasy
{
   public static class NetworkProtocolHelper
   {
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void OrdinaryMessage(this Session session, OrdinaryMessage message)
		{
			session.Send(message);
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void OrdinaryMessage(this Session session, string tag)
		{
			using var message = Fantasy.OrdinaryMessage.Create(session.Scene);
			message.Tag = tag;
			session.Send(message);
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static async FTask<LoginResponse> LoginRequest(this Session session, LoginRequest request)
		{
			return (LoginResponse)await session.Call(request);
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static async FTask<LoginResponse> LoginRequest(this Session session, string name)
		{
			using var request = Fantasy.LoginRequest.Create(session.Scene);
			request.name = name;
			return (LoginResponse)await session.Call(request);
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void PlayerDataMessage(this Session session, PlayerDataMessage message)
		{
			session.Send(message);
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void PlayerDataMessage(this Session session, int id, string name, Vector3_Position position)
		{
			using var message = Fantasy.PlayerDataMessage.Create(session.Scene);
			message.id = id;
			message.name = name;
			message.Position = position;
			session.Send(message);
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void CreatePlayrPrefabMessage(this Session session, CreatePlayrPrefabMessage message)
		{
			session.Send(message);
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void CreatePlayrPrefabMessage(this Session session, int id, Vector3_Position createPosition)
		{
			using var message = Fantasy.CreatePlayrPrefabMessage.Create(session.Scene);
			message.id = id;
			message.CreatePosition = createPosition;
			session.Send(message);
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void DelectPlayerPrefabMessage(this Session session, DelectPlayerPrefabMessage message)
		{
			session.Send(message);
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void DelectPlayerPrefabMessage(this Session session, int id)
		{
			using var message = Fantasy.DelectPlayerPrefabMessage.Create(session.Scene);
			message.id = id;
			session.Send(message);
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static async FTask<OrdinaryResponse> OrdinaryRequest(this Session session, OrdinaryRequest request)
		{
			return (OrdinaryResponse)await session.Call(request);
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static async FTask<OrdinaryResponse> OrdinaryRequest(this Session session, string tag)
		{
			using var request = Fantasy.OrdinaryRequest.Create(session.Scene);
			request.Tag = tag;
			return (OrdinaryResponse)await session.Call(request);
		}

   }
}