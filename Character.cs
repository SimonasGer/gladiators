namespace Gladiators;

public class Character(string name, int level)
{
    public string Name = name;
    public int Health = 100;
    public int Attack = 10;
    public int Defense = 0;
    public int Level = level;
    public void Battle(Character defender)
    {

        defender.Health -= Attack - defender.Defense;
        Console.WriteLine($"\n{Name} attacks {defender.Name} and deals {Attack - defender.Defense} damage!");
        Console.WriteLine($"\nDefender's health: {defender.Health}. Continue?");
        Console.ReadLine();

    }
}

public class Player(string name, string archetype, int level = 1) : Character(name, level)
{
    public string Archetype = archetype;
    public int Gold = 0;
}

public class Enemy : Character
{
    public static readonly Dictionary<int, (string name, int health, int attack, int defense)> Enemies = new()
    {
        { 1, ("Ratling", 60, 8, 0) },
        { 2, ("Bandit", 80, 12, 2) },
        { 3, ("Secutor", 100, 14, 4) },
        { 4, ("Beastmaster", 120, 16, 6) },
        { 5, ("Arena Warlord", 150, 20, 8) }
    };

    public Enemy(int level) : base("Enemy", level)
    {
        if (!Enemies.TryGetValue(level, out var enemy))
        {
            throw new ArgumentException("Invalid enemy level.");
        }
        Name = enemy.name;
        Health = enemy.health;
        Attack = enemy.attack;
        Defense = enemy.defense;
    }
}
