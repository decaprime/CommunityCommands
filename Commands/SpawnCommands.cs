using Unity.Transforms;
using VampireCommandFramework;

namespace CommunityCommands.Commands;

internal static class SpawnCommands
{
    [Command("spawnnpc", "spwn", description: "spawnnpc <Prefab Name/GUID> [<Amount>] - Spawns a modified NPC at your current position.", adminOnly: true)]
	public static void CustomSpawnNPC(ChatCommandContext ctx, string name, int count = 1)
	{
        var em = Helper.Server.EntityManager;
        var pos = em.GetComponentData<LocalToWorld>(ctx.Event.SenderCharacterEntity).Position;
        
        if (!Helper.SpawnAtPosition(ctx.Event.SenderUserEntity, name, count, new(pos.x, pos.z), 1, 2, 1800))
        {
            ctx.Reply($"Could not find specified unit: {name}");
            return;
        }

        ctx.Reply($"Spawning CustomNPC {name} at your position");
	}
}