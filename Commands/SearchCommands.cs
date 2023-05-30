using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectM;
using VampireCommandFramework;

namespace CommunityCommands.Commands;

public class SearchCommands
{
	[Command("search item", "si", adminOnly: true)]
	public static void GiveItem(ChatCommandContext ctx, string search, int page = 1)
	{
		var prefabSys = Core.Server.GetExistingSystem<PrefabCollectionSystem>();

		List<(string Name, PrefabGUID Prefab)> searchResults = new();
		try
		{
			foreach (var kvp in Core.Prefabs.NameToGuid)
			{
				if (kvp.Value.Name.StartsWith("Item_") && kvp.Key.Contains(search, StringComparison.OrdinalIgnoreCase))
				{
					searchResults.Add((kvp.Value.Name.Substring("Item_".Length), kvp.Value.Prefab));
				}
			}

			if (!searchResults.Any())
			{
				ctx.Reply("Could not find any matching prefabs.");
			}

			searchResults.OrderBy(kvp => kvp.Name);

			var sb = new StringBuilder();
			var totalCount = searchResults.Count;
			var pageSize = 8;
			var pageLabel = totalCount > pageSize ? $" (Page {page}/{Math.Ceiling(totalCount / (float)pageSize)})" : "";

			if (totalCount > pageSize)
			{
				searchResults = searchResults.Skip((page - 1) * pageSize).Take(pageSize).ToList();
			}

			sb.AppendLine($"Found {totalCount} matches {pageLabel}:");
			foreach (var match in searchResults)
			{
				sb.AppendLine(
					$"({match.Prefab.GuidHash}) {match.Name.Replace(search, $"<b>{search}</b>", StringComparison.OrdinalIgnoreCase)}");
			}

			ctx.Reply(sb.ToString());
		}
		catch (Exception e)
		{
			Core.LogException(e);
		}
	}
}
