using ProjectM;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using VampireCommandFramework;
using System;
using Il2CppSystem.Collections.Generic;
using Unity.Transforms;

namespace CommunityCommands.Commands
{
    internal static class GetPosition
    {
        [Command("getposition", "gp", description: "Get the current position of the player", adminOnly: false)]
        public static void GetPositionCommand(ChatCommandContext ctx)
        {
            var em = Helper.Server.EntityManager;
            var playerEntity = ctx.Event.SenderCharacterEntity;
            var translation = em.GetComponentData<Translation>(playerEntity);
            var currentPosition = translation.Value;

            ctx.Reply($"Current position: {currentPosition}");
        }
    }
}