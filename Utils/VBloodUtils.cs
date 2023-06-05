using System;
using CommunityCommands.Commons;
using ProjectM;
using ProjectM.Network;
using ProjectM.UI;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using VampireCommandFramework;

namespace CommunityCommands.Utils;

public class VBloodUtils
{
    private static readonly UnitSpawnerUpdateSystem UnitSpawnerSystem = Helper.Server.GetExistingSystem<UnitSpawnerUpdateSystem>();
    public static void SpawnAllBoss(ChatCommandContext ctx, Entity playerEntity, int quantity)
    {
        if (Database.BossDatabase.Count == 0)
        {
            ctx.Reply("There is no boss in the database.");
            return;
        }

        var bossSpawnCount = 0;

        foreach (var boss in Database.BossDatabase)
        {
            SpawnBosses(ctx, playerEntity, boss.Value.Prefab, quantity);
            bossSpawnCount++;
        }

        ctx.Reply($"Spawned <color=#ff0>{bossSpawnCount}</color> bosses next to <color=#ff0>{ctx.User.CharacterName}</color>.");
    }

    public static void SpawnSingleBoss(ChatCommandContext ctx, Entity playerEntity, string vBloodName, int quantity)
    {
        var bossPrefab = DatabaseUtils.GetUnitPrefabGUID(vBloodName);
        if (bossPrefab.Equals(default(PrefabGUID)))
        {
            ctx.Reply($"VBlood with name <color=#ff0000>{vBloodName}</color> not found.");
            return;
        }
        SpawnBosses(ctx, playerEntity, bossPrefab, quantity);
        var spawnMessage = quantity == 1
            ? $"Spawned <color=#ff0>{DatabaseUtils.GetUnitDisplayName(bossPrefab)}</color> next to <color=#ff0>{ctx.Event.User.CharacterName}</color>."
            : $"Spawned <color=#ff0>{quantity} {DatabaseUtils.GetUnitDisplayName(bossPrefab)}</color> next <color=#ff0>{ctx.Event.User.CharacterName}</color>.";

        ctx.Reply(spawnMessage);
    }

    private static void SpawnBosses(ChatCommandContext ctx, Entity playerEntity, PrefabGUID bossPrefab,
        int quantity)
    {
        var em = Helper.Server.EntityManager;
        try
        {
            var playerPosition = em.GetComponentData<LocalToWorld>(playerEntity).Position;

            if (UnitSpawnerSystem == null)
            {
                throw ctx.Error("Unit spawner system not found.");
            }

            for (var i = 0; i < quantity; i++)
            {
                float3 spawnPosition = GetRandomSpawnPosition(playerPosition);
                UnitSpawnerSystem.SpawnUnit(Entity.Null, bossPrefab, spawnPosition, 1, 1, 0f, 0f);
            }
        }
        catch (Exception e)
        {
            throw ctx.Error($"An error occurred: {e.Message}");
        }
    }

    private static float3 GetRandomSpawnPosition(float3 playerPosition)
    {
        var spawnRadius = 5f;
        float2 randomOffset = UnityEngine.Random.insideUnitCircle * spawnRadius;
        var spawnPosition = playerPosition + new float3(randomOffset.x, 0f, randomOffset.y);
        return spawnPosition;
    }
    
    public static Entity? GetClosestVBlood(Entity playerEntity)
    {
        var entityManager = Helper.Server.EntityManager;

        var origin = entityManager.GetComponentData<Translation>(playerEntity).Value;
        var closestDistance = float.MaxValue;
        Entity? closestVBlood = null;

        var vBloodEntities = entityManager.GetAllEntities();
        foreach (var entity in vBloodEntities)
        {
            if (entity == playerEntity || !entityManager.HasComponent<Translation>(entity))
                continue;

            // Vérifier si l'entité est un VBlood
            if (entityManager.HasComponent<VBloodUnit>(entity))
            {
                var position = entityManager.GetComponentData<Translation>(entity).Value;
                var distance = math.distance(origin, position);

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestVBlood = entity;
                }
            }
        }

        return closestVBlood;
    }
    
    public static Entity? GetVBloodByPrefabGUID(EntityManager entityManager, PrefabGUID prefabGUID)
    {
        var vBloodEntities = entityManager.GetAllEntities();

        foreach (var entity in vBloodEntities)
        {
            // Vérifier si l'entité est un VBlood et correspond au PrefabGUID spécifié
            if (entityManager.HasComponent<VBloodUnit>(entity) && entityManager.HasComponent<PrefabGUID>(entity))
            {
                var entityPrefabGUID = entityManager.GetComponentData<PrefabGUID>(entity);

                if (entityPrefabGUID.Equals(prefabGUID))
                {
                    return entity;
                }
            }
        }

        return null;
    }
    
    public static UnitStats GetUnitStats(EntityManager entityManager, Entity vBloodEntity)
    {
        if (entityManager.HasComponent<UnitStats>(vBloodEntity))
        {
            return entityManager.GetComponentData<UnitStats>(vBloodEntity);
        }
        else
        {
            throw new InvalidOperationException("VBlood entity is missing UnitStats component.");
        }
    }
}