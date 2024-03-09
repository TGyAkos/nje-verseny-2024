namespace RoundThreeTaskOne;

public class BFeladat
{
    string resultB = "";
    private string[] lines;

    public BFeladat(string[] lines)
    {
        this.lines = lines;
        megoldas();
        Console.WriteLine($"BFeladat: {resultB}");
    }
    
    void megoldas()
    {
        List<Dictionary<char, int>> mostCommonChars = new List<Dictionary<char, int>>();
        List<char> mostCommonCharsInEachPlace = new List<char>();

        for(int i = 0; i < 100; i++)
        {
            Dictionary<char, int> mostCommonCharsInCurrPlace = new Dictionary<char, int>();
            foreach (var line in lines)
            {
                char c = line[i];
                if (c != '?' && c != '-')
                {
                    if (!mostCommonCharsInCurrPlace.ContainsKey(c)) mostCommonCharsInCurrPlace[c] = 1;
                    else mostCommonCharsInCurrPlace[c]++;
                }
            }
            mostCommonChars.Add(mostCommonCharsInCurrPlace);
        }

        foreach(var dict in mostCommonChars)
        {
            var currDict = dict.OrderByDescending(x => x.Value);
            mostCommonCharsInEachPlace.Add(currDict.First().Key);
        }

        resultB = new string(mostCommonCharsInEachPlace.ToArray());
    }
}