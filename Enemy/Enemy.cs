namespace TextAdventure;

public class Enemy : Character
{
    public Weapon Weapon;
    public Enemy(string name, int maxHealth, Weapon weapon)
    {
        Name = name;
        MaxHealth = maxHealth;
        Health = maxHealth;
        Weapon = weapon;
    }
}