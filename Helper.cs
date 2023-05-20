using ProjectM;
using ProjectM.Network;
using System;
using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace CommunityCommands;

internal static class Helper
{
	private static World _serverWorld;

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
