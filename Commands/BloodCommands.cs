using CommunityCommands.Models;
using ProjectM;
using Unity.Entities;
using UnityEngine;
using VampireCommandFramework;

namespace CommunityCommands.Commands;

internal static class BloodCommands
{

	[Command("bloodpotion", "bp", description: "Creates a Potion with specified Blood Type, Quality and Value", adminOnly: true)]
	public static void GiveBloodPotionCommand(ChatCommandContext ctx, BloodType type = BloodType.Frailed, float quality = 100f)
	{
		if(!System.Enum.IsDefined(typeof(BloodType), type)){
			type = BloodType.Frailed;
		}

		quality = Mathf.Clamp(quality, 0, 100);

		Entity entity = Helper.AddItemToInventory(ctx.Event.SenderCharacterEntity, new PrefabGUID(828432508), 1);

		var blood = new StoredBlood()
		{
			BloodQuality = quality,
			BloodType = new PrefabGUID((int)type)
		};

		Core.EntityManager.SetComponentData(entity, blood);

		ctx.Reply($"Got Blood Potion Type <color=#ff0>{type}</color> with <color=#ff0>{quality}</color>% quality");
	}
}
