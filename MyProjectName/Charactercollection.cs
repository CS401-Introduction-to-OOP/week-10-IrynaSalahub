using System.Collections;

namespace DefaultNamespace;

public class Charactercollection : IEnumerable<Character>
{
    private List<Character> _characters = new List<Character>();

    public void Add(Character character)
    {
        _characters.Add(character);
    }

    public IEnumerator<Character> GetEnumerator()
    {
        foreach (var character in _characters)
        {
            yield return character;
        }
    }

    public IEnumerable<Character> GetActiveCharacters()
    {
        foreach (var character in _characters)
        {
            if (character.Status.Equals("Активний"))
            {
                yield return character;
            }
        }
    }

    public IEnumerable<Character> GetLowHPCharacters(float minHp)
    {
        foreach (var character in _characters)
        {
            if (character.HP < minHp)
            {
                yield return character;
            }
        }
    }
    
    public IEnumerable<Character> GetCharactersAboveLevel(int minLevel)
    {
        return _characters.Where(c => c.Level > minLevel);
    }
    
    public IEnumerable<Character> SortByHP()
    {
        return _characters.OrderBy(c => c.HP);
    }
    
    public IEnumerable<string> GetNames()
    {
        return _characters.Select(c => c.Name);
    }

    public Character MostGold()
    {
        float maxGold = _characters.Max(c => c.Gold);
        return _characters.First(c => c.Gold == maxGold);
    }

    public int NumberOfHurt()
    {
        return _characters.Count(c => c.Status == "Поранений");
    }

    public void PrintGroupsByRole()
    {
        var groups = _characters.GroupBy(c => c.Role);
        foreach (var group in groups)
        {
            Console.WriteLine($"Клас --> {group.Key}, кількість --> {group.Count()}");
        }
    }
    
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}