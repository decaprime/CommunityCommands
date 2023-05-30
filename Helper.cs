using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CommunityCommands.Data;
using ProjectM;
using ProjectM.Network;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using static ProjectM.Roofs.RoofTestSceneBootstrapNew;

namespace CommunityCommands;

// This is an anti-pattern, move stuff away from Helper not into it
internal static partial class Helper
{
	public static PrefabGUID GetPrefabGUID(Entity entity)
	{
		var entityManager = Core.EntityManager;
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
		try
		{
			var gameData = Core.Server.GetExistingSystem<GameDataSystem>();
			var itemSettings = AddItemSettings.Create(Core.EntityManager, gameData.ItemHashLookupMap);
			var inventoryResponse = InventoryUtilitiesServer.TryAddItem(itemSettings, recipient, guid, amount);

			return inventoryResponse.NewEntity;
		}
		catch (Exception e)
		{
			Core.LogException(e);
		}
		return new Entity();
	}
}
