namespace TextAdventure;

public class Weapon : Item
{
    public string Name { get; set; }
    
    // Damage = BaseDamage + (DamageMultiplier * RandomNumber)
    public required float BaseDamage;
    public required float DamageMultiplier;
    
    public Weapon(string name, int baseDamage, int damageMultiplier)
    {
        Name = name;
        BaseDamage = baseDamage;
        DamageMultiplier = damageMultiplier;
    }

    public void Use(Character enemy)
    {
        int randomNum = new Random().Next(Settings.MinRandom, Settings.MaxRandom);
        float damage = BaseDamage + (randomNum * DamageMultiplier);
        enemy.TakeDamage(damage);
    }
    
    public float GetRandomDamage(float multiplier)
    {
        return BaseDamage + (DamageMultiplier * multiplier);
    }
}