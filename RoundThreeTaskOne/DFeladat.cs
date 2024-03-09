namespace RoundThreeTaskOne;

public class DFeladat
{
    string[] lines;
    private string correctString =
        "7610922751913275142233435073915524642160008422684973049146293643594970710907471138712178244571230807";

    private int resultLength = 0;
    private int resultLine = 0;
    private int resultStart = 0;
    
    public DFeladat(string[] lines)
    {
        this.lines = lines;
        megoldas();
        Console.WriteLine($"DFeladat: {resultLength} {resultLine} {resultStart}");
        
    }

    void megoldas()
    {
        for (int i = 1; i <= lines.Length; i++)
        {
            string line = lines[i - 1];
            int currentLine = i;
            int currentStart = 0;
            int currentLenght = 0;
            for (int j = 1; j <= line.Length; j++)
            {
                if (line[j - 1] != correctString[j - 1] && currentStart == 0)
                {
                    currentStart = j;
                    currentLenght++;
                } 
                else if(line[j - 1] != correctString[j - 1])
                {
                    currentLenght++;
                }
                else if (line[j - 1] == correctString[j - 1])
                {
                    if (currentLenght > resultLength)
                    {
                        resultLength = currentLenght;
                        resultLine = currentLine;
                        resultStart = currentStart;
                    }
                    currentStart = 0;
                    currentLenght = 0;
                }
            }
        }
    }
}