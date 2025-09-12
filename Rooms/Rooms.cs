using System.Runtime.CompilerServices;

namespace TextAdventure;

public static class Rooms
{
    public static Room BasementCell = new Room(
        "Basement Cell",
        "You open your eyes, there's dampness in the air. Your surroundings consist of dark concrete walls and a locked steel door...",
        null,
        null
    );
    
    public static Room BasementHall = new Room(
        "Basement Hall",
        "You step into a claustrophobic hallway. Something shiny is on the floor...",
        null,
        new () {
            new Weapon("Bronze Sword", ItemType.Offensive, 10f, 2f),
        }
    );
    
    public static Room BasementExit = new Room(
        "Basement Exit",
        "As you are only steps away from leaving the basement, a menacing goblin blocks your path. It charges at you, preparing to swing its crooked axe.",
        new EnemyChallenge( new()
            {
                new Enemy("Goblin", 30, new Weapon("Crooked axe", ItemType.Offensive, 15f, 1.2f))
            }),
        new () {
            new Weapon("Crooked Axe", ItemType.Offensive, 20f, 2f),
            new HealthPotion("Health Potion", ItemType.Defensive, 100f),
        }, 1
    );
    
    public static Room LivingRoom = new Room(
        "Living Room",
        "After slaying that horrendous goblin, you thrust through the door in front of you. Your eyes are blessed with a " +
        "beautiful livingroom and a crackling campfire. However, your peace is cut short as a bloodthirsty jester charges at you!",
        new EnemyChallenge( new()
        {
            new Enemy("Jester", 50, new Weapon("Silver Daggers", ItemType.Offensive, 5f, 4f))
        }),
        null
    );
    
    public static void Initialize()
    {
        BasementCell.AddConnection(BasementHall, "Exit the prison cell");
        BasementHall.AddConnection(BasementExit, "Exit Basement");
        BasementExit.AddConnection(LivingRoom, "A dark door");
    }
}