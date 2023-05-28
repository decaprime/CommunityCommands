![](logo.png)

# CommunityCommands for V Rising

CommunityCommands is a server modification for V Rising that adds chat commands compatible with the [VampireCommandFramework](https://github.com/decaprime/VampireCommandFramework). It is designed to provide a generic collection of commands to meet various community server needs. This is a spirtual successor in the line of ChatCommands by Nopey and RPGMods by Kaltharos. This mod is not a direct fork from that line and will not contain the RPG functionalities. It's purpose is to provide a generic collection of commands for a variety of community server needs.

## Installation

To install the CommunityCommands mod, follow these steps:

1. Download the latest release of the mod from the [GitHub repository](https://github.com/decaprime/CommunityCommands).
2. Extract the contents of the downloaded file into a folder.
3. Locate the BepInEx/plugins folder in your V Rising server installation.
4. Copy the CommunityCommands.dll file and paste it into the BepInEx/plugins folder.
5. Restart your server to apply the changes.

## Usage

**Note: The following commands are available only to administrators. To allow non-administrators to use the commands, you can modify the command attributes as shown below:**

```csharp
[Command("...", "..", description: "...", adminOnly: true)]  ==>  [Command("...", "..", description: "...", adminOnly: false)]
```

CommunityCommands introduces the following commands:

### .bloodpotion (or .bp)
Creates a potion with a specified blood type, quality, and value.

Example usage: 
- `.bloodpotion Warrior 80` *give you a 80% warrior blood merlot potion*
- `.bp rogue` *give you a 100% rogue blood merlot potion*

### .give (or .g)
Give a specific item or set of items to yourself.

Example usage:
- `.give item Amulet_Of_The_Unyielding_Charger` *give you the "Amulet Of The Unyielding Charger"*
- `.give set t8` *give you a full `T8` set*

### .spawnboss (or .sb)
Spawn a boss next to the player,  If the quantity is not provided, it summons only one boss.

Example usage: 
- `.spawnboss rufus 3` *spawn 3 rufus boss near the player.*
- `.spawnboss all 2` *spawn all the bosses 2 times.*

## Contributing

We welcome contributions to the CommunityCommands mod! If you have any bug fixes, improvements, or new features to suggest, feel free to submit a pull request on the [GitHub repository](https://github.com/your-repo-link).

Please ensure that your code follows the existing coding style and includes appropriate documentation.


Happy gaming!
