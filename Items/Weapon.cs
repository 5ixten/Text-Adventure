namespace TextAdventure;

public class Weapon : Item
{
    public string Name { get; set; }
    public ItemType ItemType { get; set; }
    
    // Damage = BaseDamage + (DamageMultiplier * RandomNumber)
    public float BaseDamage { get; private set; }
    public float DamageMultiplier { get; private set; }
    
    public Weapon(string name, ItemType itemType, float baseDamage, float damageMultiplier)
    {
        Name = name;
        ItemType = itemType;
        BaseDamage = baseDamage;
        DamageMultiplier = damageMultiplier;
    }

    public void Use(Character target)
    {
        int randomNum = new Random().Next(Settings.MinRandom, Settings.MaxRandom);
        float damage = MathF.Ceiling(GetRandomDamage(randomNum));
        target.TakeDamage(damage);
    }
    
    private float GetRandomDamage(float multiplier)
    {
        return BaseDamage + (DamageMultiplier * multiplier);
    }
}