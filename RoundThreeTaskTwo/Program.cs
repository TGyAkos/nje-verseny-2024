namespace RoundThreeTaskTwo;

class Program
{
    static void Main()
    {   
        var lines = File.ReadAllLines(Directory.GetCurrentDirectory() + "../../../../szavak.txt");
        new CFeladat(lines);
        new DFeladat(lines);
        new EFeladat(lines);
    }
}