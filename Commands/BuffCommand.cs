using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityCommands.Commands.Converters;
using ProjectM;
using ProjectM.Network;
using Unity.Entities;
using VampireCommandFramework;

namespace CommunityCommands.Commands;
internal class BuffCommands
{
	[Command("buff", adminOnly: true)]
	public void BuffCommand(ChatCommandContext ctx, int prefabBuff, OnlinePlayer player = null)
	{

		if (!player?.Value.IsOnline ?? false)
		{
			throw ctx.Error("Player not found or not online.");
		}

		var des = Core.Server.GetExistingSystem<DebugEventsSystem>();
		var buffEvent = new ApplyBuffDebugEvent()
		{
			BuffPrefabGUID = new PrefabGUID(prefabBuff)
		};

		var fromCharacter = new FromCharacter()
		{
			User = player?.Value.UserEntity ?? ctx.Event.SenderUserEntity,
			Character = player?.Value.CharEntity ?? ctx.Event.SenderCharacterEntity
		};

		des.ApplyBuff(fromCharacter, buffEvent);
	}
}
