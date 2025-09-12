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
            
            // Parrying
            bool hasWeapons = actionNames.Count > 0;
            string parryString = "Parry (50% to block and redirect damage | 50% to take damage)";
            bool successfulParry = false;
            if (hasWeapons)
                actionNames.Add(parryString);
            
            string escapeString = "Escape to previous room";
            actionNames.Add(escapeString);
            
            // Get what action to do
            string actionName = Prompt.GetOption("Items and actions to use", actionNames);
            
            if (actionName == parryString) // Parry action
            {
                successfulParry = new Random().Next(1, 3) == 1; // 50% to parry
                Prompt.WriteMessage(successfulParry ? "Parry successful!" : "Parry failed...",
                    successfulParry ? ConsoleColor.Magenta : ConsoleColor.DarkRed);
            } 
            else if (actionName == escapeString) // Escape action
            {
                Game.EnterRoom(Game.VisitedRooms[Game.VisitedRooms.Count - 2]);
                return;
            } 
            else // Use item action
            {
                Item item = Game.Player.Inventory.Items.First(i => i.Name == actionName);
                // Use on enemy if offensive item, use on player if defensive item
                item.Use(item.ItemType == ItemType.Offensive ? targetEnemy : Game.Player);
            }
            
            // Enemy attacks player
            // Select "targetEnemy" if alive, otherwise pick a new one
            Enemy? offensiveEnemy = targetEnemy.Health > 0 ? targetEnemy : Enemies.FirstOrDefault(e => !e.IsDefeated);
            if (offensiveEnemy == null)
                continue; 
            
            // 1/3 that the enemy heals
            bool healEnemy = new Random().Next(1, 4) == 1;
            if (successfulParry) // Parry enemy
            {
                offensiveEnemy.Weapon.Use(offensiveEnemy);
            } 
            else if (healEnemy && offensiveEnemy.Health < offensiveEnemy.MaxHealth) // Heal enemy (if not full health)
            {
                offensiveEnemy.Heal(10);
            }
            else // Enemy attacks
            {
                offensiveEnemy.Weapon.Use(Game.Player);
            }

            if (Game.Player.IsDefeated)
            {
                Game.PlayerDied();
                return;
            }
        }
    }

    public bool IsComplete()
    {
        List<Enemy> deadEnemies = Enemies.Where(e => e.IsDefeated == true).ToList();
        return deadEnemies.Count == Enemies.Count;
    }
}