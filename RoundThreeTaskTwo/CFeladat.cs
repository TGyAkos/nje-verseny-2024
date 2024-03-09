using System.Text;

namespace RoundThreeTaskTwo;

public class CFeladat
{
    string[] lines;
    int result = 0;
    
    public CFeladat(string[] lines)
    {
        this.lines = lines;
        megoldas();
        Console.WriteLine($"CFeladat: {result}");
    }
    
    void megoldas()
    {
        foreach (string line in lines)
        {
            if (IsPrime(wordToNumber(line)))
            {
                result++;
            }
        }
    }
    
    int wordToNumber(string c)
    {
        return Encoding.ASCII.GetBytes(c).Select(x => (int)x).ToArray().Sum();
    }
    
    bool IsPrime(int number)
    {
        if (number <= 1) return false;
        if (number == 2) return true;
        if (number % 2 == 0) return false;

        var boundary = (int)Math.Floor(Math.Sqrt(number));
          
        for (int i = 3; i <= boundary; i += 2)
            if (number % i == 0)
                return false;
    
        return true;        
    }
}