using CommunityCommands.Data;
using CommunityCommands.Models;
using ProjectM;
using Unity.Entities;
using Unity.Transforms;

using VampireCommandFramework;

namespace CommunityCommands.Commands;

internal static class SpawnCommands
{
	public record struct CharacterUnit(string Name, PrefabGUID Prefab);

	public class CharacterUnitConverter : CommandArgumentConverter<CharacterUnit>
	{
		public override CharacterUnit Parse(ICommandContext ctx, string input)
		{
			if (Character.Named.TryGetValue(input, out var unit) || Character.Named.TryGetValue("CHAR_" + input, out unit))
			{
				return new(Character.NameFromPrefab[unit.GuidHash], unit);
			}
			// "CHAR_Bandit_Bomber": -1128238456,
			if (int.TryParse(input, out var id) && Character.NameFromPrefab.TryGetValue(id, out var name))
			{
				return new(name, new(id));
			}

			throw ctx.Error($"Can't find unit {input.Bold()}");
		}
	}

	[Command("spawnnpc", "spwn", description: "Spawns CHAR_ npcs", adminOnly: true)]
	public static void SpawnNpc(ChatCommandContext ctx, CharacterUnit character, int count = 1)
	{
		var pos = Core.EntityManager.GetComponentData<LocalToWorld>(ctx.Event.SenderCharacterEntity).Position;

		Core.UnitSpawner.Spawn(ctx.Event.SenderUserEntity, character.Prefab, count, new(pos.x, pos.z), 1, 2, -1);
		ctx.Reply($"Spawning {character.Name.Bold()} at your position");
	}

	[Command("customspawn", "cspn", "customspawn <Prefab Name> [<BloodType> <BloodQuality> <Consumable(\"true/false\")> <Duration>]", "Spawns a modified NPC at your current position.", adminOnly: true)]
	public static void CustomSpawnNpc(ChatCommandContext ctx, CharacterUnit unit, int level = 0, BloodType type = BloodType.Frailed, int quality = 0, bool consumable = true, int duration = -1)
	{
		var pos = Core.EntityManager.GetComponentData<LocalToWorld>(ctx.Event.SenderCharacterEntity).Position;

		if (quality > 100 || quality < 0)
		{
			throw ctx.Error($"Blood Quality must be between 0 and 100");
		}

		Core.UnitSpawner.SpawnWithCallback(ctx.Event.SenderUserEntity, unit.Prefab, pos.xz, duration, (Entity e) =>
		{
			var blood = Core.EntityManager.GetComponentData<BloodConsumeSource>(e);
			blood.UnitBloodType = new PrefabGUID((int)type);
			blood.BloodQuality = quality;
			blood.CanBeConsumed = consumable;

			var unitLevel = Core.EntityManager.GetComponentData<UnitLevel>(e);
			unitLevel.Level = level;

			Core.EntityManager.SetComponentData(e, unitLevel);
			Core.EntityManager.SetComponentData(e, blood);
		});
	}
}
