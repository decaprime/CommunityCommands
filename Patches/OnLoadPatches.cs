using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using ProjectM;
using ProjectM.Gameplay.Systems;
using ProjectM.Shared;


namespace CommunityCommands.Patches;

[HarmonyPatch(typeof(SpawnTeamSystem_OnPersistenceLoad), nameof(SpawnTeamSystem_OnPersistenceLoad.OnUpdate))]
public static class InitializationPatch
{
	[HarmonyPostfix]
	public static void OneShot_AfterLoad_InitializationPatch()
	{
		Core.InitializeAfterLoaded();
		Plugin.Harmony.Unpatch(typeof(SpawnTeamSystem_OnPersistenceLoad).GetMethod("OnUpdate"), typeof(InitializationPatch).GetMethod("OneShot_AfterLoad_InitializationPatch"));
	}
}
