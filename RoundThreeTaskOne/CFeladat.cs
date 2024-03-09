namespace RoundThreeTaskOne;

public class CFeladat
{
    Dictionary<string, double> resultC = new();
    private string[] lines;

    private string correctString =
        "7610922751913275142233435073915524642160008422684973049146293643594970710907471138712178244571230807";
    Dictionary<string, int> incorrectChars = new();
    Dictionary<string, int> correctNumberOfChars = new();
    Dictionary<string, double> incorrectCharsPercent = new();
    double[] mostIncorrect = [0, 0];

    
    public CFeladat(string[] lines)
    {
        this.lines = lines;
        megoldas();
        Console.WriteLine($"CFeladat: {resultC.First()}");
    }
    
    void megoldas()
    {
        for (int d = 0; d < 10; d++)
        {
            correctNumberOfChars[d.ToString()] = correctString.Count(x => x.ToString() == d.ToString());
            incorrectChars[d.ToString()] = 0;
        }

        for (int i = 0; i < lines.Length; i++)
        {
            string line = lines[i];
            for (int j = 0; j < line.Length; j++)
            {
                if (line[j] != correctString[j])
                {
                    incorrectChars[correctString[j].ToString()]++;
                }
            }
        }
        
        foreach (var correctNumberOfChar in correctNumberOfChars)
        {
            incorrectCharsPercent[correctNumberOfChar.Key] = (double)incorrectChars[correctNumberOfChar.Key] / (double)(correctNumberOfChar.Value * 500) ;
        }

        foreach (var incorrectCharPercent in incorrectCharsPercent)
        {
            if (incorrectCharPercent.Value > mostIncorrect[1])
            {
                mostIncorrect[0] = Convert.ToDouble(incorrectCharPercent.Key);
                mostIncorrect[1] = incorrectCharPercent.Value;
            }
        }
        
        resultC.Add(mostIncorrect[0].ToString(), mostIncorrect[1]);

    }
}