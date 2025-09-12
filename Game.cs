using System.ComponentModel;

namespace TextAdventure;

public static class Game
{
    public static Player Player { get; private set; }
    public static Room CurrentRoom { get; private set; } = Rooms.BasementCell;
    public static List<Room> VisitedRooms { get; set; } = new List<Room>();
    
    private static bool Won = false;

    public static void Start()
    {
        Console.Clear();
        string playerName = Prompt.GetText("Hello traveler, please enter your name");
        Console.Clear();
        Player = new Player(playerName,100);
        
        // Intro prompts
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Welcome to the grand Text Adventure {Player.Name}!");
        Console.ResetColor();
        Prompt.WriteMessage("Begin your journey", ConsoleColor.Yellow);
        Console.Clear();
        
        VisitedRooms.Add(Rooms.BasementCell);
        GameLoop();
    }
    
    public static void GameLoop()
    {
        while (!Won)
        {
            Console.Clear();
            CurrentRoom.WriteInfo();

            if (!CurrentRoom.ChallengeComplete())
            {
                StartChallenge();
            } else
            {
                TravelOrLoot();
            }
        }
    }

    public static void TravelOrLoot()
    {
        List<string> options = new() { };
        
        if (CurrentRoom.Items != null && CurrentRoom.Items.Count > 0)
            options.Add("Loot");
        
        options.Add("Travel Forward");
        
        if (VisitedRooms.Count > 1)
            options.Add("Global Travel");
        
        string playerAction = Prompt.GetOption("What do you want to do?", options);
        switch (playerAction)
        {
            case "Loot":
                CurrentRoom.DisplayItems();
                break;
            case "Travel Forward":
                CurrentRoom.TryTravel();
                break;
            case "Global Travel":
                GobalTravel();
                break;
        }
    }
    
    public static void GobalTravel()
    {
        List<string> keys = VisitedRooms.Where(r => r != CurrentRoom).Select(k => k.Name).ToList();
        string? key = Prompt.GetOption("Travel options:", keys, true);
        
        if (key == null)
            return;
        
        Room selectedRoom = VisitedRooms.FirstOrDefault(r => r.Name == key);
        Game.EnterRoom(selectedRoom);
    }

    public static void StartChallenge()
    {
        if (CurrentRoom.ChallengeComplete())
        {
            Console.WriteLine("Error: Can't start challenge");
            return;
        }
        
        CurrentRoom.Challenge.Start();
    }

    public static void EnterRoom(Room newRoom)
    {
        // Check if the current room is completed
        /*if (CurrentRoom.Challenge != null && !CurrentRoom.Challenge.IsComplete())
        {
            Prompt.WriteMessage("Can't switch room without completing challenge", ConsoleColor.Red);
            return;
        }*/

        // Check if the new room, can be reached from the current room
       /* bool canEnter = false;
        foreach (var otherRoom in Game.CurrentRoom.ConnectedRooms)
        {
            if (otherRoom.Value == newRoom)
            {
                canEnter = true;
                break;
            }
        }
        
        if (!canEnter) return;
        */
        CurrentRoom = newRoom;
        if (!VisitedRooms.Contains(newRoom))
            VisitedRooms.Add(CurrentRoom);
    }
}