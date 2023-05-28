using ProjectM;
using Unity.Entities;
using VampireCommandFramework;
using System;
using Unity.Mathematics;
using Unity.Transforms;
using CommunityCommands.Commands;

namespace CommunityCommands.Commands
{
    internal static class SpawnBoss
    {
        [Command("spawnboss", "sb", description: "Spawn a boss next to the player", adminOnly: true)]
        public static void SpawnEnemy(ChatCommandContext ctx, string bossName, int quantity = 1)
        {
            var em = Helper.Server.EntityManager;
            var playerEntity = ctx.Event.SenderCharacterEntity;
            if (!em.Exists(playerEntity))
            {
                ctx.Reply("Player entity not found.");
                return;
            }

            if (bossName.ToLower() == "all")
            {
                var bossPrefabs = Database.GetBossPrefabs();
                if (bossPrefabs.Count == 0)
                {
                    ctx.Reply("No boss prefabs found.");
                    return;
                }

                int bossSpawnCount = 0;

                foreach (var bossPrefab in bossPrefabs)
                {
                    SpawnBosses(ctx, playerEntity, bossPrefab.Value, quantity);
                    bossSpawnCount++;
                }

                ctx.Reply($"Spawned <color=#ff0>{bossSpawnCount}</color> bosses next to the player.");
            }
            else
            {
                var bossPrefab = Database.GetUnitPrefabGUID(bossName);
                if (bossPrefab.Equals(default(PrefabGUID)))
                {
                    ctx.Reply($"Boss with name <color=#ff0000>{bossName}</color> not found.");
                    return;
                }

                SpawnBosses(ctx, playerEntity, bossPrefab, quantity);
            }
        }

        private static void SpawnBosses(ChatCommandContext ctx, Entity playerEntity, PrefabGUID bossPrefab,
            int quantity)
        {
            var em = Helper.Server.EntityManager;
            var enemyName = Database.GetUnitName(bossPrefab.ToString());
            if (string.IsNullOrEmpty(enemyName))
            {
                ctx.Reply("Boss name not found.");
                return;
            }

            try
            {
                var playerPosition = em.GetComponentData<LocalToWorld>(playerEntity).Position;
                var unitSpawnerSystem = Helper.Server.GetExistingSystem<UnitSpawnerUpdateSystem>();

                if (unitSpawnerSystem == null)
                {
                    ctx.Reply("Unit spawner system not found.");
                    return;
                }

                for (int i = 0; i < quantity; i++)
                {
                    float3 spawnPosition = GetRandomSpawnPosition(playerPosition);
                    unitSpawnerSystem.SpawnUnit(Entity.Null, bossPrefab, spawnPosition, 1, 1, 0f, 0f);
                }
                string spawnMessage = quantity == 1 ? $"Spawned <color=#ff0>{enemyName}</color> next to the player." :
                    $"Spawned <color=#ff0>{quantity} {enemyName}</color> next to the player.";

                ctx.Reply(spawnMessage);
            }
            catch (Exception e)
            {
                ctx.Reply($"An error occurred: {e.Message}");
            }
        }

        private static float3 GetRandomSpawnPosition(float3 playerPosition)
        {
            float spawnRadius = 15f;
            float2 randomOffset = UnityEngine.Random.insideUnitCircle * spawnRadius;
            float3 spawnPosition = playerPosition + new float3(randomOffset.x, 0f, randomOffset.y);
            return spawnPosition;
        }
    }
}
