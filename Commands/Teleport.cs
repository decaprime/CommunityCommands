using Unity.Mathematics;
using VampireCommandFramework;
using CommunityCommands.Utils;
using System;

namespace CommunityCommands.Commands
{
    internal static class Teleport
    {
        [Command("teleport", "tp", description: "Teleport to a specific boss", adminOnly: false)]
        public static void TeleportToTarget(ChatCommandContext ctx, string targetName)
        {
            float3 targetPosition;
            try
            {
                targetPosition = DatabaseUtils.GetBossPosition(targetName);
            }
            catch (Exception e)
            {
                throw ctx.Error($"Error: {e.Message}");
            }

            if (targetPosition.Equals(float3.zero))
            {
                ctx.Reply($"{DatabaseUtils.GetBossPositionText(targetName)}");
                return;
            }

            CharacterUtil.TeleportToPos(ctx, targetName, targetPosition);
        }
    }
}