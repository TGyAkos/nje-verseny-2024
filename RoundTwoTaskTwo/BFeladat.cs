namespace RoundTwoTaskTwo;

public class BFeladat
{
    private string[][] _jatszmak;
    private int _lepesek = 0;
    public BFeladat(string[][] allGames)
    {
        _jatszmak = allGames;
        countHuszarLepesek();
        Console.WriteLine($"Hurkászok lépésszáma: {_lepesek}");
    }

    void countHuszarLepesek()
    {
        foreach (string[] game in _jatszmak)
        {
            foreach (string move in game)
            {
                if (move.Contains("H"))
                {
                    _lepesek += 4;
                }
            }
        }
    }
    
}