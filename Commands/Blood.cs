using ProjectM;
using Unity.Entities;
using UnityEngine;
using VampireCommandFramework;
using CommunityCommands.Utils;

namespace CommunityCommands.Commands;

internal static class Blood
{
    [Command("bloodpotion", "bp", description: "Creates a Potion with specified Blood Type, Quality and Value",
        adminOnly: false)]
    public static void GiveBloodPotionCommand(ChatCommandContext ctx, string bloodName = "Frailed",
        float quality = 100f)
    {
        quality = Mathf.Clamp(quality, 0, 100);
        var em = Helper.Server.EntityManager;

        Entity entity =
            Helper.AddItemToInventory(ctx.Event.SenderCharacterEntity, BloodUtils.GetBloodPotionRecipe(), 1);

        var blood = new StoredBlood()
        {
            BloodQuality = quality,
            BloodType = BloodUtils.GetBloodPrefabGuid(bloodName)
        };

        em.SetComponentData(entity, blood);

        ctx.Reply(
            $"Got Blood Potion Type <color=#ff0>{BloodUtils.GetBloodName(bloodName)}</color> with <color=#ff0>{(int)quality}</color>% quality");
    }
}