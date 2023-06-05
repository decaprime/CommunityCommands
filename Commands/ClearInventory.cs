using CommunityCommands.Utils;
using VampireCommandFramework;

namespace CommunityCommands.Commands;

public class ClearInventory
{
    [Command("clearinventory", "ci", description: "Clears your inventory", adminOnly: false)]
    public static void ClearInventoryCommand(ChatCommandContext ctx)
    {
        CharacterUtil.ClearInventory(ctx);
    }
}