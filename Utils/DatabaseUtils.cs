using System;
using System.Collections.Generic;
using System.Linq;
using ProjectM;
using Unity.Entities;
using Unity.Mathematics;
using VampireCommandFramework;
using CommunityCommands.Commons;

namespace CommunityCommands.Utils
{
    public class DatabaseUtils
    {
        private static readonly Dictionary<string, VBlood> VBloodDatabase = Database.BossDatabase;
        private static readonly Dictionary<string, List<Item>> ItemSetsDatabase = Database.ItemSets;

        public static string GetUnitDisplayName(string bossName)
        {
            if (VBloodDatabase.TryGetValue(bossName.ToLower(), out var boss))
            {
                return boss.DisplayName;
            }

            return null;
        }

        public static string GetUnitDisplayName(PrefabGUID bossPrefab)
        {
            foreach (var boss in VBloodDatabase.Values)
            {
                if (boss.Prefab == bossPrefab)
                {
                    return boss.DisplayName;
                }
            }

            return null;
        }

        public static PrefabGUID GetUnitPrefabGUID(string bossName)
        {
            if (VBloodDatabase.TryGetValue(bossName.ToLower(), out var boss))
            {
                return boss.Prefab;
            }

            return default(PrefabGUID);
        }

        public static float3 GetBossPosition(string targetName)
        {
            if (VBloodDatabase.TryGetValue(targetName.ToLower(), out var boss))
            {
                return boss.Position.position;
            }

            throw new Exception($"Invalid target name '{targetName}'.");
        }

        public static string GetBossPositionText(string targetName)
        {
            if (VBloodDatabase.TryGetValue(targetName.ToLower(), out var boss))
            {
                return boss.Position.text;
            }

            throw new Exception($"Invalid target name '{targetName}'.");
        }

        internal static void GiveEquipmentSet(ChatCommandContext ctx, string setName)
        {
            if (ItemSetsDatabase.TryGetValue(setName, out var equipmentList))
            {
                var cpt = 0;
                foreach (var item in equipmentList)
                {
                    PrefabGUID prefab = new PrefabGUID(item.Prefab);

                    Entity entity = Helper.AddItemToInventory(ctx.Event.SenderCharacterEntity, prefab, 1);
                    if (entity == Entity.Null)
                    {
                        ctx.Reply(
                            $"Failed to add item <color=#ff0000>{item.Name.Replace("_", " ")}</color> to inventory, your inventory is full.");
                    }
                    else
                    {
                        cpt++;
                    }
                }

                ctx.Reply(
                    $"Given {cpt} out of {equipmentList.Count} items from the <color=#00ff00>{setName}</color> item set to the player.");
            }
            else
            {
                ctx.Reply($"Equipment set <color=#ff0000>{setName}</color> not found.");
            }
        }

        internal static void GiveSingleItem(ChatCommandContext ctx, string itemName)
        {
            var item = GetItem(ctx, itemName);
            if (item == null)
            {
                return;
            }

            PrefabGUID prefab = new PrefabGUID(item.Prefab);

            Entity entity = Helper.AddItemToInventory(ctx.Event.SenderCharacterEntity, prefab, 1);
            var replyMessage = entity != Entity.Null
                ? $"Given item <color=#00ff00>{item.Name.Replace("_", " ")}</color> to the player."
                : $"Failed to add item <color=#ff0000>{item.Name.Replace("_", " ")}</color> to inventory, your inventory is full.";

            ctx.Reply(replyMessage);
        }

        public static Item GetItem(ChatCommandContext ctx, string itemName)
        {
            var lowercaseItemName = itemName.ToLower();
            Item foundItem = null;
            var matchingItems = new List<Item>();

            foreach (var itemSet in ItemSetsDatabase.Values)
            {
                foreach (var item in itemSet)
                {
                    if (item.Name.ToLower().Contains(lowercaseItemName))
                    {
                        foundItem = item;
                        matchingItems.Add(item);
                    }
                }
            }

            switch (matchingItems.Count)
            {
                case 0:
                    return null;
                case 1:
                    return foundItem;
                default:
                    var matchedItemNames =
                        string.Join(", ", matchingItems.Select(i => $"<color=#00ff00>{i.Name}</color>"));
                    ctx.Reply($"Multiple matches found: {matchedItemNames}");
                    return null;
            }
        }

        internal static void GiveJewelSet(ChatCommandContext ctx, string jewelSet)
        {
            if (Database.JewelDictionary.TryGetValue(jewelSet.ToLower(), out var jewelList))
            {
                var count = 0;
                foreach (var jewel in jewelList)
                {
                    PrefabGUID prefab = jewel.PrefabGuid;

                    Entity entity = Helper.AddItemToInventory(ctx.Event.SenderCharacterEntity, prefab, 1);
                    if (entity == Entity.Null)
                    {
                        ctx.Reply(
                            $"Failed to add jewel <color=#ff0000>{jewel.Name.Replace("_", " ")}</color> to inventory, your inventory is full.");
                    }
                    else
                    {
                        count++;
                    }
                }

                ctx.Reply(
                    $"Given {count} out of {jewelList.Count} jewels from the <color=#00ff00>{jewelSet}</color> set to the player.");
            }
            else
            {
                ctx.Reply($"Jewel set <color=#ff0000>{jewelSet}</color> not found.");
            }
        }

        internal static void GiveSingleJewel(ChatCommandContext ctx, string jewelName, string jewelTier)
        {
            var jewel = GetJewel(ctx, jewelName, jewelTier);
            if (jewel == null)
            {
                return;
            }

            PrefabGUID prefab = jewel.PrefabGuid;

            Entity entity = Helper.AddItemToInventory(ctx.Event.SenderCharacterEntity, prefab, 1);
            var replyMessage = entity != Entity.Null
                ? $"Given jewel <color=#00ff00>{jewel.Name.Replace("_", " ")} {jewel.Tier}</color> to the player."
                : $"Failed to add jewel <color=#ff0000>{jewel.Name.Replace("_", " ")}</color> to inventory, your inventory is full.";

            ctx.Reply(replyMessage);
        }

        public static Jewel GetJewel(ChatCommandContext ctx, string jewelName, string jewelTier)
        {
            var lowercaseJewelName = jewelName.ToLower();
            var lowercaseJewelTier = jewelTier.ToLower();
            Jewel foundJewel = null;
            var matchingJewels = new List<Jewel>();

            foreach (var jewelSet in Database.JewelDictionary.Values)
            {
                foreach (var jewel in jewelSet)
                {
                    if (jewel.Name.ToLower().Contains(lowercaseJewelName) && jewel.Tier.ToLower() == lowercaseJewelTier)
                    {
                        foundJewel = jewel;
                        matchingJewels.Add(jewel);
                    }
                }
            }

            switch (matchingJewels.Count)
            {
                case 0:
                    return null;
                case 1:
                    return foundJewel;
                default:
                    var matchedJewelNames =
                        string.Join(", ", matchingJewels.Select(j => $"<color=#00ff00>{j.Name}</color>"));
                    ctx.Reply($"Multiple matches found: {matchedJewelNames}");
                    return null;
            }
        }

        public static Dictionary<string, (PrefabGUID, int)> GetMaterialDictionary { get; } = Database.MaterialDictionary;
    }
}