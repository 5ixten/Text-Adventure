using System.ComponentModel;

namespace TextAdventure;

public static class Game
{
    public static Player Player { get; private set; }
    public static Room CurrentRoom { get; private set; } = Rooms.BasementCell;
    public static List<Room> VisitedRooms { get; set; } = new List<Room>();
    
    private static bool Won;

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
        Prompt.WriteMessage($"After entering the magic portal you've returned to your homeworld." +
                            $" Congrats {Player.Name}, you won the game!", ConsoleColor.DarkYellow);
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

    public static void PlayerDied()
    {
        Prompt.WriteMessage("After perishing in the midst of battle, you suddenly regain consciousness, back where you started...", ConsoleColor.DarkYellow);
        Game.Player.Health = Game.Player.MaxHealth;
        EnterRoom(Rooms.BasementCell);
    }

    public static void EnterRoom(Room newRoom)
    {
        CurrentRoom = newRoom;
        if (!VisitedRooms.Contains(newRoom))
            VisitedRooms.Add(CurrentRoom);

        if (CurrentRoom == Rooms.MagicPortal)
        {
            Won = true;
        }
    }
}