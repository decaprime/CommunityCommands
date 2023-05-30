using System.Text.RegularExpressions;

using CommunityCommands;
using CommunityCommands.Commands.Converters;
using Unity.Collections;
using VampireCommandFramework;

namespace CommunityCommands.Commands;

public static class RenameCommands
{
	[Command("rename", description: "Rename another player.", adminOnly: true)]
	public static void RenameOther(ChatCommandContext ctx, FoundPlayer player, NewName newName)
	{
		Core.Players.RenamePlayer(player.Value.UserEntity, player.Value.CharEntity, newName.Name);
		ctx.Reply($"Renamed {Format.B(player.Value.CharacterName.ToString())} -> {Format.B(newName.Name.ToString())}");
	}

	[Command("rename", description: "Rename yourself.", adminOnly: true)]
	public static void RenameMe(ChatCommandContext ctx, NewName newName)
	{
		Core.Players.RenamePlayer(ctx.Event.SenderUserEntity, ctx.Event.SenderCharacterEntity, newName.Name);
		ctx.Reply($"Your name has been updated to: {Format.B(newName.Name.ToString())}");
	}

	public record struct NewName(FixedString64 Name);

	public class NewNameConverter : CommandArgumentConverter<NewName>
	{
		public override NewName Parse(ICommandContext ctx, string input)
		{
			if (!IsAlphaNumeric(input))
			{
				throw ctx.Error("Name must be alphanumeric.");
			}
			var newName = new NewName(input);
			if (newName.Name.utf8LengthInBytes > 20)
			{
				throw ctx.Error("Name too long.");
			}

			return newName;
		}
		public bool IsAlphaNumeric(string input)
		{
			return Regex.IsMatch(input, @"^[a-zA-Z0-9]+$");
		}
	}
}
