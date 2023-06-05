using CommunityCommands.Utils;
using VampireCommandFramework;

namespace CommunityCommands.Commands;

public class UnlockAllResearch
{
    [Command("unlockallresearch", "uar", description: "Unlock all research for the player.", adminOnly: false)]
    public static void UnlockAllResearchCommand(ChatCommandContext ctx)
    {
        CharacterUtil.UnlockAllResearch(ctx);
    }
}