namespace TextAdventure.Enemy;

public class Enemy : Character
{
    // Damage = BaseDamage + (DamageMultiplier * RandomNumber)
    public required float BaseDamage;
    public required float DamageMultiplier;

    public bool IsDefeated
    {
        get { return Health <= 0; }
    }

    public float GetRandomDamage(float multiplier)
    {
        return BaseDamage + (DamageMultiplier * multiplier);
    }
}