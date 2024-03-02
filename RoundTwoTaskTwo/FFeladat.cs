namespace RoundTwoTaskTwo;

public class FFeladat
{
    private string[][] _jatszmak;
    private int _tablaCounter = 0;
    
    public FFeladat(string[][] allGames)
    {
        _jatszmak = allGames;
        countTables();
        Console.WriteLine($"Tobb mint husz babu maradt a tablan: {_tablaCounter}");
    }

    void countTables()
    {
        foreach (string[] game in _jatszmak)
        {
            int numberOfPieces = 32;
            foreach (string move in game)
            {
                if (move.Contains("x"))
                {
                    numberOfPieces--;
                }
            }
            if (numberOfPieces > 20)
            {
                _tablaCounter++;
            }
        }
    }
}