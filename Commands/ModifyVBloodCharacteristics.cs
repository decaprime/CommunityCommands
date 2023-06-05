using System.IO;
using CommunityCommands.Utils;
using ProjectM;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using VampireCommandFramework;

namespace CommunityCommands.Commands
{
    internal static class ModifyVBloodCharacteristics
    {
        [Command("modifyvblood", "mvb", description: "Modify the characteristics of the nearest VBlood.", adminOnly: false)]
        public static void ModifyVBloodCommand(ChatCommandContext ctx, int level)
        {
            var entityManager = Helper.Server.EntityManager;
            var playerEntity = ctx.Event.SenderCharacterEntity;

            // Get the closest VBlood entity with the specified PrefabGUID
            var closestVBlood = VBloodUtils.GetClosestVBlood(playerEntity);

            if (closestVBlood != null)
            {
                // Modify the UnitLevel component of the closest VBlood entity
                var unitLevel = entityManager.GetComponentData<UnitLevel>(closestVBlood.Value);
                unitLevel.Level = level;
                entityManager.SetComponentData(closestVBlood.Value, unitLevel);
                var unitStats = entityManager.GetComponentData<UnitStats>(closestVBlood.Value);
                unitStats.PhysicalPower.Value = 150;
               
                ctx.Reply($"Modified the characteristics of the nearest VBlood to level: {level}");
            }
            else
            {
                ctx.Reply("No VBlood found nearby.");
            }
        }

    }
}
