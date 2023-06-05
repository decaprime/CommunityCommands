namespace CommunityCommands.Commons;

public class Item
{
    public string Name { get; set; }
    public int Prefab { get; set; }

    public override string ToString()
    {
        return $"{{name: \"{Name}\", prefab: {Prefab}}}";
    }
}