using CommunityCommands.Commons;
using CommunityCommands.Utils;
using VampireCommandFramework;

namespace CommunityCommands.Commands
{
    public class Jewels
    {
        [Command("jewel", "jw", description: "Add a jewel in your inventory.", adminOnly: false)]
        public static void FindJewelPrefabCommand(ChatCommandContext ctx, GiveType type, string name,
            string jewelTier = "t02")
        {
            if (type == GiveType.Item)
            {
                DatabaseUtils.GiveSingleJewel(ctx, name, jewelTier);
            }
            else if (type == GiveType.Set)
            {
                DatabaseUtils.GiveJewelSet(ctx, name);
            }
            else
            {
                ctx.Reply($"No jewel or jewel set matching the name '{name}' and tier '{jewelTier}' was found.");
            }
        }
    }
}