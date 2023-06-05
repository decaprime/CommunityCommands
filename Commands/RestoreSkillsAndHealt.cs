using CommunityCommands.Utils;
using VampireCommandFramework;

namespace CommunityCommands.Commands;

public class RestoreSkillsAndHealt
{
    [Command("reset", "rs", description: "Restore healt ( 100% ) and reset skills cooldown.", adminOnly: false)]
    public static void RestoreSkillsAndHealtCommand(ChatCommandContext ctx)
    {
        CharacterUtil.RecoverHealt(ctx);
        CharacterUtil.ResetSkillsCooldown(ctx.Event.SenderCharacterEntity);
        ctx.Reply("Health and skills cooldown restored.");
    }
}