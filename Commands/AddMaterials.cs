using CommunityCommands.Utils;
using Unity.Entities;
using VampireCommandFramework;

namespace CommunityCommands.Commands
{
    public class AddMaterials
    {
        [Command("ct5", description: "Add some materials to a player's inventory to directly builde a level 5 castle.", adminOnly: false)]
        public static void AddMaterialsCommand(ChatCommandContext ctx, string playerName = "")
        {
            if (string.IsNullOrEmpty(playerName))
            {
                playerName = ctx.Event.User.CharacterName.ToString(); 
            }

            var playerEntity = CharacterUtil.GetPlayerEntityByName(playerName);

            if (playerEntity != Entity.Null)
            {
                foreach (var keyValuePair in DatabaseUtils.GetMaterialDictionary)
                {
                    Helper.AddItemToInventory(playerEntity, keyValuePair.Value.Item1, keyValuePair.Value.Item2);
                }
    
                ctx.Reply($"Materials added to {playerName}'s inventory.");
            }
            else
            {
                ctx.Reply($"Player '{playerName}' not found.");
            }
        }
    }
}