namespace RoundThreeTaskOne;

class Program
{
    static void Main()
    {   
        var lines = File.ReadAllLines(Directory.GetCurrentDirectory() + "../../../../uzenetek.txt");
        new BFeladat(lines);
        new CFeladat(lines);
        new DFeladat(lines);
    }
}

