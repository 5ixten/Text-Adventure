namespace TextAdventure;

public class Player : Character
{
    public Inventory Inventory;

    public Player(string name, int maxHealth)
    {
        Name = name;
        MaxHealth = maxHealth;
        Health =  maxHealth;
        
        Inventory = new Inventory();
    }

    public void WriteStats()
    {
        Console.BackgroundColor = ConsoleColor.Black;
        Console.WriteLine($"\n--{Name}'s Stats--");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"  Health: {Health}/{MaxHealth}");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("  Inventory: EMPTY");
        Console.ResetColor();
    }

    public void TakeDamage(int damage)
    {
        Health = Math.Clamp(Health - damage, 0, MaxHealth);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"⚔️︎ {Name} has been hit for {damage} damage!");
        Console.ResetColor();
    }
}