using System.Collections.Generic;
using CommunityCommands.Commons;
using ProjectM;
using Blood = CommunityCommands.Commons.Blood;

namespace CommunityCommands.Utils;

public class BloodUtils
{
    public static PrefabGUID GetBloodPotionRecipe()
    {
        return new PrefabGUID(1223264867);
    }

    public static PrefabGUID GetBloodPrefabGuid(string bloodName)
    {
        var bloodTypes = Database.BloodTypes;
        foreach (var blood in bloodTypes)
        {
            if (blood.name.ToLower().Equals(bloodName.ToLower()))
            {
                return blood.prefab;
            }
        }

        return default(PrefabGUID);
    }

    public static string GetBloodName(PrefabGUID prefab)
    {
        var bloodTypes = Database.BloodTypes;
        foreach (var blood in bloodTypes)
        {
            if (blood.prefab == prefab)
            {
                return blood.name;
            }
        }

        return "Frailed";
    }

    public static string GetBloodName(string blooName)
    {
        var bloodTypes = Database.BloodTypes;
        foreach (var blood in bloodTypes)
        {
            if (blood.name.ToLower().Equals(blooName.ToLower()))
            {
                return blood.name;
            }
        }

        return "Frailed";
    }
}