namespace TextAdventure;

public class Room
{
    public string Name;
    public string? Challenge;
    public string? Items;
    public Dictionary<string, Room> ConnectedRooms;

    public Room(string name, string? challenge, string? items,  Dictionary<string, Room> connectedRooms)
    {
        Name = name;
        Challenge = challenge;
        Items = items;
        ConnectedRooms = connectedRooms;
    }
}