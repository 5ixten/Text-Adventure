namespace TextAdventure;

public class HealthPotion : Item
{
    public string Name { get; set; }
    public ItemType ItemType { get; set; }
    public float Healing;

    public HealthPotion(string name, ItemType itemType, float healing)
    {
        Name = name;
        ItemType = itemType;
        Healing = healing;
    }

    public void Use(Character target)
    {
        target.Heal(Healing);
        Game.Player.Inventory.Items.Remove(this);
    }
}