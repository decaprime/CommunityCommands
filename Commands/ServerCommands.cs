using ProjectM.Network;
using Unity.Collections;
using Unity.Entities;

using VampireCommandFramework;

namespace CommunityCommands.Commands;
public class ServerCommands {
	public static class Shutdown {
		[Command("shutdown", shortHand: "quit", description: "Trigger the exit signal & shutdown the server.", adminOnly: true)]
		public static void Initialize() {
			UnityEngine.Application.Quit();
		}
	}

	public static class Kick {
		[Command("kick", "kick <playername>", "Kick the specified player out of the server.", adminOnly: true)]
		public static void Initialize(ICommandContext ctx, string name) {


			if (FindPlayer(name, true, out _, out var targetUserEntity)) {
				KickPlayer(targetUserEntity);
				ctx.Reply($"Player \"{name}\" has been kicked from server.");
			} else {
				ctx.Reply("Specified player not found.");
			}
		}
		public static bool FindPlayer(string name, bool mustOnline, out Entity playerEntity, out Entity userEntity) {
			foreach (var UsersEntity in Core.EntityManager.CreateEntityQuery(ComponentType.ReadOnly<User>()).ToEntityArray(Allocator.Temp)) {
				var target_component = Core.EntityManager.GetComponentData<User>(UsersEntity);
				if (mustOnline) {
					if (!target_component.IsConnected) continue;
				}

				string CharName = target_component.CharacterName.ToString();
				if (CharName.Equals(name)) {
					userEntity = UsersEntity;
					playerEntity = target_component.LocalCharacter._Entity;
					return true;
				}
			}
			playerEntity = new Entity();
			userEntity = new Entity();
			return false;
		}
		public static void KickPlayer(Entity userEntity) {
			EntityManager em = Core.Server.EntityManager;
			var userData = em.GetComponentData<User>(userEntity);
			int index = userData.Index;

			var entity = em.CreateEntity(
				ComponentType.ReadOnly<NetworkEventType>(),
				ComponentType.ReadOnly<SendEventToUser>(),
				ComponentType.ReadOnly<KickEvent>()
			);

			var KickEvent = new KickEvent() {
				PlatformId = userData.PlatformId
			};

			em.SetComponentData<SendEventToUser>(entity, new() {
				UserIndex = index
			});
			em.SetComponentData<NetworkEventType>(entity, new() {
				EventId = NetworkEvents.EventId_KickEvent,
				IsAdminEvent = false,
				IsDebugEvent = false
			});

			em.SetComponentData(entity, KickEvent);
		}
	}

		public static class Ping {
		[Command("ping", "p", "ping", "Shows your latency.")]
		public static void Initialize(ChatCommandContext ctx) {
			var ping = Core.EntityManager.GetComponentData<Latency>(ctx.Event.SenderCharacterEntity).Value;
			ctx.Reply($"Your latency is <color=#ffff00>{ping}</color>s");
		}
	}

}
