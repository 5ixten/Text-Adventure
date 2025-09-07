using System;

namespace TextAdventure;

public static class Prompt
{
    public static string GetText(string message, ConsoleColor? foreground = null)
    {
        Console.ForegroundColor = foreground ?? Console.ForegroundColor;
        Console.WriteLine("\n" + message + ":");
        Console.ResetColor();
        
        string input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Input cannot be empty. Please try again.");
            return GetText(message, foreground);
        }

        return input;
    }

    public static void WriteMessage(string message, ConsoleColor? foreground = null)
    {
        Console.ForegroundColor = foreground ?? Console.ForegroundColor;
        Console.WriteLine(message + " (enter)");
        Console.ReadLine();
        Console.ResetColor();
    }
    
    public static bool GetBool(string message, ConsoleColor? foreground = null)
    {
        Console.ForegroundColor = foreground ?? Console.ForegroundColor;
        Console.WriteLine("\n" + message + "(y/n):");
        Console.ResetColor();
        
        string input = Console.ReadLine().ToLower();

        if (!input.Equals("y") && !input.Equals("n"))
        {
            Console.WriteLine("Invalid input. Please try again.");
            return GetBool(message, foreground);
        }

        return input.Equals("y");
    }
}
