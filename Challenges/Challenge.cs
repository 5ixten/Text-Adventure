namespace TextAdventure;

public interface Challenge
{
    public string Name { get; set; }
    public void Start();
    public bool IsComplete();
}