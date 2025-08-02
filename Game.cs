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
        Menu prologue = new($"You are a {archetype}. You must fight to survive, {name}. Right now, for example, your cellmate is lunging at you", ["Fight Back!"],
            [
                () => Prologue(archetype),
                () => Fight(player),
            ]

        );
        prologue.Show();
    }
    private static void Fight(Player player)
    {
        Enemy enemy = new(player.Level);
        while (enemy.Health > 0 && player.Health > 0)
        {
            player.Battle(enemy);
            if (enemy.Health <= 0) break;

            enemy.Battle(player);
            if (player.Health <= 0) break;
        }
        if (player.Health <= 0)
        {
            Console.WriteLine("\nYou died");
        }
        else
        {
            Console.WriteLine($"You defeated {enemy.Name}. Continue?");
            Console.ReadLine();

        }
    }
}