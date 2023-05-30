using Unity.Collections;
using Unity.Entities;

namespace CommunityCommands.Models;

public struct PlayerData
{
	public FixedString64 CharacterName { get; set; }
	public ulong SteamID { get; set; }
	public bool IsOnline { get; set; }
	public Entity UserEntity { get; set; }
	public Entity CharEntity { get; set; }
	public PlayerData(FixedString64 characterName = default, ulong steamID = 0, bool isOnline = false, Entity userEntity = default, Entity charEntity = default)
	{
		CharacterName = characterName;
		SteamID = steamID;
		IsOnline = isOnline;
		UserEntity = userEntity;
		CharEntity = charEntity;
	}
}
