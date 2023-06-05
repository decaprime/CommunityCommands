using CommunityCommands.Utils;
using VampireCommandFramework;

namespace CommunityCommands.Commands;

public class UnlockAllAbilities
{
    [Command("unlockallabilities", "uaa", description: "Unlock all abilities for the player.", adminOnly: false)]
    public static void UnlockAllAbilitiesCommand(ChatCommandContext ctx)
    {
        CharacterUtil.UnlockAllAbilities(ctx);
    }
}