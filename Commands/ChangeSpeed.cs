using CommunityCommands.Utils;
using VampireCommandFramework;

namespace CommunityCommands.Commands;

public class ChangeSpeed
{
    [Command("changespeed", "cs", description: "Change the speed of your character.", adminOnly: false)]
    public static void ChangeSpeedCommand(ChatCommandContext ctx, float speed = 4.4f)
    {
        CharacterUtil.ChangeSpeed(ctx, speed);
    }
}