using CommunityCommands.Commands.Converters;
using ProjectM;
using VampireCommandFramework;

namespace CommunityCommands.Commands;

public class KillCommands
{
	[Command("kill", adminOnly: true)]
	public void KillCommand(ChatCommandContext ctx, FoundPlayer player = null)
	{
		StatChangeUtility.KillEntity(Core.EntityManager, player?.Value.CharEntity ?? ctx.Event.SenderCharacterEntity,
			ctx.Event.SenderCharacterEntity, 0, true);

		ctx.Reply($"Killed {player?.Value.CharacterName ?? "you"}.");
	}
}