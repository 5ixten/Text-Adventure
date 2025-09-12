using System;

namespace TextAdventure;

public static class Prompt
{
    public static string GetText(string message, ConsoleColor? foreground = null)
    {
        Console.ResetColor();
        Console.ForegroundColor = foreground ?? Console.ForegroundColor;
        Console.Write("\n" + message + ": ");
        Console.ResetColor();
        
        string input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Input cannot be empty. Please try again.");
            return GetText(message, foreground);
        }

        return input;
    }
    
    public static string? GetOption(string message, List<string> options, bool canBack = false, ConsoleColor foreground = ConsoleColor.DarkYellow)
    {
        Console.ResetColor();
        Console.ForegroundColor = foreground;
        
        if (canBack && !options.Contains("Back"))
            options.Add("Back");
        
        string optionText = "";

        for (int i = 0; i < options.Count; i++)
        {
            optionText += $"{i+1}. {options[i]}\n";
        }

        Console.WriteLine("\n" + message);
        Console.WriteLine(optionText);
        
        Console.ResetColor();
        Console.Write("What would you like to do? (enter number): ");

        int number;
        if (int.TryParse(Console.ReadLine(), out number))
        {
            if ((number-1) < 0 || number > options.Count)
            {
                return GetOption(message, options, canBack, foreground);
            }

            if (options[number - 1] == "Back")
                return null;
            return options[number-1];
        }

        return GetOption(message, options, canBack, foreground);
    }

    public static void WriteMessage(string message, ConsoleColor? foreground = null)
    {
        Console.ForegroundColor = foreground ?? Console.ForegroundColor;
        Console.Write("\n" + message + " (enter) ");
        Console.ReadLine();
        Console.ResetColor();
    }
    
    public static bool GetBool(string message, ConsoleColor? foreground = null)
    {
        Console.ForegroundColor = foreground ?? Console.ForegroundColor;
        Console.Write("\n" + message + "(y/n): ");
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
