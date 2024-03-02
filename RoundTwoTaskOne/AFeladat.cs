namespace RoundTwoTaskOne;

public class AFeladat
{
    private string _szam;

    public AFeladat()
    {
        _szam = "1";
        generateNumber();
        Console.WriteLine($"A. 21. szám: {_szam}");
    }
    
    private void generateNumber()
    {
        for (int i = 1; i <= 20; i++)
        {
            // Console.WriteLine($"{i}. szám: {_szam}");
            string newSzam = "";
            foreach (char jegy in _szam)
            {
                newSzam += (Convert.ToInt32(char.ToString(jegy)) * 2).ToString();
            }
            _szam = newSzam;
        }
    }
    
}