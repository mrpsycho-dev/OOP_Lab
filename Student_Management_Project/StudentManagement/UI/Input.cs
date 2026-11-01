namespace StudentManagement.UI;

public static class Input
{
    public static string ReadText(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine();
    }

    public static int ReadInt(string prompt)
    {
        int value;
        Console.Write(prompt);
        while (!int.TryParse(Console.ReadLine(), out value))
            Console.Write("Please enter a number: ");
        return value;
    }

    public static bool Confirm(string prompt) => ReadText($"{prompt} (y/n): ")?.ToLower() == "y";

    public static void Pause()
    {
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey(true);
    }
}
