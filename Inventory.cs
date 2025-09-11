namespace TextAdventure;

public class Inventory
{
    public List<Item> Items { get; private set; }
    public int MaxSize = 4;
    
    public Inventory()
    {
        Items = new ();
    }

    public void AddItem(Item item)
    {
        Items.Add(item);
        Prompt.WriteMessage($"{Game.Player.Name} now owns {item.Name}", ConsoleColor.Green);
    }
}