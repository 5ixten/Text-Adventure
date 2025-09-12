namespace TextAdventure;

public class DiceRollChallenge : Challenge
{
    public string Name { get; set; } = "Dice Roll";
    public int DiceSize;
    public int DiceCount;
    
    private bool Won = false;

    public DiceRollChallenge(int diceCount, int diceSize)
    {
        DiceSize = diceSize;
        DiceCount = diceCount;
    }

    public void Start()
    {
        while (!IsComplete())
        {
            Console.Clear();
            Console.WriteLine($"Roll the number {DiceSize} on all dices");
            Prompt.WriteMessage("Roll", ConsoleColor.Green);
            List<int> result = new();
            for (int i = 0; i < DiceCount; i++)
            {
                int randomNum = new Random().Next(1, DiceSize+1);
                result.Add(randomNum);
            }

            string resultString = string.Join(" ", result);
            bool won = result.TrueForAll(n => n == DiceSize);

            if (won)
            {
                Prompt.WriteMessage("Won! Dices: " + resultString, ConsoleColor.Green);
                Won = true;
            }
            else
            {
                Prompt.WriteMessage("Lost! Dices: " + resultString, ConsoleColor.DarkRed);
            }
        }
    }
    
    public bool IsComplete()
    {
        return Won;
    }
}