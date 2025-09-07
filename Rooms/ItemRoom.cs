namespace TextAdventure.Rooms;

public class ItemRoom : Room
{
    public Item[] Items;

    public ItemRoom(Item[] items)
    {
        Items = items;
    }
}