namespace DefaultNamespace;

public class Character
{
    public string Name { get; set; }
    public string Role { get; set; }
    public float Level { get; set; }
    public float HP { get; set; }
    public float Gold { get; set; }
    public string Status { get; set; }

    public Character(string name, string role, float level, float hp, float gold, string status)
    {
        Name = name;
        Role = role;
        Level = level;
        HP = hp;
        Gold = gold;
        Status = status;
    }

}