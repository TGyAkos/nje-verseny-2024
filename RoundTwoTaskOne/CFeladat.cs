namespace RoundTwoTaskOne;

public class CFeladat
{
    string _szam;
    
    public CFeladat()
    {
        _szam = "11";
        generateNumber();
        Console.WriteLine($"A 31. elem: {_szam}");
    }
    
    private void generateNumber()
    {
        for (int i = 1; i <= 30; i++)
        {
            int osszeg = 0;
            foreach (char szam in _szam)
            {
                 osszeg += Convert.ToInt32(char.ToString(szam));
            }

            _szam += osszeg.ToString();
        }
    }
}