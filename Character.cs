using System.Security.Cryptography.X509Certificates;

namespace Gladiators;

public class Character(string name, int level, int gold)
{
    public string Name = name;
    public int MaxHealth = 100;
    public int Health = 100;
    public int Attack = 10;
    public int Defense = 0;
    public int Gold = gold;
    public int Level = level;
    public void Battle(Character defender)
    {
        defender.Health -= Math.Clamp(Attack - defender.Defense, 0, 999);
        Console.WriteLine($"\n{Name} attacks {defender.Name} and deals {Attack - defender.Defense} damage!");
        Console.WriteLine($"\nDefender's health: {defender.Health}/{defender.MaxHealth}. Continue?");
        Console.ReadLine();

    }
}

public class Player : Character
{
    public string Archetype;
    public Player(string archetype, string name) : base(name, 0, 0)
    {
        Name = name;
        Archetype = archetype;
    }

}

public class Enemy : Character
{
    public static readonly Dictionary<int, (string name, int health, int attack, int defense, int gold)> Enemies = new()
    {
        { 0, ("Ratling", 60, 8, 0, 100) },
        { 1, ("Bandit", 80, 12, 2, 200) },
        { 2, ("Secutor", 100, 14, 4, 300) },
        { 3, ("Beastmaster", 120, 16, 6, 400) },
        { 4, ("Arena Warlord", 150, 20, 8, 500) }
    };

    public Enemy(int level) : base("Enemy", level, 0)
    {
        if (!Enemies.TryGetValue(level, out var enemy))
        {
            throw new ArgumentException("Invalid enemy level.");
        }
                Name = enemy.name;
        Health = enemy.health;
        MaxHealth = enemy.health;
        Attack = enemy.attack;
        Defense = enemy.defense;
        Gold = enemy.gold;
    }
}
