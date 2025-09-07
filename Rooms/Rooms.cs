namespace TextAdventure;

public static class Rooms
{
    public static Room BasementCell;
    public static Room BasementHall;
    public static Room BasementStairs;
    public static Room LivingRoom;
    public static Room Outside;
    public static Room Portal;

    public static void Initialize()
    {
        BasementCell = new Room(
            "Basement Cell",
            null, 
            "Bronze Sword",
            new() {
                {"Forward", BasementHall} }
           );
    }
}