using BepInEx;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;
using VampireCommandFramework;
namespace CommunityCommands;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
[BepInDependency("gg.deca.VampireCommandFramework")]
[VampireCommandFramework.Breadstone.Reloadable]
public class Plugin : BasePlugin
{
	Harmony _harmony;

	public override void Load()
	{
		// Plugin startup logic
		Log.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} version {MyPluginInfo.PLUGIN_VERSION} is loaded!");

		// Harmony patching
		_harmony = new Harmony(MyPluginInfo.PLUGIN_GUID);
		_harmony.PatchAll(System.Reflection.Assembly.GetExecutingAssembly());

		// Register all commands in the assembly with VCF
		CommandRegistry.RegisterAll();
	}

	public override bool Unload()
	{
		CommandRegistry.UnregisterAssembly();
		_harmony?.UnpatchSelf();
		return true;
	}
}
