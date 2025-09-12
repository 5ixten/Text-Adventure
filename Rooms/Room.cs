namespace TextAdventure;

public class Room
{
    public string? Name;
    public string? Introduction;
    public Challenge? Challenge;
    public List<Item>? Items;
    public Dictionary<string, Room> ConnectedRooms = new();
    
    public int MaxLooting;
    private int ItemsLooted = 0;
    public Item[]? OriginalItems;

    public bool Introduced { get; private set; } = false;

    public Room(string name, string introduction, Challenge? challenge = null, List<Item>? items = null, int? maxLooting = null)
    {
        Name = name;
        Introduction = introduction;
        Challenge = challenge;
        Items = items;
        MaxLooting = maxLooting ?? (Items != null ? items.Count : 0);
        OriginalItems = items != null ? items.ToArray() : null;
    }

    public void AddConnection(Room room, string prompt)
    {
        ConnectedRooms.Add(prompt, room);
    }

    public bool ChallengeComplete()
    {
        return Challenge == null || Challenge.IsComplete();
    }

    public void DisplayItems()
    {
        if (!ChallengeComplete() || Items == null)
        {
            return;
        }

        
        bool limitedLooting = Items != null && MaxLooting != OriginalItems.Length;
        // Prevent looting more than MaxLooting
        if (limitedLooting && ItemsLooted < MaxLooting)
        {
            Prompt.WriteMessage($"You can only take {OriginalItems.Length - ItemsLooted - 1} more items", ConsoleColor.Yellow);
        } else if (limitedLooting && ItemsLooted >= MaxLooting)
        {
            Prompt.WriteMessage("Max amount of items looted here", ConsoleColor.Red);
            return;
        }
        
        // List all items available
        List<String> itemNames = Items.Select(i => i.Name).ToList();
        string? selectedItemName = Prompt.GetOption("Available items:", itemNames, true);
        if (selectedItemName == null)
            return;
        
        // Select and move item to inventory
        Item selectedItem =  Items.FirstOrDefault(i => i.Name == selectedItemName);
        Game.Player.Inventory.AddItem(selectedItem);
        Items.Remove(selectedItem);
        
        // Only increase ItemsLooted if the selectedItem wasn't previously owned by player
        if (OriginalItems.Contains(selectedItem))
        {
            ItemsLooted++;
        }
    }

    public void TryTravel()
    {
        if (!ChallengeComplete())
        {
            return;
        }
        
        List<string> keys = new();
        foreach (var otherRoom in ConnectedRooms)
        {
            keys.Add(otherRoom.Key);
        }

        Room? selectedRoom = null;
        // Enter next room if challenge is done/doesn't exist
        if (Challenge == null || Challenge.IsComplete())
        {
            string? key = Prompt.GetOption("Travel options:", keys, true);
            if (key == null)
                return;
            selectedRoom = ConnectedRooms[key];
        }
        Game.EnterRoom(selectedRoom);
    }
    
    public void WriteInfo()
    {
        if (!Introduced)
        {
            Introduced = true;
            Prompt.WriteMessage(Introduction);
        }
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"Location: {Name}");
        Console.ResetColor();
    }
}