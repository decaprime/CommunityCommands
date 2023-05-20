using ProjectM;
using Unity.Entities;
using UnityEngine;
using VampireCommandFramework;

namespace CommunityCommands.Commands;

internal static class BloodCommands
{
	public enum BloodType
	{
		Frailed = -899826404,
		Creature = -77658840,
		Warrior = -1094467405,
		Rogue = 793735874,
		Brute = 581377887,
		Scholar = -586506765,
		Worker = -540707191
	}

	[Command("bloodpotion", "bp", description: "Creates a Potion with specified Blood Type, Quality and Value")]
	public static void GiveBloodPotionCommand(ChatCommandContext ctx, BloodType type = BloodType.Frailed, float quality = 100f)
	{
		quality = Mathf.Clamp(quality, 0, 100);
		var em = Helper.Server.EntityManager;

		Entity entity = Helper.AddItemToInventory(ctx.Event.SenderCharacterEntity, new PrefabGUID(828432508), 1);

		var blood = new StoredBlood()
		{
			BloodQuality = quality,
			BloodType = new PrefabGUID((int)type)
		};

		em.SetComponentData(entity, blood);

		ctx.Reply($"Got Blood Potion Type <color=#ff0>{type}</color> with <color=#ff0>{quality}</color>% quality");
	}
}