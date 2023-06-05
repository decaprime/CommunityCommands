using CommunityCommands.Utils;
using VampireCommandFramework;

namespace CommunityCommands.Commands
{
    using ProjectM;
    using Unity.Entities;
    using Unity.Transforms;
    using Unity.Collections;
    using Unity.Mathematics;
    using System.Collections.Generic;

    internal static class HorseUtil
    {
        private static Entity empty_entity = new Entity();

        internal static void SpawnHorse(int countlocal, float3 localPos)
        {
            Helper.Server.GetExistingSystem<UnitSpawnerUpdateSystem>().SpawnUnit(empty_entity,
                new PrefabGUID(1149585723), new float3(localPos.x, 0, localPos.z), countlocal, 1, 2, -1);
        }

        internal static NativeArray<Entity> GetHorses()
        {
            var horseQuery = Helper.Server.EntityManager.CreateEntityQuery(new EntityQueryDesc()
            {
                All = new[]
                {
                    ComponentType.ReadWrite<FeedableInventory>(),
                    ComponentType.ReadWrite<NameableInteractable>(),
                    ComponentType.ReadWrite<Mountable>(),
                    ComponentType.ReadOnly<LocalToWorld>(),
                    ComponentType.ReadOnly<Team>()
                },
                None = new[] { ComponentType.ReadOnly<Dead>(), ComponentType.ReadOnly<DestroyTag>() }
            });

            return horseQuery.ToEntityArray(Unity.Collections.Allocator.Temp);
        }

        internal static Entity? GetClosetHorse(Entity e)
        {
            var horseEntityQuery = GetHorses();


            var origin = Helper.Server.EntityManager.GetComponentData<LocalToWorld>(e).Position;
            var closest = float.MaxValue;

            Entity? closestHorse = null;
            foreach (var horse in horseEntityQuery)
            {
                var position = Helper.Server.EntityManager.GetComponentData<LocalToWorld>(horse).Position;
                var distance = UnityEngine.Vector3.Distance(origin, position);
                if (distance < closest)
                {
                    closest = distance;
                    closestHorse = horse;
                }
            }

            return closestHorse;
        }

        internal static List<Entity> ClosestHorses(Entity e, float radius = 5f)
        {
            var horses = GetHorses();
            var results = new List<Entity>();
            var origin = Helper.Server.EntityManager.GetComponentData<LocalToWorld>(e).Position;

            foreach (var horse in horses)
            {
                var position = Helper.Server.EntityManager.GetComponentData<LocalToWorld>(horse).Position;
                var distance = UnityEngine.Vector3.Distance(origin, position); // wait really?
                if (distance < radius)

                {
                    results.Add(horse);
                }
            }

            return results;
        }

        internal static void ModifyHorseAttributes(ChatCommandContext ctx, Entity horseEntity, float maxSpeed, float acceleration, float rotation)
        {
            var em = Helper.Server.EntityManager;
            var mountableComponents = em.GetComponentDataFromEntity<Mountable>(true);

            if (mountableComponents.HasComponent(horseEntity))
            {
                var mountable = mountableComponents[horseEntity];
                mountable.MaxSpeed = maxSpeed;
                mountable.Acceleration = acceleration;
                mountable.RotationSpeed = rotation * 10;
                mountableComponents[horseEntity] = mountable;
            }
        }

    }
}