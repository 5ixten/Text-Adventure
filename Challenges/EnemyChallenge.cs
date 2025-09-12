namespace TextAdventure;

public class EnemyChallenge : Challenge
{
    public string Name { get; set; } = "Fight";
    public List<Enemy> Enemies { get; }
    
    public EnemyChallenge(List<Enemy> enemies)
    {
        Enemies = enemies;
    }

    public void Start()
    {
        // Player presented by options
        // CurrentEnemy attacks
        // Loop until win
        int round = 0;
        while (!IsComplete())
        {
            round++;
            Console.Clear();
            Prompt.WriteMessage($"Fight Round {round}");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{Game.Player.Name}'s Health: {Game.Player.Health}/{Game.Player.MaxHealth}");
            
            // Enemy to attack
            Enemy targetEnemy = Enemies.First(e => !e.IsDefeated);
            Console.WriteLine($"{targetEnemy.Name}'s Health: {targetEnemy.Health}/{targetEnemy.MaxHealth}");
            
            // Get what item to use from input
            List<string> actionNames = Game.Player.Inventory.Items.Where(i => i.ItemType != ItemType.Tool).Select(i => i.Name).ToList();
            string escapeString = "Escape to previous room";
            actionNames.Add(escapeString);
            
            string actionName = Prompt.GetOption("Items and actions to use", actionNames);
            if (actionName == escapeString)
            {
                Game.EnterRoom(Game.VisitedRooms[Game.VisitedRooms.Count - 2]);
                return;
            }
            
            Item item = Game.Player.Inventory.Items.First(i => i.Name == actionName);

            // Use on enemy if offensive item, use on player if defensive item
            item.Use(item.ItemType == ItemType.Offensive ? targetEnemy : Game.Player);
            
            // Enemy attacks player
            // Select "targetEnemy" if alive, otherwise pick a new one
            Enemy? offensiveEnemy = targetEnemy.Health > 0 ? targetEnemy : Enemies.FirstOrDefault(e => !e.IsDefeated);
            if (offensiveEnemy != null)
            {
                offensiveEnemy.Weapon.Use(Game.Player);
            }
        }
    }

    public bool IsComplete()
    {
        List<Enemy> deadEnemies = Enemies.Where(e => e.IsDefeated == true).ToList();
        return deadEnemies.Count == Enemies.Count;
    }
}