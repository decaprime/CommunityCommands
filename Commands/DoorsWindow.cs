using System.Collections.Generic;
using CommunityCommands.Utils;
using ProjectM;
using ProjectM.CastleBuilding;
using ProjectM.Scripting;
using Unity.Collections;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;
using VampireCommandFramework;

namespace CommunityCommands.Commands
{
    public class DoorsWindow
    {
        [Command("close-all", "ca", description: "Close all doors.", adminOnly: false)]
        public static void CloseAll(ChatCommandContext ctx, DoorWindow? target = null) => ChangeDoorWindows(ctx, false, target);

        [Command("open-all", "oa", description: "Open all doors.", adminOnly: false)]
        public static void OpenAll(ChatCommandContext ctx, DoorWindow? target = null) => ChangeDoorWindows(ctx, true, target);

        public enum DoorWindow { Doors, Windows }
        private static readonly HashSet<int> WINDOW_PREFABS = new HashSet<int> { -1771014048 };
        private const float MaxCastleDistance = 60f;

        public struct DoorState
        {
            public Entity Entity;
            public bool OpenState;
        }

        public static void ChangeDoorWindows(ChatCommandContext ctx, bool open, DoorWindow? target)
        {
            var character = ctx.Event.SenderCharacterEntity;
            var castleHearts = Helper.Server.EntityManager.CreateEntityQuery(ComponentType.ReadOnly<CastleHeart>(), ComponentType.ReadOnly<LocalToWorld>())
                .ToEntityArray(Allocator.Temp);
            var gameManager = Helper.Server.GetExistingSystem<ServerScriptMapper>()?._ServerGameManager;
            var playerPos = Helper.Server.EntityManager.GetComponentData<LocalToWorld>(character).Position;

            var closestCastle = Entity.Null;
            float closest = float.MaxValue;

            foreach (var castle in castleHearts)
            {
                var isPlayerOwned = gameManager.Value.IsAllies(character, castle);
                if (!isPlayerOwned) continue;

                var castlePos = Helper.Server.EntityManager.GetComponentData<LocalToWorld>(castle).Position;
                var distance = Vector3.Distance(castlePos, playerPos);
                if (distance < closest && distance < MaxCastleDistance)
                {
                    closest = distance;
                    closestCastle = castle;
                }
            }

            if (closestCastle == Entity.Null)
            {
                ctx.Reply("Could not find nearby castle you own");
                return;
            }

            var doors = Helper.Server.EntityManager.CreateEntityQuery(new EntityQueryDesc()
            {
                All = new[] { ComponentType.ReadWrite<Door>(), ComponentType.ReadOnly<CastleHeartConnection>(), ComponentType.ReadOnly<PrefabGUID>(), ComponentType.ReadOnly<Team>() },
                Options = EntityQueryOptions.IncludeDisabled
            }).ToEntityArray(Allocator.Temp);

            var doorStates = new List<DoorState>();

            int count = 0;
            for (int i = 0; i < doors.Length; i++)
            {
                var connection = Helper.Server.EntityManager.GetComponentData<CastleHeartConnection>(doors[i]);
                if (connection.CastleHeartEntity._Entity != closestCastle) continue;

                if (target != null)
                {
                    var prefab = Helper.Server.EntityManager.GetComponentData<PrefabGUID>(doors[i]);

                    if (target == DoorWindow.Doors && WINDOW_PREFABS.Contains(prefab.GuidHash)) continue;
                    if (target == DoorWindow.Windows && !WINDOW_PREFABS.Contains(prefab.GuidHash)) continue;
                }

                var doorState = new DoorState
                {
                    Entity = doors[i],
                    OpenState = open,
                    
                };
                doorStates.Add(doorState);
                count++;
            }

            var doorComponents = Helper.Server.EntityManager.GetComponentDataFromEntity<Door>(true);

            foreach (var doorState in doorStates)
            {
                var door = doorComponents[doorState.Entity];
                door.OpenState = doorState.OpenState;
                doorComponents[doorState.Entity] = door;
            }
            doorStates.Clear();

            ctx.Reply($"Changed {count} {(target?.ToString() ?? "Windows and Doors")}");
        }
    }
}
