using ProjectM;
using Unity.Entities;
using VampireCommandFramework;
using System.Collections.Generic;

namespace CommunityCommands.Commands
{
    internal static class GiveItem
    {
        private static Dictionary<string, List<Item>> equipmentSets = Database.GetSetDatabase();

        [Command("give", "g", description: "Give a specific item or set of items to yourself", adminOnly: true)]
        public static void GiveItemCommand(ChatCommandContext ctx, string type, string name)
        {
            if (string.IsNullOrEmpty(type) || string.IsNullOrEmpty(name))
            {
                ctx.Reply("Please provide valid arguments for <color=#ff0000>type</color> and <color=#ff0000>name</color>.");
                return;
            }

            type = type.ToLower();

            if (type == "set")
            {
                GiveEquipmentSet(ctx, name);
            }
            else if (type == "item")
            {
                GiveSingleItem(ctx, name);
            }
            else
            {
                ctx.Reply($"Invalid type <color=#ff0000>{type}</color>. Valid types are <color=#00ff00>set</color> and <color=#00ff00>item</color>.");
            }
        }

        private static void GiveEquipmentSet(ChatCommandContext ctx, string setName)
        {
            if (equipmentSets.TryGetValue(setName, out var equipmentList))
            {
                foreach (var item in equipmentList)
                {
                    GiveSingleItem(ctx, item.Name);
                }

                ctx.Reply($"Given equipment set <color=#00ff00>{setName}</color> to the player.");
            }
            else
            {
                ctx.Reply($"Equipment set <color=#ff0000>{setName}</color> not found.");
            }
        }

        private static void GiveSingleItem(ChatCommandContext ctx, string itemName)
        {
            var em = Helper.Server.EntityManager;
            var item = GetItem(itemName);
            if (item == null)
            {
                ctx.Reply($"Item <color=#ff0000>{itemName}</color> not found.");
                return;
            }

            PrefabGUID prefab = new PrefabGUID(item.Prefab);

            Entity entity = Helper.AddItemToInventory(ctx.Event.SenderCharacterEntity, prefab, 1);
            if (entity != Entity.Null)
            {
                ctx.Reply($"Given item <color=#00ff00>{item.Name.Replace("_", " ")}</color> to the player.");
            }
            else
            {
                ctx.Reply($"Failed to add item <color=#ff0000>{item.Name.Replace("_", " ")}</color> to inventory.");
            }
        }

        private static Item GetItem(string itemName)
        {
            itemName = itemName.ToLower();
            Item foundItem = null;
            int matchingItemCount = 0;

            foreach (var itemSet in equipmentSets)
            {
                foreach (var item in itemSet.Value)
                {
                    if (item.Name.ToLower().StartsWith(itemName))
                    {
                        foundItem = item;
                        matchingItemCount++;
                    }
                }
            }

            if (matchingItemCount == 1)
            {
                return foundItem;
            }
            
            return null;
        }
    }
}
