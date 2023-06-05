using ProjectM;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using VampireCommandFramework;
using System;
using CommunityCommands.Utils;
using Il2CppSystem.Collections.Generic;
using Unity.DebugDisplay;
using Unity.Transforms;

namespace CommunityCommands.Commands
{
    internal static class Horse
    {
        [Command("horse", "h", description: "Manage horses (spawn or set max attributes)", adminOnly: false)]
        public static void HorseCommand(ChatCommandContext ctx, string subCommand, int quantity = 1, float speed = 11f,
            float acceleration = 7.0f, float rotation = 14.0f)
        {
            var em = Helper.Server.EntityManager;
            var playerEntity = ctx.Event.SenderCharacterEntity;
            if (!em.Exists(playerEntity))
            {
                ctx.Reply("Player entity not found.");
                return;
            }

            subCommand = subCommand.ToLower();

            if (subCommand == "spawn")
            {
                SpawnHorse(ctx, playerEntity, quantity, speed, acceleration, rotation);
            }
            else if (subCommand == "max")
            {
                SetMaxAttributes(ctx, playerEntity, speed, acceleration, rotation);
            }
            else
            {
                ctx.Reply("Invalid subcommand. Available subcommands: spawn, max.");
            }
        }

        private static void SpawnHorse(ChatCommandContext ctx, Entity playerEntity, int quantity, float speed,
            float acceleration, float rotation)
        {
            try
            {
                var em = Helper.Server.EntityManager;
                var playerPosition = em.GetComponentData<Translation>(playerEntity).Value;

                for (int i = 0; i < quantity; i++)
                {
                    HorseUtil.SpawnHorse(1, playerPosition);
                }

                ctx.Reply($"Spawned {quantity} horse(s) next to the player.");
            }
            catch (Exception e)
            {
                throw ctx.Error($"An error occurred: {e.Message}");
            }
        }

        private static void SetMaxAttributes(ChatCommandContext ctx, Entity playerEntity, float speed,
            float acceleration, float rotation)
        {
           
                var closestHorse = HorseUtil.GetClosetHorse(playerEntity);

                if (closestHorse != null)
                {
                    HorseUtil.ModifyHorseAttributes(ctx, closestHorse.Value, speed, acceleration, rotation);

                    ctx.Reply(
                        $"Changed attributes for the closest horse: Speed: {speed}, Acceleration: {acceleration}, Rotation: {rotation}");
                }
                else
                {
                    ctx.Reply("No horse found nearby.");
                }

        }
    }
}