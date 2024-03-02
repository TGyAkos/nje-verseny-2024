namespace RoundTwoTaskOne;

public class BFeladat
{
    private string _kezdoSzam = "";

    public BFeladat()
    {
        generateAndCompareNumber();
        Console.WriteLine($"B. A kezdo szam: {_kezdoSzam}");
    }
    
    private void generateAndCompareNumber()
    {
        for (int i = 10; i <= 100; i++)
        {
            string szam = i.ToString();
            for (int j = 1; j <= 30; j++)
            {
                if ((szam.Length > 27 && szam.Substring(szam.Length - 27) == "216816212162121681684816816"))
                {
                    _kezdoSzam = i.ToString();
                    return;
                }
                string newSzam = "";
                foreach (char jegy in szam)
                {
                    newSzam += (Convert.ToInt32(char.ToString(jegy)) * 2).ToString();
                }
                szam = newSzam;
            }
        }
    }
}