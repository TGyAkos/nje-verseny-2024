using System.Text;

namespace RoundThreeTaskTwo;

public class EFeladat
{
    string[] lines; 
    char[] result;
    Dictionary<int, List<string>> data = new();
    List<char> allCharacters = new();
    
    
    public EFeladat(string[] lines)
    {
        this.lines = lines;
        megoldas();
        Console.WriteLine($"EFeladat: {new String(result)}");
    }

    void megoldas()
    {
        foreach (string line in lines)
        {
            if (wordToNumber(line) == 607) allCharacters.AddRange(line.ToCharArray());
        }

        var query = (from characters in allCharacters
            group characters by characters into g
            let count = g.Count()
            orderby count descending
            select new { Value = g.Key, Count = count });

        result = query.Where(x => x.Count >= 5).Select(x => x.Value).ToArray();
        Array.Sort(result);
    }

    int wordToNumber(string c)
    {
        return Encoding.ASCII.GetBytes(c).Select(x => (int)x).ToArray().Sum();
    }
}