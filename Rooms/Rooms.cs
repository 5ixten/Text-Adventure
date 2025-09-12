using System.Runtime.CompilerServices;

namespace TextAdventure;

public static class Rooms
{
    public static Room BasementCell = new Room(
        "Basement Cell",
        "You open your eyes, there's dampness in the air. Your surroundings consist of dark concrete walls and a locked steel door..."
    );
    
    public static Room BasementHall = new Room(
        "Basement Hall",
        "You step into a claustrophobic hallway. Something shiny is on the floor...",
        null,
        new () {
            new Weapon("Bronze Sword", ItemType.Offensive, 8f, 2f),
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
        "beautiful livingroom and a crackling fireplace. However, your peace is cut short as a bloodthirsty jester charges at you!",
        new EnemyChallenge( new()
        {
            new Enemy("Jester", 50, new Weapon("Silver Daggers", ItemType.Offensive, 5f, 4f))
        })
    );
    
    public static Room Kitchen = new Room(
        "Kitchen",
        "As soon as you enter this room, the smell of rotten food hits your nostrils. Luckily, the cabinets are full of potions...",
        null,
        new()
        {
            new HealthPotion("Health Potion", ItemType.Defensive, 100f),
            new HealthPotion("Health Potion", ItemType.Defensive, 100f),
            new HealthPotion("Health Potion", ItemType.Defensive, 100f)
        }
    );
    
    public static Room MysteriousPantry = new Room(
        "Mysterious Pantry",
        "You enter a mysterious pantry, there are some dices and a magic box on the floor...",
        new DiceRollChallenge(2, 6),
        new()
        {
            new Key("Port Key")
        }
    );
    
    public static Room LargePort = new Room(
        "Large Port",
        "You approach a grand and enormous port",
        new KeyChallenge("Key challenge"),
        new () {
            new Weapon("Flaming Spear", ItemType.Offensive, 50f, 5f),
        }
    );
    
    public static Room OldYard = new Room(
        "Old Yard",
        "After opening the port, fresh air makes your hair swirl. You're now standing in the middle of an old yard, there are growls and howls in the distance...",
        new EnemyChallenge( new()
        {
            new Enemy("Dire Wolf", 150, new Weapon("Claws", ItemType.Offensive, 20f, 2f)),
            new Enemy("Boss Goblin", 250, new Weapon("Spiked Wooden Club", ItemType.Offensive, 15f, 4f))
        })
    );
    
    public static Room MagicPortal = new Room(
        "Magic Portal",
        "You approach a glistering portal, a portal to your home world!"
    );
    
    public static void Initialize()
    {
        BasementCell.AddConnection(BasementHall, "Exit the prison cell");
        BasementHall.AddConnection(BasementExit, "Exit Basement");
        BasementExit.AddConnection(LivingRoom, "Dark door");
        
        LivingRoom.AddConnection(LargePort, "Large port");
        LargePort.AddConnection(OldYard, "Old Yard");
        
        LivingRoom.AddConnection(Kitchen, "Kitchen");
        Kitchen.AddConnection(MysteriousPantry, "Mysterious pantry");
        
        OldYard.AddConnection(MagicPortal, "Magic Portal");
    }
}