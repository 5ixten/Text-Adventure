namespace TextAdventure;

public class Room
{
    public string Name;
    public string Introduction;
    public string? Challenge;
    public string? Items;
    public Dictionary<string, Room> ConnectedRooms;

    public bool Introduced { get; private set; } = false;

    public Room(string name, string introduction, Dictionary<string, Room> connectedRooms, string? challenge, string? items)
    {
        Name = name;
        Introduction = introduction;
        ConnectedRooms = connectedRooms;
        Challenge = challenge;
        Items = items;
    }
    
    public void WriteInfo()
    {
        Console.Clear();
        if (!Introduced)
        {
            Introduced = true;
            Console.WriteLine(Introduction);
        }

        List<string> keys = new();
        foreach (var otherRoom in ConnectedRooms)
        {
            keys.Add(otherRoom.Key);
        }

        Room? selectedRoom = null;
        // Enter next room if challenge is done/doesn't exist
        if (Challenge == null || Challenge == "Completed")
        {
            string key = Prompt.GetOption("Available actions:", keys, ConsoleColor.DarkYellow);
            selectedRoom = ConnectedRooms[key];
        }
        Console.WriteLine("Selectedroom recieved");
    }
}