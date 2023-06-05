using ProjectM;
using System.Collections.Generic;
using CommunityCommands.Commands;

namespace CommunityCommands
{
    public class Database
    {
        private static Dictionary<string, (string name, PrefabGUID)> GetUnitDatabase()
        {
            Dictionary<string, (string name, PrefabGUID)> database_units =
                new Dictionary<string, (string name, PrefabGUID)>
                {
                    { "wolf", ("Alpha Wolf", new PrefabGUID(-1905691330)) },
                    { "errol", ("Errol the Stonebreaker", new PrefabGUID(-2025101517)) },
                    { "keely", ("Keely the Frost Archer", new PrefabGUID(1124739990)) },
                    { "rufus", ("Rufus the Foreman", new PrefabGUID(2122229952)) },
                    { "goreswine", ("Goreswine the Ravager", new PrefabGUID(577478542)) },
                    { "grayson", ("Grayson the Armourer", new PrefabGUID(1106149033)) },
                    { "rat", ("Putrid Rat", new PrefabGUID(-2039908510)) },
                    { "lidia", ("Lidia the Chaos Archer", new PrefabGUID(763273073)) },
                    { "clive", ("Clive the Firestarter", new PrefabGUID(1896428751)) },
                    { "bear", ("Ferocious Bear", new PrefabGUID(-1391546313)) },
                    { "polora", ("Polora the Feywalker", new PrefabGUID(-484556888)) },
                    { "nicholaus", ("Nicholaus the Fallen", new PrefabGUID(153390636)) },
                    { "quincey", ("Quincey the Bandit King", new PrefabGUID(-1659822956)) },
                    { "beatrice", ("Beatrice the Tailor", new PrefabGUID(-1942352521)) },
                    { "tristan", ("Tristan the Vampire Hunter", new PrefabGUID(-1449631170)) },
                    { "kriig", ("Kriig the Undead General", new PrefabGUID(-1365931036)) },
                    { "christina", ("Christina the Sun Priestess", new PrefabGUID(-99012450)) },
                    { "vincent", ("Vincent the Frostbringer", new PrefabGUID(-29797003)) },
                    { "bane", ("Bane the Shadowblade", new PrefabGUID(613251918)) },
                    { "grethel", ("Grethel the Glassblower", new PrefabGUID(910988233)) },
                    { "leandra", ("Leandra the Shadow Priestess", new PrefabGUID(939467639)) },
                    { "maja", ("Maja the Dark Savant", new PrefabGUID(1945956671)) },
                    { "terah", ("Terah the Geomancer", new PrefabGUID(-1065970933)) },
                    { "meredith", ("Meredith the Bright Archer", new PrefabGUID(850622034)) },
                    { "jade", ("Jade the Vampire Hunter", new PrefabGUID(-1968372384)) },
                    { "raziel", ("Raziel the Shepherd", new PrefabGUID(-680831417)) },
                    { "frostmaw", ("Frostmaw the Mountain Terror", new PrefabGUID(24378719)) },
                    { "octavian", ("Octavian the Militia Captain", new PrefabGUID(1688478381)) },
                    { "domina", ("Domina the Blade Dancer", new PrefabGUID(-1101874342)) },
                    { "angram", ("Angram the Purifier", new PrefabGUID(106480588)) },
                    { "ziva", ("Ziva the Engineer", new PrefabGUID(172235178)) },
                    { "ungora", ("Ungora the Spider Queen", new PrefabGUID(-548489519)) },
                    { "wanderer", ("The Old Wanderer", new PrefabGUID(109969450)) },
                    { "foulrot", ("Foulrot the Soultaker", new PrefabGUID(-1208888966)) },
                    { "willfred", ("Willfred the Werewolf Chief", new PrefabGUID(-1007062401)) },
                    { "balaton", ("The Duke of Balaton", new PrefabGUID(-203043163)) },
                    { "cyril", ("Cyril the Cursed Smith", new PrefabGUID(326378955)) },
                    { "magnus", ("Sir Magnus the Overseer", new PrefabGUID(-26105228)) },
                    { "mairwyn", ("Mairwyn the Elementalist", new PrefabGUID(-2013903325)) },
                    { "baron", ("Baron du Bouchon the Sommelier", new PrefabGUID(192051202)) },
                    { "morian", ("Morian the Stormwing Matriarch", new PrefabGUID(685266977)) },
                    { "terrorclaw", ("Terrorclaw the Ogre", new PrefabGUID(-1347412392)) },
                    { "azariel", ("Azariel the Sunbringer", new PrefabGUID(114912615)) },
                    { "henry", ("Henry Blackbrew the Doctor", new PrefabGUID(814083983)) },
                    { "matka", ("Matka the Curse Weaver", new PrefabGUID(-910296704)) },
                    { "voltatia", ("Voltatia the Power Master", new PrefabGUID(2054432370)) },
                    { "styx", ("Nightmarshal Styx the Sunderer", new PrefabGUID(1112948824)) },
                    { "solarus", ("Solarus the Immaculate", new PrefabGUID(-740796338)) }
                };

            return database_units;
        }


        public static Dictionary<string, PrefabGUID> GetBossPrefabs()
        {
            Dictionary<string, PrefabGUID> bossPrefabs = new Dictionary<string, PrefabGUID>();

            Dictionary<string, (string name, PrefabGUID)> unitDatabase = GetUnitDatabase();
            foreach (var unitData in unitDatabase)
            {
                bossPrefabs.Add(unitData.Value.name, unitData.Value.Item2);
            }

            return bossPrefabs;
        }


        public static string GetUnitName(string unitId)
        {
            Dictionary<string, (string name, PrefabGUID)> unitDatabase = GetUnitDatabase();

            foreach (var unitData in unitDatabase)
            {
                if (unitData.Value.Item2.ToString() == unitId)
                {
                    return unitData.Value.name;
                }
            }

            return null;
        }


        public static PrefabGUID GetUnitPrefabGUID(string unitId)
        {
            Dictionary<string, (string name, PrefabGUID)> unitDatabase = GetUnitDatabase();
            if (unitDatabase.ContainsKey(unitId))
            {
                return unitDatabase[unitId].Item2;
            }
            else
            {
                return default(PrefabGUID);
            }
        }
        
        public static Dictionary<string, List<Item>> GetSetDatabase()
        {
            Dictionary<string, List<Item>> item_sets = new Dictionary<string, List<Item>>();

            List<Item> t8 = new List<Item>
            {
                //Weapons
                new Item { Name = "Sanguine_Axes",  Prefab = -2044057823},
                new Item { Name = "Sanguine_Crossbow", Prefab = 1389040540},
                new Item { Name = "Sanguine_Mace",  Prefab = -126076280 },
                new Item { Name = "Sanguine_Reaper",  Prefab = -2053917766},
                new Item { Name = "Sanguine_Slashers",  Prefab = 1322545846 },
                new Item { Name = "Sanguine_Spear", Prefab = -850142339 },
                new Item { Name = "Sanguine_Sword",  Prefab = -774462329 },
                
                //Stuff
                new Item { Name = "Bloodmoon_Boots", Prefab = -556769032 },
                new Item { Name = "Bloodmoon_Chestguard", Prefab = 488592933 },
                new Item { Name = "Bloodmoon_Leggings", Prefab = 1292986377 },
                new Item { Name = "Bloodmoon_Gloves", Prefab = 1634690081},
                
                //Jewels
                new Item { Name = "Amulet_Of_The_Arch-Warlock", Prefab = 1380368392 },
                new Item { Name = "Amulet_Of_The_Crimson_Commander", Prefab = -104934480 },
                new Item { Name = "Amulet_Of_The_Unyielding_Charger", Prefab = -1004351840 },
                new Item { Name = "Amulet_Of_The_Blademaster", Prefab = -296161379 },
                new Item { Name = "Amulet_Of_The_Master_Spellweaver", Prefab = -1306155896 },
                new Item { Name = "Amulet_Of_The_Wicked_Prophet", Prefab = -175650376 },
            };
            
            List<Item> t7 = new List<Item>
            {
                //Weapons
                new Item { Name = "Dark_Silver_Axes", Prefab = -1130238142 },
                new Item { Name = "Dark_Silver_Crossbow", Prefab = -814739263 },
                new Item { Name = "Dark_Silver_Mace", Prefab = -184713893 },
                new Item { Name = "Dark_Silver_Reaper", Prefab = 6711686},
                new Item { Name = "Dark_Silver_Slashers", Prefab = 633666898 },
                new Item { Name = "Dark_Silver_Spear", Prefab = -352704566 },
                new Item { Name = "Dark_Silver_Sword", Prefab = -1455388114 },
                
                //Stuff
                new Item { Name = "Dawnthorn_Boots", Prefab = 560446510 },
                new Item { Name = "Dawnthorn_Gloves", Prefab = 2055058719 },
                new Item { Name = "Dawnthorn_Chestguard", Prefab = -930514044},
                new Item { Name = "Dawnthorn_Leggings", Prefab = -1555051415 },
                
                //Jewels
                new Item { Name = "Bloody_Merlot_Amulet", Prefab = 991396285 },
            };
            
            List<Item> t6 = new List<Item>
            {
                //Weapons
                new Item { Name = "Merciless_Iron_Axes", Prefab = 198951695 },
                new Item { Name = "Merciless_Iron_Crossbow", Prefab = 1221976097 },
                new Item { Name = "Merciless_Iron_Mace", Prefab = -276593802 },
                new Item { Name = "Merciless_Iron_Reaper", Prefab = 1778128946},
                new Item { Name = "Merciless_Iron_Slashers", Prefab = 866934844 },
                new Item { Name = "Merciless_Iron_Spear", Prefab = 1065194820 },
                new Item { Name = "Merciless_Iron_Sword", Prefab = -435501075 },
                
                //Stuff
                new Item { Name = "Merciless_Hollowfang_Boots", Prefab = -674860200 },
                new Item { Name = "Merciless_Hollowfang_Gloves", Prefab = 82446940 },
                new Item { Name = "Merciless_Hollowfang_Leggings", Prefab = -916555565 },
                new Item { Name = "Merciless_Hollowfang_Chestguard", Prefab = 1388572480 },
                
                //Jewels
                new Item { Name = "Pendant_Of_The_Dawnrunner", Prefab = -1046748791 },
                new Item { Name = "Pendant_Of_The_Duskwatcher", Prefab = 610958202 },
                new Item { Name = "Pendant_Of_The_knigth", Prefab = -425306671 },
                new Item { Name = "Pendant_Of_The_Sorcerer", Prefab = 199425997 },
                new Item { Name = "Pendant_Of_The_Spellweaver", Prefab = 1012837641 },
                new Item { Name = "Pendant_Of_The_Warlock", Prefab = -651554566 },
            };
            
            List<Item> t5 = new List<Item>
            {
                //Weapons
                new Item { Name = "Iron_Axes", Prefab = -1579575933 },
                new Item { Name = "Iron_Crossbow", Prefab = 836066667 },
                new Item { Name = "Iron_Mace", Prefab = -1714012261 },
                new Item { Name = "Iron_Reaper", Prefab = -2081286944},
                new Item { Name = "Iron_Slashers", Prefab = -314614708 },
                new Item { Name = "Iron_Spear", Prefab = 1853029976 },
                new Item { Name = "Iron_Sword", Prefab = -903587404 },
                
                //Stuff
                new Item { Name = "Hollowfang_Boots", Prefab = -1837769884 },
                new Item { Name = "Hollowfang_Gloves", Prefab = -406808302 },
                new Item { Name = "Hollowfang_Leggings", Prefab = 12127911 },
                new Item { Name = "Hollowfang_Chestguard", Prefab = -604941435 },
                
                //Jewels
                new Item { Name = "Scourgestone_Pendant", Prefab = -650855520 },
            };
            
            List<Item> t4 = new List<Item>
            {
                //Weapons
                new Item { Name = "Merciless_Copper_Axes", Prefab = -491969324 },
                new Item { Name = "Merciless_Copper_Crossbow", Prefab = -1636801169 },
                new Item { Name = "Merciless_Copper_Mace", Prefab = 343324920 },
                new Item { Name = "Merciless_Copper_Slashers", Prefab = -1042299347 },
                new Item { Name = "Merciless_Copper_Spear", Prefab = 790210443 },
                new Item { Name = "Merciless_Copper_Sword", Prefab = -1219959051 },
                
                //Stuff
                new Item { Name = "Merciless_Nightstalker_Boots", Prefab = -1675225643 },
                new Item { Name = "Merciless_Nightstalker_Gloves", Prefab = -1739590652 },
                new Item { Name = "Merciless_Nightstalker_Leggings", Prefab = -1771720396 },
                new Item { Name = "Merciless_Nightstalker_Chestguard", Prefab = 1721366777 },
                
                //Jewels
                new Item { Name = "Ring_Of_The_Dawnrunner", Prefab = -154264228 },
                new Item { Name = "Ring_Of_The_Duskwatcher", Prefab = -809059551 },
                new Item { Name = "Ring_Of_The_Spellweaver", Prefab = -886916793 },
                new Item { Name = "Ring_Of_The_Warlock", Prefab = 336922685 },
            };
            
            List<Item> t3 = new List<Item>
            {
                //Weapons
                new Item { Name = "Copper_Axes", Prefab = 518802008 },
                new Item { Name = "Copper_Crossbow", Prefab = -1277074895 },
                new Item { Name = "Copper_Mace", Prefab = -331345186 },
                new Item { Name = "Copper_Spear", Prefab = 1370755976 },
                new Item { Name = "Copper_Sword", Prefab = -2037272000 },
                
                //Stuff
                new Item { Name = "Nightstalker_Boots", Prefab = -1354920908 },
                new Item { Name = "Nightstalker_Gloves", Prefab = -1183157751 },
                new Item { Name = "Nightstalker_Leggings", Prefab = 1925394440 },
                new Item { Name = "Nightstalker_Chestguard", Prefab = -957963240 },
                
                //Jewels
                new Item { Name = "Gravedigger_Ring", Prefab = -1588051702 },
            };
            
            item_sets.Add("t8", t8);
            item_sets.Add("t7", t7);
            item_sets.Add("t6", t6);
            item_sets.Add("t5", t5);
            item_sets.Add("t4", t4);
            item_sets.Add("t3", t3);

            return item_sets;
        }

    }
}