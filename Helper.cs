using ProjectM;
using Unity.Entities;
using UnityEngine;
using Unity.Transforms;
using Unity.Mathematics;

namespace CommunityCommands;

internal static class Helper
{
	private static World _serverWorld;
	private static Entity empty_entity = new Entity();
	public static World Server
	{
		get
		{
			if (_serverWorld != null) return _serverWorld;

			_serverWorld = GetWorld("Server")
				?? throw new System.Exception("There is no Server world (yet). Did you install a server mod on the client?");
			return _serverWorld;
		}
	}

	public static bool IsServer => Application.productName == "VRisingServer";

	private static World GetWorld(string name)
	{
		foreach (var world in World.s_AllWorlds)
		{
			if (world.Name == name)
			{
				return world;
			}
		}

		return null;
	}

	public static bool SpawnAtPosition(Entity user, string name, int count, float2 position, float minRange = 1, float maxRange = 2, float duration = -1)
	{
		var isFound = Database.database_units.TryGetValue(name, out var unit);
		if (!isFound) return false;

		var translation = Server.EntityManager.GetComponentData<Translation>(user);
		var f3pos = new float3(position.x, translation.Value.y, position.y);
		Server.GetExistingSystem<UnitSpawnerUpdateSystem>().SpawnUnit(empty_entity, unit, f3pos, count, minRange, maxRange, duration);
		return true;
	}

	public static PrefabGUID GetPrefabGUID(Entity entity)
	{
		var entityManager = Server.EntityManager;
		PrefabGUID guid;
		try
		{
			guid = entityManager.GetComponentData<PrefabGUID>(entity);
		}
		catch
		{
			guid.GuidHash = 0;
		}
		return guid;
	}

	public static Entity AddItemToInventory(Entity recipient, PrefabGUID guid, int amount)
	{
		var gameData = Server.GetExistingSystem<GameDataSystem>();
		var itemSettings = AddItemSettings.Create(Server.EntityManager, gameData.ItemHashLookupMap);
		var inventoryResponse = InventoryUtilitiesServer.TryAddItem(itemSettings, recipient, guid, amount);
		return inventoryResponse.NewEntity;
	}
}
