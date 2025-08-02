namespace Gladiators;

public abstract class Character()
{
    public int Health = 100;
    public int Attack = 10;
    public int Defense = 0;
    public int Level = 1;

    internal class Player
    {
        public Player()
        {
        }
    }
}

public class Player(string name, string archetype) : Character()
{
    public string Name = name;
    public string Archetype = archetype;
    public int Gold = 0;
}