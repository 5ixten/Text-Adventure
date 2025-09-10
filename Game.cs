namespace TextAdventure;

public static class Game
{
    public static Player Player { get; private set; }
    public static Room CurrentRoom { get; private set; } = Rooms.BasementCell;
    private static bool Won = false;

    public static void Start()
    {
        string playerName = Prompt.GetText("Hello traveler, please enter your name");
        Console.Clear();
        Player = new Player(playerName,100);
        
        // Intro prompts
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Welcome to the grand Text Adventure {Player.Name}!");
        Console.ResetColor();
        Prompt.WriteMessage("Begin your journey", ConsoleColor.Yellow);
        Console.Clear();
        
        GameLoop();
    }

    public static void GameLoop()
    {
        CurrentRoom.WriteInfo();


        if (!Won)
        {
            GameLoop();
        }
    }

    public static void EnterRoom(Room newRoom)
    {
        // Check if the current room is completed
        if (CurrentRoom.Challenge != null && CurrentRoom.Challenge != "Completed")
        {
            Prompt.WriteMessage("Can't switch room without completing challenge", ConsoleColor.Red);
            return;
        }

        // Check if the new room, can be reached from the current room
        bool canEnter = false;
        foreach (var otherRoom in Game.CurrentRoom.ConnectedRooms)
        {
            if (otherRoom.Value == newRoom)
            {
                canEnter = true;
                break;
            }
        }
        
        if (!canEnter) return;
        CurrentRoom = newRoom;
    }
}