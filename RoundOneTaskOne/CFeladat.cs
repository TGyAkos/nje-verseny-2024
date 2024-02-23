namespace RoundOneTaskOne;

class CFeladat
{
    public double[] Szamok;
    public double[] DaraboltSzamok;

    public double result { get; set; }

    public CFeladat(double[] Szamok)
    {
        this.Szamok = Szamok;
        parseNumbers();
        findMostAbundantNumber();

        Console.WriteLine($"Legtobbszor megjelent ketjegyu szam: {result}");
    }

    void findMostAbundantNumber()
    {
        double query = (from item in DaraboltSzamok
            group item by item into g
            orderby g.Count() descending
            select g.Key).First();

        result = query;
    }

    void parseNumbers()
    {
        List<double> parsed = new List<double>();

        foreach (double szam in Szamok)
        {
            for (int i = 0; i < szam.ToString().Length - 1; i++)
            {
                parsed.Add(double.Parse(szam.ToString().Substring(i, 2)));
            }
        }

        DaraboltSzamok = parsed.ToArray();
    }
}