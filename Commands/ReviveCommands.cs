using CommunityCommands.Commands.Converters;
using Il2CppSystem;
using ProjectM;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using VampireCommandFramework;

namespace CommunityCommands.Commands;

internal class ReviveCommands
{
	[Command("revive", adminOnly: true)]
	public void ReviveCommand(ChatCommandContext ctx)
	{
		var pos = Core.EntityManager.GetComponentData<LocalToWorld>(ctx.Event.SenderCharacterEntity).Position;

		var sbs = Core.Server.GetExistingSystem<ServerBootstrapSystem>();
		var bufferSystem = Core.Server.GetExistingSystem<EntityCommandBufferSystem>();
		var buffer = bufferSystem.CreateCommandBuffer();

		Nullable_Unboxed<float3> spawnLoc = new();
		spawnLoc.value = pos;
		spawnLoc.has_value = true;

		sbs.RespawnCharacter(buffer, ctx.Event.SenderUserEntity,
			customSpawnLocation: spawnLoc,
			previousCharacter: ctx.Event.SenderCharacterEntity);

		ctx.Reply("Revived");
	}
}
