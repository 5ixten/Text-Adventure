namespace TextAdventure;

public class Character
{
    public string Name;
    public int MaxHealth;
    public float Health;
    
    public bool IsDefeated
    {
        get { return Health <= 0; }
    }
    
    public void TakeDamage(float damage)
    {
        Health = Math.Clamp(Health - damage, 0, MaxHealth);
        Prompt.WriteMessage($"- {Name} has been hit for {damage} damage!", ConsoleColor.Red);
        if (IsDefeated)
        {
            Prompt.WriteMessage($"- {Name} was killed", ConsoleColor.Red);
        }
    }
}