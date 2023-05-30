using CommunityCommands.Data;
using CommunityCommands.Models;
using ProjectM;
using Unity.Entities;
using Unity.Transforms;

using VampireCommandFramework;

namespace CommunityCommands.Commands;

internal static class SpawnCommands
{
	[Command("spawnnpc", "spwn", description: "Spawns CHAR_ npcs", adminOnly: true)]
	public static void SpawnNpc(ChatCommandContext ctx, string name, int count = 1)
	{
		var pos = Core.EntityManager.GetComponentData<LocalToWorld>(ctx.Event.SenderCharacterEntity).Position;

		if (!Character.Named.TryGetValue(name, out var unit) && Character.Named.TryGetValue("CHAR_" + name, out unit))
		{
			throw ctx.Error($"Can't find unit {name}");
		}

		Core.UnitSpawner.Spawn(ctx.Event.SenderUserEntity, unit, count, new(pos.x, pos.z), 1, 2, -1);
		ctx.Reply($"Spawning CustomNPC {name} at your position");
	}

	[Command("customspawn", "cspn", "customspawn <Prefab Name> [<BloodType> <BloodQuality> <Consumable(\"true/false\")> <Duration>]", "Spawns a modified NPC at your current position.", adminOnly: true)]
	public static void CustomSpawnNpc(ChatCommandContext ctx, string name, BloodType type, int quality, bool consumable, int duration = -1)
	{
		var pos = Core.EntityManager.GetComponentData<LocalToWorld>(ctx.Event.SenderCharacterEntity).Position;

		if (!Character.Named.TryGetValue(name, out var unit) && Character.Named.TryGetValue("CHAR_" + name, out unit))
		{
			throw ctx.Error($"Can't find unit {name}");
		}

		if (quality > 100 || quality < 0)
		{
			throw ctx.Error($"Blood Quality must be between 0 and 100");
		}

		Core.UnitSpawner.SpawnWithCallback(ctx.Event.SenderUserEntity, unit, pos.xz, duration, (Entity e) =>
		{
			var blood = Core.EntityManager.GetComponentData<BloodConsumeSource>(e);
			blood.UnitBloodType = new PrefabGUID((int)type);
			blood.BloodQuality = quality;
			blood.CanBeConsumed = consumable;
			Core.EntityManager.SetComponentData(e, blood);
		});
	}
}
