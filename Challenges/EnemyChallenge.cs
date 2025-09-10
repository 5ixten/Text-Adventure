namespace TextAdventure;

public class EnemyChallenge : Challenge
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Enemy[] Enemies;
    public EnemyChallenge(Enemy[] enemies)
    {
        Enemies = enemies;
    }

    public bool IsComplete()
    {
        Enemy[] deadEnemies = Enemies.Where(e => e.IsDefeated == true).ToArray();
        return deadEnemies.Length == Enemies.Length;
    }
}