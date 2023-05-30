using CommunityCommands.Commands.Converters;
using ProjectM;
using Unity.Entities;
using VampireCommandFramework;

namespace CommunityCommands.Commands;

public static class ResetCooldown
{
	[Command("resetcooldown", "cd", "Instantly cooldown all ability & skills for the player.", adminOnly: true)]
	public static void Initialize(ChatCommandContext ctx, FoundPlayer player = null)
	{
		Entity PlayerCharacter = player?.Value.CharEntity ?? ctx.Event.SenderCharacterEntity;
		string name = player?.Value.CharacterName.ToString() ?? ctx.Name;

		var AbilityBuffer = Core.EntityManager.GetBuffer<AbilityGroupSlotBuffer>(PlayerCharacter);
		foreach (var ability in AbilityBuffer)
		{
			var AbilitySlot = ability.GroupSlotEntity._Entity;
			var ActiveAbility = Core.EntityManager.GetComponentData<AbilityGroupSlot>(AbilitySlot);
			var ActiveAbility_Entity = ActiveAbility.StateEntity._Entity;

			var b = Helper.GetPrefabGUID(ActiveAbility_Entity);
			if (b.GuidHash == 0) continue;

			var AbilityStateBuffer = Core.EntityManager.GetBuffer<AbilityStateBuffer>(ActiveAbility_Entity);
			foreach (var state in AbilityStateBuffer)
			{
				var abilityState = state.StateEntity._Entity;
				var abilityCooldownState = Core.EntityManager.GetComponentData<AbilityCooldownState>(abilityState);
				abilityCooldownState.CooldownEndTime = 0;
				Core.EntityManager.SetComponentData(abilityState, abilityCooldownState);
			}
		}

		ctx.Reply($"Player \"{name}\" cooldown reset.");
	}
}
