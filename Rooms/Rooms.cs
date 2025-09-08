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
            "You open your eyes, there's dampness in the air. Your surroundings consist of dark concrete walls and a locked steel door...",
            new() {
                {"Exit the prison cell", BasementHall} },
            null, 
            "Bronze Sword"
           );
    }
}