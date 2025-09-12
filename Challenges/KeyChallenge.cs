namespace TextAdventure;

public class KeyChallenge : Challenge
{
    public string Name { get; set; }
    public Item? key;

    public KeyChallenge(string name)
    {
        
    }

    public void Start()
    {
        Item? key = Game.Player.Inventory.Items.FirstOrDefault(i => i is Key);
        if (key == null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You need a key to enter...");
            Console.ResetColor();
            Prompt.WriteMessage("Return to last room");
            Game.EnterRoom(Game.VisitedRooms.First(r => r.ConnectedRooms.ContainsValue(Game.CurrentRoom)));
        }
    }

    public bool IsComplete()
    {
        return key != null;
    }
}