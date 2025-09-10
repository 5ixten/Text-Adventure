namespace TextAdventure;

public interface Challenge
{
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsComplete();
}