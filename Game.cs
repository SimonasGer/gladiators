namespace Gladiators;

public class Game
{
    public static void Start()
    {
        Menu start = new("Welcome to the game", ["Start", "Quit"],
            [
                () => Start(), //If a non-existant option is selected, the option selection is redisplayed
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
        Console.WriteLine("\nEnter your name if you remember: ");
        string input = Console.ReadLine() ?? "";
        string name = string.IsNullOrWhiteSpace(input) ? "Slave" : input;
        Player player = new(archetype, name);
        Menu prologue = new($"You are a {player.Archetype}. You must fight to survive, {player.Name}. Right now, for example, a thug is charging at you", ["Fight Back!"],
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
            player.Level++;
            player.Health = player.MaxHealth;
            player.Gold += enemy.Gold;
            Console.WriteLine($"You defeated {enemy.Name}. Continue?");
            Console.ReadLine();
            City(player);
        }
    }
    private static void City(Player player)
    {
        Menu city = new($"You have {player.Health} health, {player.Attack} attack, {player.Defense} defence, and {player.Gold} gold, what will you do?", ["Fight", "Armor Shop", "Weapons Shop", "Quit"],
            [
                () => City(player),
                () => Fight(player),
                () => ArmorShop(player),
                () => WeaponsShop(player),
                () => Environment.Exit(0),
            ]

        );
        city.Show();
    }
    public static void ArmorShop(Player player)
    {
        Armor armorShop = new();
        Menu shop = new(armorShop.Text, armorShop.Choices,
            [
                () => ArmorShop(player),
                () => Armor.Upgrade(player),
                () => City(player),
            ]
        );
        shop.Show();
    }
    public static void WeaponsShop(Player player)
    {
        Weapons weaponsShop = new();
        Menu shop = new(weaponsShop.Text, weaponsShop.Choices,
            [
                () => ArmorShop(player),
                () => Weapons.Upgrade(player),
                () => City(player),
            ]
        );
        shop.Show();
    }
}