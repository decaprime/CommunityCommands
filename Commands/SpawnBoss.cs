using ProjectM;
using Unity.Entities;
using VampireCommandFramework;
using System;
using CommunityCommands.Commons;
using Unity.Mathematics;
using Unity.Transforms;
using CommunityCommands.Utils;


namespace CommunityCommands.Commands
{
    internal static class SpawnBoss
    {
        [Command("spawn", "s", description: "Spawn a vblood or npc next to the player", adminOnly: false)]
        public static void SpawnBossCommand(ChatCommandContext ctx, SpawnType type, string vBloodName = "wolf", int quantity = 1)
        {
            if (type == SpawnType.All)
            {
                VBloodUtils.SpawnAllBoss(ctx, ctx.Event.SenderCharacterEntity, quantity);
            }
            else if (type == SpawnType.Vblood)
            {
                VBloodUtils.SpawnSingleBoss(ctx, ctx.Event.SenderCharacterEntity, vBloodName, quantity);   
            }
        }
    }
}