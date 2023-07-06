using CommunityCommands.Commands.Converters;
using Il2CppSystem;
using Il2CppInterop.Runtime;
using ProjectM;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using VampireCommandFramework;

namespace CommunityCommands.Commands;

internal class ReviveCommands
{
	[Command("revive", adminOnly: true)]
	public void ReviveCommand(ChatCommandContext ctx, OnlinePlayer target = null)
	{
		var user = target?.Value.UserEntity ?? ctx.Event.SenderUserEntity;
		var character = target?.Value.CharEntity ?? ctx.Event.SenderCharacterEntity;

		var pos = Core.EntityManager.GetComponentData<LocalToWorld>(character).Position;

		var sbs = Core.Server.GetExistingSystem<ServerBootstrapSystem>();
		var bufferSystem = Core.Server.GetExistingSystem<EntityCommandBufferSystem>();
		var buffer = bufferSystem.CreateCommandBuffer();

		Nullable_Unboxed<float3> spawnLoc = new();
		spawnLoc.value = pos;
		spawnLoc.has_value = true;

		sbs.RespawnCharacter(buffer, user,
			customSpawnLocation: spawnLoc,
			previousCharacter: character);

		ctx.Reply("Revived");
	}
}
