namespace Gladiators;

public class Game
{
    public static void Start()
    {
        Menu start = new("Welcome to the game", ["Start", "Quit"],
            [
                () => Start(),
                () => SelectCharacter(),
                () => Environment.Exit(0),
            ]

        );
        start.Show();
    }
    private static void SelectCharacter()
    {
        Menu createCharacter = new("Select character class", ["Slave"],
            [
                () => SelectCharacter(),
                () => Prologue("slave"),
            ]

        );
        createCharacter.Show();
    }
    private static void Prologue(string archetype)
    {
        Console.WriteLine("\nEnter your name if you remember.");
        string name = Console.ReadLine() ?? "Slave";
        Player player = new(name, archetype);
        Menu prologue = new($"You are a {archetype}. You must fight to survive, {name}", ["Continue"],
            [
                () => Fight(player),
                () => Environment.Exit(0),
            ]

        );
        prologue.Show();
    }
    private static void Fight(object player)
    {
        Console.WriteLine("Fight one");
    }
}
