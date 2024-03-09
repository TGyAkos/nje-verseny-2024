using System.Text;

namespace RoundThreeTaskTwo;

public class DFeladat
{
    string[] lines; 
    int result;
    Dictionary<int, List<string>> data = new();
    
    
    public DFeladat(string[] lines)
    {
        this.lines = lines;
        megoldas();
        Console.WriteLine($"DFeladat: {result}");
    }

    void megoldas()
    {
        foreach (string line in lines)
        {
            if (!data.ContainsKey(wordToNumber(line))) data[wordToNumber(line)] = [line];
            else data[wordToNumber(line)].Add(line);
        }
        
        result = data.MaxBy(x => x.Value.Count).Value.Count;
    }
    
    int wordToNumber(string c)
    {
        return Encoding.ASCII.GetBytes(c).Select(x => (int)x).ToArray().Sum();
    }
}