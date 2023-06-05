using ProjectM;
using System.Collections.Generic;
using Unity.Mathematics;

namespace CommunityCommands.Commons
{
    public class Database
    {
        public static List<Blood> BloodTypes { get; } = new List<Blood>
        {
            new Blood { name = "Frailed", prefab = new PrefabGUID(-899826404) },
            new Blood { name = "Creature", prefab = new PrefabGUID(-77658840) },
            new Blood { name = "Warrior", prefab = new PrefabGUID(-1094467405) },
            new Blood { name = "Rogue", prefab = new PrefabGUID(793735874) },
            new Blood { name = "Brute", prefab = new PrefabGUID(581377887) },
            new Blood { name = "Scholar", prefab = new PrefabGUID(-586506765) },
            new Blood { name = "Mutant", prefab = new PrefabGUID(-2017994753) },
            new Blood { name = "Worker", prefab = new PrefabGUID(-540707191) }
        };


        public static Dictionary<string, VBlood> BossDatabase { get; } = new Dictionary<string, VBlood>()
        {
            {
                "wolf", new VBlood
                {
                    DisplayName = "Alpha Wolf",
                    Prefab = new PrefabGUID(-1905691330),
                    Position = new Position
                    {
                        position = float3.zero,
                        text =
                            "I cannot teleport you to the <color=#ff00ff>Alpha Wolf</color> as VBlood moves around <color=#00ffff>Farbane Woods</color>, so you will have to track him yourself."
                    }
                }
            },
            {
                "errol", new VBlood
                {
                    DisplayName = "Errol the Stonebreaker",
                    Prefab = new PrefabGUID(-2025101517),
                    Position = new Position { position = new float3(-1554f, 10f, 1478f), text = "None" }
                }
            },
            {
                "keely", new VBlood
                {
                    DisplayName = "Keely the Frost Archer",
                    Prefab = new PrefabGUID(1124739990),
                    Position = new Position { position = new float3(-1029f, 0f, -1358f), text = "None" }
                }
            },
            {
                "rufus", new VBlood
                {
                    DisplayName = "Rufus the Foreman",
                    Prefab = new PrefabGUID(2122229952),
                    Position = new Position { position = new float3(-1218f, 0f, -1549f), text = "None" }
                }
            },
            {
                "goreswine", new VBlood
                {
                    DisplayName = "Goreswine the Ravager",
                    Prefab = new PrefabGUID(577478542),
                    Position = new Position
                    {
                        position = float3.zero,
                        text =
                            "I cannot teleport you to <color=#ff00ff>Goreswine the Ravager</color> as VBlood moves from <color=#00ffff>The Desecrated Graveyard</color> to <color=#00ffff>The Infested Graveyard</color>."
                    }
                }
            },
            {
                "grayson", new VBlood
                {
                    DisplayName = "Grayson the Armourer",
                    Prefab = new PrefabGUID(1106149033),
                    Position = new Position { position = new float3(-1692f, 5f, 1400f), text = "None" }
                }
            },
            {
                "rat", new VBlood
                {
                    DisplayName = "Putrid Rat",
                    Prefab = new PrefabGUID(-2039908510),
                    Position = new Position { position = float3.zero, text = "Summon" }
                }
            },
            {
                "lidia", new VBlood
                {
                    DisplayName = "Lidia the Chaos Archer",
                    Prefab = new PrefabGUID(763273073),
                    Position = new Position
                    {
                        position = float3.zero,
                        text =
                            "I'm sorry, but I cannot teleport you to <color=#ff00ff>Lidia the Chaos Archer</color> as VBlood moves around <color=#00ffff>Farbane Woods</color>."
                    }
                }
            },
            {
                "clive", new VBlood
                {
                    DisplayName = "Clive the Firestarter",
                    Prefab = new PrefabGUID(1896428751),
                    Position = new Position { position = new float3(-2133f, 5f, -1528f), text = "None" }
                }
            },
            {
                "bear", new VBlood
                {
                    DisplayName = "Ferocious Bear",
                    Prefab = new PrefabGUID(-1391546313),
                    Position = new Position { position = new float3(-702f, 0f, -1521f), text = "None" }
                }
            },
            {
                "polora", new VBlood
                {
                    DisplayName = "Polora the Feywalker",
                    Prefab = new PrefabGUID(-484556888),
                    Position = new Position { position = new float3(-2018f, 0f, -1218f), text = "None" }
                }
            },
            {
                "nicholaus", new VBlood
                {
                    DisplayName = "Nicholaus the Fallen",
                    Prefab = new PrefabGUID(153390636),
                    Position = new Position { position = new float3(-1357f, 15f, 1332f), text = "None" }
                }
            },
            {
                "quincey", new VBlood
                {
                    DisplayName = "Quincey the Bandit King",
                    Prefab = new PrefabGUID(-1659822956),
                    Position = new Position { position = new float3(-1392f, 20f, -1211f), text = "None" }
                }
            },
            {
                "beatrice", new VBlood
                {
                    DisplayName = "Beatrice the Tailor",
                    Prefab = new PrefabGUID(-1942352521),
                    Position = new Position
                    {
                        position = new float3(-1045f, 0f, -880f),
                        text =
                            " <color=#ff00ff>Beatrice the Tailor</color> remains within <color=#00ffff>Dawnbreak Village</color> and does not roam beyond its boundaries"
                    }
                }
            },
            {
                "tristan", new VBlood
                {
                    DisplayName = "Tristan the Vampire Hunter",
                    Prefab = new PrefabGUID(-1449631170),
                    Position = new Position
                    {
                        position = float3.zero,
                        text =
                            "I'm sorry, but I cannot teleport you directly to <color=#ff00ff>Tristan the Vampire Hunter</color>. He is known to patrol both <color=#00ffff>Farbane Woods</color> and <color=#00ffff>Dunley Farmlands</color>."
                    }
                }
            },
            {
                "kriig", new VBlood
                {
                    DisplayName = "Kriig the Undead General",
                    Prefab = new PrefabGUID(-1365931036),
                    Position = new Position
                    {
                        position = new float3(-1368f, 0f, -1048f),
                        text =
                            " <color=#ff00ff>Kriig the Undead General</color> can be found roaming inside <color=#00ffff>The Haunted Iron Mine</color>."
                    }
                }
            },
            {
                "christina", new VBlood
                {
                    DisplayName = "Christina the Sun Priestess",
                    Prefab = new PrefabGUID(-99012450),
                    Position = new Position
                    {
                        position = float3.zero,
                        text =
                            "I'm sorry, but I cannot teleport you directly to <color=#ff00ff>Christina the Sun Priestess</color>. She is known to roam between <color=#00ffff>Mossick Village</color> and <color=#00ffff>Dawnbreak Village</color>."
                    }
                }
            },
            {
                "vincent", new VBlood
                {
                    DisplayName = "Vincent the Frostbringer",
                    Prefab = new PrefabGUID(-29797003),
                    Position = new Position
                    {
                        position = new float3(-1339f, 0f, -824f),
                        text =
                            " <color=#ff00ff>Vincent the Frostbringer</color> can often be found patrolling the streets of <color=#00ffff>Dunley Farmlands</color>."
                    }
                }
            },
            {
                "bane", new VBlood
                {
                    DisplayName = "Bane the Shadowblade",
                    Prefab = new PrefabGUID(613251918),
                    Position = new Position
                    {
                        position = float3.zero,
                        text =
                            "I'm sorry, but I cannot teleport you directly to <color=#ff00ff>Bane the Shadowblade</color>. This VBlood has a tendency to wander throughout <color=#00ffff>Dunley Farmlands</color>."
                    }
                }
            },
            {
                "grethel", new VBlood
                {
                    DisplayName = "Grethel the Glassblower",
                    Prefab = new PrefabGUID(910988233),
                    Position = new Position { position = new float3(-1727f, 1f, -370f), text = "None" }
                }
            },
            {
                "leandra", new VBlood
                {
                    DisplayName = "Leandra the Shadow Priestess",
                    Prefab = new PrefabGUID(939467639),
                    Position = new Position { position = new float3(-1182f, 15f, -376f), text = "None" }
                }
            },
            {
                "maja", new VBlood
                {
                    DisplayName = "Maja the Dark Savant",
                    Prefab = new PrefabGUID(1945956671),
                    Position = new Position { position = new float3(-867f, 15f, 510f), text = "None" }
                }
            },
            {
                "terah", new VBlood
                {
                    DisplayName = "Terah the Geomancer",
                    Prefab = new PrefabGUID(-1065970933),
                    Position = new Position { position = new float3(-1660f, 8f, -543f), text = "None" }
                }
            },
            {
                "meredith", new VBlood
                {
                    DisplayName = "Meredith the Bright Archer",
                    Prefab = new PrefabGUID(850622034),
                    Position = new Position
                    {
                        position = new float3(-1395f, 0f, -904f),
                        text =
                            " <color=#ff00ff>Meredith the Bright Archer</color> can be found roaming inside <color=#00ffff>The Haunted Iron Mine</color>."
                    }
                }
            },
            {
                "jade", new VBlood
                {
                    DisplayName = "Jade the Vampire Hunter",
                    Prefab = new PrefabGUID(-1968372384),
                    Position = new Position
                    {
                        position = float3.zero,
                        text =
                            "I'm sorry, but I cannot teleport you directly to <color=#ff00ff>Jade the Vampire Hunter</color>. This VBlood is known to roam around <color=#00ffff>Dunley Farmlands</color>."
                    }
                }
            },
            {
                "raziel", new VBlood
                {
                    DisplayName = "Raziel the Shepherd",
                    Prefab = new PrefabGUID(-680831417),
                    Position = new Position { position = new float3(-166f, 5f, -697f), text = "None" }
                }
            },
            {
                "frostmaw", new VBlood
                {
                    DisplayName = "Frostmaw the Mountain Terror",
                    Prefab = new PrefabGUID(24378719),
                    Position = new Position
                    {
                        position = float3.zero,
                        text =
                            "I'm afraid I can't teleport you directly to <color=#ff00ff>Frostmaw the Mountain Terror</color>. This VBlood creature roams the treacherous terrain of <color=#00ffff>The Hallowed Mountains</color>."
                    }
                }
            },
            {
                "octavian", new VBlood
                {
                    DisplayName = "Octavian the Militia Captain",
                    Prefab = new PrefabGUID(1688478381),
                    Position = new Position { position = new float3(-1215f, 5f, -523f), text = "None" }
                }
            },
            {
                "domina", new VBlood
                {
                    DisplayName = "Domina the Blade Dancer",
                    Prefab = new PrefabGUID(-1101874342),
                    Position = new Position { position = new float3(-1706f, 0f, -153f), text = "None" }
                }
            },
            {
                "angram", new VBlood
                {
                    DisplayName = "Angram the Purifier",
                    Prefab = new PrefabGUID(106480588),
                    Position = new Position
                    {
                        position = new float3(-1707f, 0f, -70f),
                        text =
                            " <color=#ff00ff>Angram the Purifier</color> freely roams inside <color=#00ffff>The Pools of Rebirth</color>."
                    }
                }
            },
            {
                "ziva", new VBlood
                {
                    DisplayName = "Ziva the Engineer",
                    Prefab = new PrefabGUID(172235178),
                    Position = new Position { position = new float3(-1344f, 9f, 108f), text = "None" }
                }
            },
            {
                "ungora", new VBlood
                {
                    DisplayName = "Ungora the Spider Queen",
                    Prefab = new PrefabGUID(-548489519),
                    Position = new Position { position = new float3(-1074f, 5f, 52f), text = "None" }
                }
            },
            {
                "wanderer", new VBlood
                {
                    DisplayName = "The Old Wanderer",
                    Prefab = new PrefabGUID(109969450),
                    Position = new Position { position = new float3(-1250f, 0f, -105f), text = "None" }
                }
            },
            {
                "foulrot", new VBlood
                {
                    DisplayName = "Foulrot the Soultaker",
                    Prefab = new PrefabGUID(-1208888966),
                    Position = new Position { position = new float3(-604f, 0f, -67f), text = "None" }
                }
            },
            {
                "willfred", new VBlood
                {
                    DisplayName = "Willfred the Werewolf Chief",
                    Prefab = new PrefabGUID(-1007062401),
                    Position = new Position { position = new float3(-1041f, 10f, -254f), text = "None" }
                }
            },
            {
                "balaton", new VBlood
                {
                    DisplayName = "The Duke of Balaton",
                    Prefab = new PrefabGUID(-203043163),
                    Position = new Position { position = new float3(-925f, 0f, 246f), text = "None" }
                }
            },
            {
                "cyril", new VBlood
                {
                    DisplayName = "Cyril the Cursed Smith",
                    Prefab = new PrefabGUID(326378955),
                    Position = new Position { position = new float3(-753f, 0f, 96f), text = "None" }
                }
            },
            {
                "magnus", new VBlood
                {
                    DisplayName = "Sir Magnus the Overseer",
                    Prefab = new PrefabGUID(-26105228),
                    Position = new Position { position = new float3(-2326f, 10f, -582f), text = "None" }
                }
            },
            {
                "mairwyn", new VBlood
                {
                    DisplayName = "Mairwyn the Elementalist",
                    Prefab = new PrefabGUID(-2013903325),
                    Position = new Position { position = new float3(-2007f, 15f, -897f), text = "None" }
                }
            },
            {
                "baron", new VBlood
                {
                    DisplayName = "Baron du Bouchon the Sommelier",
                    Prefab = new PrefabGUID(192051202),
                    Position = new Position { position = new float3(-2208f, -4f, -774f), text = "None" }
                }
            },
            {
                "morian", new VBlood
                {
                    DisplayName = "Morian the Stormwing Matriarch",
                    Prefab = new PrefabGUID(685266977),
                    Position = new Position { position = new float3(-2174f, 15f, -911f), text = "None" }
                }
            },
            {
                "terrorclaw", new VBlood
                {
                    DisplayName = "Terrorclaw the Ogre",
                    Prefab = new PrefabGUID(-1347412392),
                    Position = new Position { position = new float3(-563f, 15f, 1212f), text = "None" }
                }
            },
            {
                "azariel", new VBlood
                {
                    DisplayName = "Azariel the Sunbringer",
                    Prefab = new PrefabGUID(114912615),
                    Position = new Position { position = new float3(-2490f, 10f, -710f), text = "None" }
                }
            },
            {
                "henry", new VBlood
                {
                    DisplayName = "Henry Blackbrew the Doctor",
                    Prefab = new PrefabGUID(814083983),
                    Position = new Position { position = new float3(-1795f, 18f, 40f), text = "None" }
                }
            },
            {
                "matka", new VBlood
                {
                    DisplayName = "Matka the Curse Weaver",
                    Prefab = new PrefabGUID(-910296704),
                    Position = new Position { position = new float3(-685f, 0f, 86f), text = "None" }
                }
            },
            {
                "voltatia", new VBlood
                {
                    DisplayName = "Voltatia the Power Master",
                    Prefab = new PrefabGUID(2054432370),
                    Position = new Position { position = new float3(-1502f, 20f, 264f), text = "None" }
                }
            },
            {
                "styx", new VBlood
                {
                    DisplayName = "Nightmarshal Styx the Sunderer",
                    Prefab = new PrefabGUID(1112948824),
                    Position = new Position
                    {
                        position = float3.zero,
                        text =
                            "I'm sorry, but I cannot teleport you directly to <color=#ff00ff>Nightmarshal Styx the Sunderer</color>. This VBlood entity roams within the depths of <color=#00ffff>The Cursed Forest</color>."
                    }
                }
            },
            {
                "solarus", new VBlood
                {
                    DisplayName = "Solarus the Immaculate",
                    Prefab = new PrefabGUID(-740796338),
                    Position = new Position { position = new float3(-1980f, 25f, -717f), text = "None" }
                }
            },
            {
                "behemot", new VBlood
                {
                    DisplayName = "Gorecrusher the Behemoth",
                    Prefab = new PrefabGUID(-1936575244),
                    Position = new Position { position = new float3(692f, 10f, -87f), text = "None" }
                }
            },
            {
                "horror", new VBlood
                {
                    DisplayName = "The Winged Horror",
                    Prefab = new PrefabGUID(-393555055),
                    Position = new Position { position = new float3(-690f, 20f, -1330f), text = "None" }
                }
            },
            {
                "adam", new VBlood
                {
                    DisplayName = "Adam The Firstborn",
                    Prefab = new PrefabGUID(1233988687),
                    Position = new Position { position = new float3(-1854f, 20f, -346f), text = "None" }
                }
            },
        };

        public static Dictionary<string, List<Item>> ItemSets { get; } = new Dictionary<string, List<Item>>()
        {
            {
                "tx", new List<Item>
                {
                    //Weapons
                    new Item { Name = "ShadowMatter_NecromancyDagger", Prefab = -526440176 },
                    new Item { Name = "ShadowMatter_Longbow", Prefab = 1283345494 },
                }
            },
            {
                "leg", new List<Item>
                {
                    //Weapons
                    new Item { Name = "Legendary_GreatSword", Prefab = -1173681254 },
                    new Item { Name = "Legendary_Mace", Prefab = 1994084762 },
                    new Item { Name = "Legendary_Pistols", Prefab = -944318126 },
                    new Item { Name = "Legendary_Reaper", Prefab = -105026635 },
                    new Item { Name = "Legendary_Slashers", Prefab = 821410795 },
                    new Item { Name = "Legendary_Spear", Prefab = -1931117134 },
                    new Item { Name = "Legendary_Sword", Prefab = 195858450 },
                    new Item { Name = "Legendary_Crossbow", Prefab = 935392085 },
                    new Item { Name = "Legendary_Axes", Prefab = -102830349 },
                }
            },
            {
                "t9", new List<Item>
                {
                    //Weapons
                    new Item { Name = "ShadowMatter_Axes", Prefab = 2100090213 },
                    new Item { Name = "ShadowMatter_Crossbow", Prefab = 1957540013 },
                    new Item { Name = "ShadowMatter_Mace", Prefab = 160471982 },
                    new Item { Name = "ShadowMatter_Reaper", Prefab = -465491217 },
                    new Item { Name = "ShadowMatter_Slashers", Prefab = 506082542 },
                    new Item { Name = "ShadowMatter_Spear", Prefab = 1307774440 },
                    new Item { Name = "ShadowMatter_Sword", Prefab = -1215982687 },
                    new Item { Name = "ShadowMatter_Pistols", Prefab = -1265586439 },
                    new Item { Name = "ShadowMatter_GreatSword", Prefab = 1322254792 },
                    new Item { Name = "ShadowMatter_Longbow", Prefab = 1283345494 },
                    new Item { Name = "ShadowMatter_Necromancy_Dagger", Prefab = -526440176 },

                    //Stuff
                    new Item { Name = "DarkMatter_Boots", Prefab = 1400688919 },
                    new Item { Name = "DarkMatter_Chest", Prefab = 1055898174 },
                    new Item { Name = "DarkMatter_Gloves", Prefab = -204401621 },
                    new Item { Name = "DarkMatter_Leggings", Prefab = 125611165 },
                }
            },
            {
                "t8", new List<Item>
                {
                    //Weapons
                    new Item { Name = "Sanguine_Axes", Prefab = -2044057823 },
                    new Item { Name = "Sanguine_Crossbow", Prefab = 1389040540 },
                    new Item { Name = "Sanguine_Mace", Prefab = -126076280 },
                    new Item { Name = "Sanguine_Reaper", Prefab = -2053917766 },
                    new Item { Name = "Sanguine_Slashers", Prefab = 1322545846 },
                    new Item { Name = "Sanguine_Spear", Prefab = -850142339 },
                    new Item { Name = "Sanguine_Sword", Prefab = -774462329 },
                    new Item { Name = "Sanguine_GreatSword", Prefab = 147836723 },

                    //Stuff
                    new Item { Name = "Bloodmoon_Boots", Prefab = -556769032 },
                    new Item { Name = "Bloodmoon_Chestguard", Prefab = 488592933 },
                    new Item { Name = "Bloodmoon_Leggings", Prefab = 1292986377 },
                    new Item { Name = "Bloodmoon_Gloves", Prefab = 1634690081 },

                    //Jewels
                    new Item { Name = "Amulet_Of_The_Arch-Warlock", Prefab = 1380368392 },
                    new Item { Name = "Amulet_Of_The_Crimson_Commander", Prefab = -104934480 },
                    new Item { Name = "Amulet_Of_The_Unyielding_Charger", Prefab = -1004351840 },
                    new Item { Name = "Amulet_Of_The_Blademaster", Prefab = -296161379 },
                    new Item { Name = "Amulet_Of_The_Master_Spellweaver", Prefab = -1306155896 },
                    new Item { Name = "Amulet_Of_The_Wicked_Prophet", Prefab = -175650376 },
                }
            },
            {
                "t7", new List<Item>
                {
                    //Weapons
                    new Item { Name = "Dark_Silver_Axes", Prefab = -1130238142 },
                    new Item { Name = "Dark_Silver_Crossbow", Prefab = -814739263 },
                    new Item { Name = "Dark_Silver_Mace", Prefab = -184713893 },
                    new Item { Name = "Dark_Silver_Reaper", Prefab = 6711686 },
                    new Item { Name = "Dark_Silver_Slashers", Prefab = 633666898 },
                    new Item { Name = "Dark_Silver_Spear", Prefab = -352704566 },
                    new Item { Name = "Dark_Silver_Sword", Prefab = -1455388114 },
                    new Item { Name = "Dark_Silver_GreatSword", Prefab = 674704033 },

                    //Stuff
                    new Item { Name = "Dawnthorn_Boots", Prefab = 560446510 },
                    new Item { Name = "Dawnthorn_Gloves", Prefab = 2055058719 },
                    new Item { Name = "Dawnthorn_Chestguard", Prefab = -930514044 },
                    new Item { Name = "Dawnthorn_Leggings", Prefab = -1555051415 },

                    //Jewels
                    new Item { Name = "Bloody_Merlot_Amulet", Prefab = 991396285 },
                }
            },

            {
                "t6", new List<Item>
                {
                    //Weapons
                    new Item { Name = "Merciless_Iron_Axes", Prefab = 198951695 },
                    new Item { Name = "Merciless_Iron_Crossbow", Prefab = 1221976097 },
                    new Item { Name = "Merciless_Iron_Mace", Prefab = -276593802 },
                    new Item { Name = "Merciless_Iron_Reaper", Prefab = 1778128946 },
                    new Item { Name = "Merciless_Iron_Slashers", Prefab = 866934844 },
                    new Item { Name = "Merciless_Iron_Spear", Prefab = 1065194820 },
                    new Item { Name = "Merciless_Iron_Sword", Prefab = -435501075 },
                    new Item { Name = "Merciless_GreatSword", Prefab = 82781195 },

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
                }
            },


            {
                "t5", new List<Item>
                {
                    //Weapons
                    new Item { Name = "Iron_Axes", Prefab = -1579575933 },
                    new Item { Name = "Iron_Crossbow", Prefab = 836066667 },
                    new Item { Name = "Iron_Mace", Prefab = -1714012261 },
                    new Item { Name = "Iron_Reaper", Prefab = -2081286944 },
                    new Item { Name = "Iron_Slashers", Prefab = -314614708 },
                    new Item { Name = "Iron_Spear", Prefab = 1853029976 },
                    new Item { Name = "Iron_Sword", Prefab = -903587404 },
                    new Item { Name = "Iron_GreatSword", Prefab = -768054337 },

                    //Stuff
                    new Item { Name = "Hollowfang_Boots", Prefab = -1837769884 },
                    new Item { Name = "Hollowfang_Gloves", Prefab = -406808302 },
                    new Item { Name = "Hollowfang_Leggings", Prefab = 12127911 },
                    new Item { Name = "Hollowfang_Chestguard", Prefab = -604941435 },

                    //Jewels
                    new Item { Name = "Scourgestone_Pendant", Prefab = -650855520 },
                }
            },


            {
                "t4", new List<Item>
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
                }
            },

            {
                "t3", new List<Item>
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
                }
            },
        };

        public static Dictionary<string, List<Jewel>> JewelDictionary { get; } = new Dictionary<string, List<Jewel>>
        {
            {
                "blood", new List<Jewel>
                {
                    new Jewel { Name = "T01", Tier = "T01", PrefabGuid = new PrefabGUID(-113436752) },
                    new Jewel { Name = "T02", Tier = "T02", PrefabGuid = new PrefabGUID(-996555621) },
                    new Jewel { Name = "Blood_Fountain", Tier = "T02", PrefabGuid = new PrefabGUID(-1624411159) },
                    new Jewel { Name = "Blood_Rage", Tier = "T02", PrefabGuid = new PrefabGUID(343217159) },
                    new Jewel { Name = "Blood_Rite", Tier = "T02", PrefabGuid = new PrefabGUID(-2059886133) },
                    new Jewel { Name = "Sanguine_Coil", Tier = "T02", PrefabGuid = new PrefabGUID(75934448) },
                    new Jewel { Name = "Shadowbolt", Tier = "T02", PrefabGuid = new PrefabGUID(918613164) },
                    new Jewel { Name = "Veil_Of_Blood", Tier = "T02", PrefabGuid = new PrefabGUID(-431964258) },
                    new Jewel { Name = "T03", Tier = "T03", PrefabGuid = new PrefabGUID(-41686151) },
                    new Jewel { Name = "Blood_Fountain", Tier = "T03", PrefabGuid = new PrefabGUID(-312598876) },
                    new Jewel { Name = "Blood_Rage", Tier = "T03", PrefabGuid = new PrefabGUID(-1952560879) },
                    new Jewel { Name = "Blood_Rite", Tier = "T03", PrefabGuid = new PrefabGUID(1881059081) },
                    new Jewel { Name = "Sanguine_Coil", Tier = "T03", PrefabGuid = new PrefabGUID(1785926321) },
                    new Jewel { Name = "Shadowbolt", Tier = "T03", PrefabGuid = new PrefabGUID(738473666) },
                    new Jewel { Name = "Veil_Of_Blood", Tier = "T03", PrefabGuid = new PrefabGUID(-1302801575) },
                    new Jewel { Name = "T04", Tier = "T04", PrefabGuid = new PrefabGUID(271061481) }
                }
            },
            {
                "chaos", new List<Jewel>
                {
                    new Jewel { Name = "T01", Tier = "T01", PrefabGuid = new PrefabGUID(2130810069) },
                    new Jewel { Name = "T02", Tier = "T02", PrefabGuid = new PrefabGUID(1083105737) },
                    new Jewel { Name = "Aftershock", Tier = "T02", PrefabGuid = new PrefabGUID(1035334240) },
                    new Jewel { Name = "Chaos_Barrier", Tier = "T02", PrefabGuid = new PrefabGUID(1112619884) },
                    new Jewel { Name = "Chaos_Volley", Tier = "T02", PrefabGuid = new PrefabGUID(1243967840) },
                    new Jewel { Name = "Power_Surge", Tier = "T02", PrefabGuid = new PrefabGUID(1168555540) },
                    new Jewel { Name = "Veil_Of_Chaos", Tier = "T02", PrefabGuid = new PrefabGUID(-2133879652) },
                    new Jewel { Name = "Void", Tier = "T02", PrefabGuid = new PrefabGUID(157004582) },
                    new Jewel { Name = "T03", Tier = "T03", PrefabGuid = new PrefabGUID(-1601295908) },
                    new Jewel { Name = "Aftershock", Tier = "T03", PrefabGuid = new PrefabGUID(685024499) },
                    new Jewel { Name = "Chaos_Barrier", Tier = "T03", PrefabGuid = new PrefabGUID(-209873380) },
                    new Jewel { Name = "Chaos_Volley", Tier = "T03", PrefabGuid = new PrefabGUID(-1111771702) },
                    new Jewel { Name = "Power_Surge", Tier = "T03", PrefabGuid = new PrefabGUID(-1090887222) },
                    new Jewel { Name = "Veil_Of_Chaos", Tier = "T03", PrefabGuid = new PrefabGUID(1613948207) },
                    new Jewel { Name = "Void", Tier = "T03", PrefabGuid = new PrefabGUID(-2054797612) },
                    new Jewel { Name = "T04", Tier = "T04", PrefabGuid = new PrefabGUID(-1796954295) }
                }
            },
            {
                "frost", new List<Jewel>
                {
                    new Jewel { Name = "T01", Tier = "T01", PrefabGuid = new PrefabGUID(1908312304) },
                    new Jewel { Name = "T02", Tier = "T02", PrefabGuid = new PrefabGUID(1030854657) },
                    new Jewel { Name = "Crystal_Lance", Tier = "T02", PrefabGuid = new PrefabGUID(-390381611) },
                    new Jewel { Name = "Frost_Barrier", Tier = "T02", PrefabGuid = new PrefabGUID(2134082866) },
                    new Jewel { Name = "Frost_Bat", Tier = "T02", PrefabGuid = new PrefabGUID(-309124704) },
                    new Jewel { Name = "Ice_Block", Tier = "T02", PrefabGuid = new PrefabGUID(724975767) },
                    new Jewel { Name = "Ice_Nova", Tier = "T02", PrefabGuid = new PrefabGUID(-535477182) },
                    new Jewel { Name = "Veil_Of_Frost", Tier = "T02", PrefabGuid = new PrefabGUID(-710738056) },
                    new Jewel { Name = "T03", Tier = "T03", PrefabGuid = new PrefabGUID(223899244) },
                    new Jewel { Name = "Crystal_Lance", Tier = "T03", PrefabGuid = new PrefabGUID(594180030) },
                    new Jewel { Name = "Frost_Barrier", Tier = "T03", PrefabGuid = new PrefabGUID(1381699867) },
                    new Jewel { Name = "Frost_Bat", Tier = "T03", PrefabGuid = new PrefabGUID(-1530254765) },
                    new Jewel { Name = "Ice_Block", Tier = "T03", PrefabGuid = new PrefabGUID(-889584357) },
                    new Jewel { Name = "Ice_Nova", Tier = "T03", PrefabGuid = new PrefabGUID(1123463900) },
                    new Jewel { Name = "Veil_Of_Frost", Tier = "T03", PrefabGuid = new PrefabGUID(-1190496962) },
                    new Jewel { Name = "T04", Tier = "T04", PrefabGuid = new PrefabGUID(-147757377) }
                }
            },
            {
                "illusion", new List<Jewel>
                {
                    new Jewel { Name = "T01", Tier = "T01", PrefabGuid = new PrefabGUID(1387124262) },
                    new Jewel { Name = "T02", Tier = "T02", PrefabGuid = new PrefabGUID(437696083) },
                    new Jewel { Name = "Mist_Trance", Tier = "T02", PrefabGuid = new PrefabGUID(101601247) },
                    new Jewel { Name = "Mosquito", Tier = "T02", PrefabGuid = new PrefabGUID(-928330249) },
                    new Jewel { Name = "Phantom_Aegis", Tier = "T02", PrefabGuid = new PrefabGUID(1123282909) },
                    new Jewel { Name = "Spectral_Wolf", Tier = "T02", PrefabGuid = new PrefabGUID(1520619383) },
                    new Jewel { Name = "Veil_Of_Illusion", Tier = "T02", PrefabGuid = new PrefabGUID(606339127) },
                    new Jewel { Name = "Wraith_Spear", Tier = "T02", PrefabGuid = new PrefabGUID(665418354) },
                    new Jewel { Name = "T03", Tier = "T03", PrefabGuid = new PrefabGUID(1540217782) },
                    new Jewel { Name = "Mist_Trance", Tier = "T03", PrefabGuid = new PrefabGUID(-1513121786) },
                    new Jewel { Name = "Mosquito", Tier = "T03", PrefabGuid = new PrefabGUID(-826325611) },
                    new Jewel { Name = "Phantom_Aegis", Tier = "T03", PrefabGuid = new PrefabGUID(870884715) },
                    new Jewel { Name = "Spectral_Wolf", Tier = "T03", PrefabGuid = new PrefabGUID(455494178) },
                    new Jewel { Name = "Veil_Of_Illusion", Tier = "T03", PrefabGuid = new PrefabGUID(-1206629745) },
                    new Jewel { Name = "Wraith_Spear", Tier = "T03", PrefabGuid = new PrefabGUID(998259069) },
                    new Jewel { Name = "T04", Tier = "T04", PrefabGuid = new PrefabGUID(97169184) }
                }
            },
            {
                "storm", new List<Jewel>
                {
                    new Jewel { Name = "T01", Tier = "T01", PrefabGuid = new PrefabGUID(-560146452) },
                    new Jewel { Name = "T02", Tier = "T02", PrefabGuid = new PrefabGUID(876293388) },
                    new Jewel { Name = "Ball_Lightning", Tier = "T02", PrefabGuid = new PrefabGUID(-1703746731) },
                    new Jewel { Name = "Cyclone", Tier = "T02", PrefabGuid = new PrefabGUID(994654794) },
                    new Jewel { Name = "Discharge", Tier = "T02", PrefabGuid = new PrefabGUID(-313733383) },
                    new Jewel { Name = "Lightning_Wall", Tier = "T02", PrefabGuid = new PrefabGUID(394140527) },
                    new Jewel { Name = "Polarity_Shift", Tier = "T02", PrefabGuid = new PrefabGUID(-944716649) },
                    new Jewel { Name = "Veil_Of_Storm", Tier = "T02", PrefabGuid = new PrefabGUID(-1416449755) },
                    new Jewel { Name = "T03", Tier = "T03", PrefabGuid = new PrefabGUID(189228039) },
                    new Jewel { Name = "Ball_Lightning", Tier = "T03", PrefabGuid = new PrefabGUID(973763812) },
                    new Jewel { Name = "Cyclone", Tier = "T03", PrefabGuid = new PrefabGUID(-341717525) },
                    new Jewel { Name = "Discharge", Tier = "T03", PrefabGuid = new PrefabGUID(1533847605) },
                    new Jewel { Name = "Lightning_Wall", Tier = "T03", PrefabGuid = new PrefabGUID(-2134499162) },
                    new Jewel { Name = "Polarity_Shift", Tier = "T03", PrefabGuid = new PrefabGUID(-844537086) },
                    new Jewel { Name = "Veil_Of_Storm", Tier = "T03", PrefabGuid = new PrefabGUID(182214837) },
                    new Jewel { Name = "T04", Tier = "T04", PrefabGuid = new PrefabGUID(2023809276) }
                }
            },
            {
                "unholy", new List<Jewel>
                {
                    new Jewel { Name = "T01", Tier = "T01", PrefabGuid = new PrefabGUID(803445709) },
                    new Jewel { Name = "T02", Tier = "T02", PrefabGuid = new PrefabGUID(-860388090) },
                    new Jewel { Name = "Corpse_Explosion", Tier = "T02", PrefabGuid = new PrefabGUID(977816262) },
                    new Jewel { Name = "Corrupted_Skull", Tier = "T02", PrefabGuid = new PrefabGUID(-1183600395) },
                    new Jewel { Name = "Death_Knight", Tier = "T02", PrefabGuid = new PrefabGUID(-173571027) },
                    new Jewel { Name = "Soulburn", Tier = "T02", PrefabGuid = new PrefabGUID(1277476884) },
                    new Jewel { Name = "Veil_Of_Bones", Tier = "T02", PrefabGuid = new PrefabGUID(-1347054873) },
                    new Jewel { Name = "Ward_Of_The_Damned", Tier = "T02", PrefabGuid = new PrefabGUID(-593608743) },
                    new Jewel { Name = "T03", Tier = "T03", PrefabGuid = new PrefabGUID(-647547545) },
                    new Jewel { Name = "Corpse_Explosion", Tier = "T03", PrefabGuid = new PrefabGUID(-1123608041) },
                    new Jewel { Name = "Corrupted_Skull", Tier = "T03", PrefabGuid = new PrefabGUID(-1508992859) },
                    new Jewel { Name = "Death_Knight", Tier = "T03", PrefabGuid = new PrefabGUID(-318118264) },
                    new Jewel { Name = "Soulburn", Tier = "T03", PrefabGuid = new PrefabGUID(282707515) },
                    new Jewel { Name = "Veil_Of_Bones", Tier = "T03", PrefabGuid = new PrefabGUID(-1913987811) },
                    new Jewel { Name = "Ward_Of_The_Damned", Tier = "T03", PrefabGuid = new PrefabGUID(665184248) },
                    new Jewel { Name = "T04", Tier = "T04", PrefabGuid = new PrefabGUID(1412786604) }
                }
            }
        };
        
        internal static readonly Dictionary<string, (PrefabGUID, int)> MaterialDictionary =
            new Dictionary<string, (PrefabGUID, int)>()
            {
                { "planche", (new PrefabGUID(-1017402979), 400) }, //
                { "planche-renforcé", (new PrefabGUID(-1397591435), 8) }, //
                { "brique de pierre", (new PrefabGUID(1788016417), 400) }, //
                { "pierre", (new PrefabGUID(-1531666018), 240) }, //
                { "cuir", (new PrefabGUID(-1907572080), 12) }, //
                { "dark silver ingot", (new PrefabGUID(-762000259), 12) }, //
                { "lingots de cuivre", (new PrefabGUID(-1237019921), 12) }, //
                { "verre", (new PrefabGUID(-1233716303), 24) }, //
                { "power core", (new PrefabGUID(-1190647720), 4) }, //
                { "radium alloy", (new PrefabGUID(2116142390), 12) }, //
                { "essence", (new PrefabGUID(862477668), 250) }, //
                { "grande essence", (new PrefabGUID(271594022), 1) }, //
                { "essence originel", (new PrefabGUID(1566989408), 2) } //
            };
    }
}