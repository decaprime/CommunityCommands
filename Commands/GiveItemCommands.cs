using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectM;
using VampireCommandFramework;

namespace CommunityCommands.Commands;
internal class GiveItemCommands
{
	public record struct GivenItem(PrefabGUID Value);

	internal class GiveItemConverter : CommandArgumentConverter<GivenItem>
	{
		public override GivenItem Parse(ICommandContext ctx, string input)
		{
			if (int.TryParse(input, out var integral))
			{
				return new GivenItem(new(integral));
			}


			if (Core.Prefabs.TryGetItem(input, out var prefab))
			{
				return new GivenItem(prefab);
			}

			throw ctx.Error($"Invalid item id: {input}");
		}
	}

	[Command("give", "g", "<Prefab GUID or name> [quantity=1]", "Gives the specified item to the player", adminOnly: true)]
	public static void GiveItem(ChatCommandContext ctx, GivenItem item, int quantity = 1)
	{
		Helper.AddItemToInventory(ctx.Event.SenderCharacterEntity, item.Value, quantity);
		var prefabSys = Core.Server.GetExistingSystem<PrefabCollectionSystem>();
		prefabSys.PrefabGuidToNameDictionary.TryGetValue(item.Value, out var name); // seems excessive
		ctx.Reply($"Gave {quantity} {name}");
	}
}
