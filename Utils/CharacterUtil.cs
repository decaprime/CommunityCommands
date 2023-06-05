using System;
using CommunityCommands.Utils;
using ProjectM;
using ProjectM.Network;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using VampireCommandFramework;

namespace CommunityCommands.Commands
{
    public static class CharacterUtil
    {
        private static EntityManager EntityManager = Helper.Server.EntityManager;

        public static void TeleportToPos(ChatCommandContext ctx, string targetName, float3 pos)
        {
            var entity = EntityManager.CreateEntity(
                ComponentType.ReadWrite<FromCharacter>(),
                ComponentType.ReadWrite<PlayerTeleportDebugEvent>());

            EntityManager.SetComponentData<FromCharacter>(entity, new()
            {
                User = ctx.Event.SenderUserEntity,
                Character = ctx.Event.SenderCharacterEntity
            });

            EntityManager.SetComponentData<PlayerTeleportDebugEvent>(entity, new()
            {
                Position = new float3(pos.x, pos.y, pos.z),
                Target = PlayerTeleportDebugEvent.TeleportTarget.Self
            });
            
            var messageReply = DatabaseUtils.GetBossPositionText(targetName.ToLower()) == "None"
                ? ""
                : DatabaseUtils.GetBossPositionText(targetName.ToLower());
            ctx.Reply($"Teleported to <color=#ff00ff>{DatabaseUtils.GetUnitDisplayName(targetName)}</color>.{messageReply}");
        }
        
        public static void ClearInventory(ChatCommandContext ctx )
        {
            Entity characterEntity = ctx.Event.SenderCharacterEntity;
            if (!InventoryUtilities.TryGetInventoryEntity(EntityManager, characterEntity, out Entity playerInventory) ||
                playerInventory == Entity.Null)
                return;

            var inventoryBuffer = EntityManager.GetBuffer<InventoryBuffer>(playerInventory);

            foreach (var inventoryItem in inventoryBuffer)
            {
                InventoryUtilitiesServer.TryRemoveItem(EntityManager, playerInventory, inventoryItem.ItemType,
                    inventoryItem.Amount);
            }
            ctx.Reply("Inventory cleared.");
        }

        public static void ResetSkillsCooldown(Entity characterEntity)
        {
            var AbilityBuffer = EntityManager.GetBuffer<AbilityGroupSlotBuffer>(characterEntity);
            foreach (var ability in AbilityBuffer)
            {
                var AbilitySlot = ability.GroupSlotEntity._Entity;
                var ActiveAbility = EntityManager.GetComponentData<AbilityGroupSlot>(AbilitySlot);
                var ActiveAbility_Entity = ActiveAbility.StateEntity._Entity;

                var b = GetPrefabGUID(ActiveAbility_Entity);
                if (b.GuidHash == 0) continue;

                var AbilityStateBuffer = EntityManager.GetBuffer<AbilityStateBuffer>(ActiveAbility_Entity);
                foreach (var state in AbilityStateBuffer)
                {
                    var abilityState = state.StateEntity._Entity;
                    var abilityCooldownState = EntityManager.GetComponentData<AbilityCooldownState>(abilityState);
                    abilityCooldownState.CooldownEndTime = 0;
                    EntityManager.SetComponentData(abilityState, abilityCooldownState);
                }
            }
        }
        
        public static void RecoverHealt(ChatCommandContext ctx)
        {
            var userIndex = ctx.Event.User.Index;
            var entityManager = Helper.Server.EntityManager;
            var component = entityManager.GetComponentData<Health>(ctx.Event.SenderCharacterEntity);

            var restoreHp = ((component.MaxHealth / 100) * 100) - component.Value;

            var healthEvent = new ChangeHealthDebugEvent()
            {
                Amount = (int)restoreHp
            };

            Helper.Server.GetExistingSystem<DebugEventsSystem>().ChangeHealthEvent(userIndex, ref healthEvent);
            
            if (BuffUtility.TryGetBuff(entityManager, ctx.Event.SenderCharacterEntity, new PrefabGUID(697095869),
                    out var inCombatBuff))
            {
                entityManager.AddComponent<DestroyTag>(inCombatBuff);
            }
        }
        
        public static void UnlockAllAbilities(ChatCommandContext ctx)
        {
            try
            {
                var fromCharacter = new FromCharacter();
                fromCharacter.Character = ctx.Event.SenderCharacterEntity;
                fromCharacter.User = ctx.Event.SenderUserEntity;

                Helper.Server.GetExistingSystem<DebugEventsSystem>().UnlockAllVBloods(fromCharacter);
                ctx.Reply("Unlocked all abilities for the player.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw ctx.Error(e.Message);
            }
        }

        public static void UnlockAllResearch(ChatCommandContext ctx)
        {
            try
            {
                var fromCharacter = new FromCharacter();
                fromCharacter.Character = ctx.Event.SenderCharacterEntity;
                fromCharacter.User = ctx.Event.SenderUserEntity;

                Helper.Server.GetExistingSystem<DebugEventsSystem>().UnlockAllResearch(fromCharacter);
                ctx.Reply("Unlocked all research for the player.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw ctx.Error(e.Message);
            }
        }
        
        public static void UnlockAllQuest(ChatCommandContext ctx)
        {
            try
            {
                var debugEventsSystem = Helper.Server.GetExistingSystem<DebugEventsSystem>();
            
                var fromCharacter = new FromCharacter
                {
                    Character = ctx.Event.SenderCharacterEntity,
                    User = ctx.Event.SenderUserEntity
                };

                var commandBuffer = new EntityCommandBuffer(Allocator.Temp);

                debugEventsSystem.CompleteJournal(commandBuffer, fromCharacter);

                commandBuffer.Playback(Helper.Server.EntityManager);
                commandBuffer.Dispose();

                ctx.Reply("Unlocked all quests for the player.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw ctx.Error(e.Message);
            }
        }
        
        public static void ChangeSpeed(ChatCommandContext ctx, float speed)
        {
            Entity characterEntity = ctx.Event.SenderCharacterEntity;
            var component = EntityManager.GetComponentData<Movement>(characterEntity);
            component.Speed = ModifiableFloat.Create(characterEntity, EntityManager, speed);
            EntityManager.SetComponentData(characterEntity, component);
            ctx.Reply($"Speed of character changed to {speed}");
        }
        
        public static void GetPlayerPosition(ChatCommandContext ctx)
        {
            var em = Helper.Server.EntityManager;
            var playerEntity = ctx.Event.SenderCharacterEntity;
            var translation = em.GetComponentData<Translation>(playerEntity);
            var currentPosition = translation.Value;

            ctx.Reply($"Current position: {currentPosition}");
        }

        private static PrefabGUID GetPrefabGUID(Entity entity)
        {
            PrefabGUID guid;
            try
            {
                guid = EntityManager.GetComponentData<PrefabGUID>(entity);
            }
            catch
            {
                guid.GuidHash = 0;
            }

            return guid;
        }

        public static Entity GetPlayerEntityByName(string playerName)
        {
            playerName = playerName.ToLower();
            var entityManager = Helper.Server.EntityManager;
            var characterDataEntities = GetAllPlayers();

            foreach (var characterDataEntity in characterDataEntities)
            {
                var characterData = entityManager.GetComponentData<PlayerCharacter>(characterDataEntity);
                if (characterData.Name.ToString().ToLower().Equals(playerName))
                {
                    characterDataEntities.Dispose();
                    return characterDataEntity;
                }
            }
            characterDataEntities.Dispose();
            return Entity.Null;
        }


        public static NativeArray<Entity> GetAllPlayers()
        {
            var query = Helper.Server.EntityManager.CreateEntityQuery(
                ComponentType.ReadOnly<ProjectM.PlayerCharacter>()
            );
            return query.ToEntityArray(Allocator.Temp);
        }

     


        
        private static FromCharacter GetFromCharacter(ChatCommandContext ctx)
        {
            var fromCharacter = new FromCharacter();
            fromCharacter.Character = ctx.Event.SenderCharacterEntity;
            fromCharacter.User = ctx.Event.SenderUserEntity;
            return fromCharacter;
        }
    }
}