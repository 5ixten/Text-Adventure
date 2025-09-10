using System.Runtime.CompilerServices;

namespace TextAdventure;

public static class Rooms
{
    public static Room BasementCell = new Room(
        "Basement Cell",
        "You open your eyes, there's dampness in the air. Your surroundings consist of dark concrete walls and a locked steel door...",
        null,
        null);
    
    public static Room BasementHall = new Room(
        "Basement Hall",
        "You step into a claustrophobic hallway. In front of you stands a menacing goblin.",
        null,
        null);
    
    public static Room BasementStairs = new Room(
        "Basement Stairs",
        "Walking stair",
        null,
        null);
    
    //public static Room LivingRoom = new Room();
   // public static Room Outside = new Room();
    //public static Room Portal = new Room();

    public static void Initialize()
    {
        BasementCell.AddConnection(BasementHall, "Exit the prison cell");
        BasementHall.AddConnection(BasementStairs, "Go upstairs");
    }
}