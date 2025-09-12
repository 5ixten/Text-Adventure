namespace TextAdventure;

public class Key : Item
{
    public string Name { get; set; }
    public ItemType ItemType { get; set; } = ItemType.Tool;

    public Key(string name)
    {
        Name = name;
    }

    public void Use(Character character)
    {
        
    }
}