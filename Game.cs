namespace TextAdventure;

public static class Game
{
    public static Player Player { get; private set; }

    public static void Start()
    {
        string playerName = Prompt.GetText("Hello traveler, please enter your name");
        Console.Clear();
        Player = new Player(playerName, 100);
        Player.WriteStats();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Welcome to the grand Text Adventure {Player.Name}!");
        Console.ResetColor();
        Prompt.WriteMessage("Begin your journey", ConsoleColor.Yellow);
        Console.Clear();
    }
}