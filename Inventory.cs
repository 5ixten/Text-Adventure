namespace TextAdventure;

public class Inventory
{
    public List<Item> Items { get; private set; }
    public int MaxSize = 4;
    
    public Inventory()
    {
        Items = new ();
    }

    public Item? DropTtem()
    {
        // List all items available
        List<String> itemNames = Items.Select(i => i.Name).ToList();
        string? selectedItemName = Prompt.GetOption("Available items to drop:", itemNames, true);
        if (selectedItemName == null)
            return null;
        
        // Select and move item to inventory
        Item selectedItem =  Items.FirstOrDefault(i => i.Name == selectedItemName);
        Items.Remove(selectedItem);
        Game.CurrentRoom.Items.Add(selectedItem);
        Prompt.WriteMessage($"{selectedItem.Name} was dropped, it can be found in the {Game.CurrentRoom.Name}", ConsoleColor.Red);
        return selectedItem;
    }

    public void AddItem(Item item)
    {
        if (Items.Count >= MaxSize)
        {
            Prompt.WriteMessage($"Inventory full, drop one item", ConsoleColor.DarkRed);
            Item? droppedItem = DropTtem();
            if (droppedItem == null)
                return;
        }
        
        Items.Add(item);
        Prompt.WriteMessage($"{Game.Player.Name} now owns {item.Name}", ConsoleColor.Green);
    }
}