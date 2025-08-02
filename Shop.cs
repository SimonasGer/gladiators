namespace Gladiators;

public abstract class Shop
{
    public string Text = "Welcome to the generic shop!";
    public string[] Choices = [];
    public virtual void Upgrade()
    {

    }
}

public class Armor : Shop
{
    public static readonly Dictionary<int, (int health, int defense, int gold)> ArmorLevels = new()
    {
        { 1, (100, 2, 50) },
        { 2, (200, 4, 100) },
        { 3, (300, 6, 150) },
        { 4, (400, 8, 200) },
        { 5, (500, 10, 250) },
    };
    public Armor()
    {
        Text = "Welcome to the armor shop";
        Choices = ["Upgrade armor", "Exit shop"];
    }
    public static void Upgrade(Player player)
    {
        if (!ArmorLevels.TryGetValue(player.Level, out var level))
        {
            throw new ArgumentException("Invalid upgrade level.");
        }
        if (player.Gold < level.gold)
        {
            Console.WriteLine("\nNot enough gold to upgrade");
            Game.ArmorShop(player);
            return;
        }
        player.Gold -= level.gold;
        player.MaxHealth = level.health;
        player.Health = level.health;
        player.Defense = level.defense;
        Game.ArmorShop(player);
    }

}

public class Weapons : Shop
{
    public static readonly Dictionary<int, (int attack, int gold)> WeaponLevels = new()
    {
        { 1, (15, 50) },
        { 2, (20, 100) },
        { 3, (25, 150) },
        { 4, (30, 200) },
        { 5, (35, 250) },
    };
    public Weapons()
    {
        Text = "Welcome to the weapons shop";
        Choices = ["Upgrade weapon", "Exit shop"];
    }
    public static void Upgrade(Player player)
    {
        if (!WeaponLevels.TryGetValue(player.Level, out var level))
        {
            throw new ArgumentException("Invalid upgrade level.");
        }
        if (player.Gold < level.gold)
        {
            Console.WriteLine("\nNot enough gold to upgrade");
            Game.WeaponsShop(player);
            return;
        }
        player.Gold -= level.gold;
        player.Attack = level.attack;
        Game.WeaponsShop(player);
    }
}