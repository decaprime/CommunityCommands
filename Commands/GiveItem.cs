using CommunityCommands.Commons;
using CommunityCommands.Utils;
using VampireCommandFramework;

namespace CommunityCommands.Commands;

public class GiveItem
{
    [Command("give", "g", description: "Give a specific item or set of items to yourself", adminOnly: false)]
    public static void GiveItemCommand(ChatCommandContext ctx, GiveType type, string name)
    {
        switch (type)
        {
            case GiveType.Item:
                DatabaseUtils.GiveSingleItem(ctx, name);
                return;
            case GiveType.Set:
                DatabaseUtils.GiveEquipmentSet(ctx, name);
                break;
            default:
                throw ctx.Error(
                    "<color=#ff0000>Invalid give type.</color> Please specify either '<color=#ff0000>item</color>' or '<color=#ff0000>set</color>'.");
        }
    }
}