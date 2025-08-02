namespace Gladiators;

public class Menu(string text, string[] options, Action[] actions)
{
    public string Text = text;
    public string[] Options = options;
    public Action[] Actions = actions;

    public void Show()
    {
        Console.WriteLine(Text + "\n");

        for (int i = 0; i < Options.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {Options[i]}");
        }
        int choice = GetChoice();
        Actions[choice].Invoke();
    }

    private int GetChoice()
    {
        Console.Write("\nEnter choice: ");
        string input = Console.ReadLine() ?? "";

        if (int.TryParse(input, out int choice) &&
            choice >= 1 && choice <= Options.Length)
        {
            return choice;
        }

        Console.WriteLine("\nInvalid choice. Try again.\n");
        return 0;
    }


}

