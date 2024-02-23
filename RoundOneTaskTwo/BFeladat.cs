namespace RoundOneTaskTwo;

public class BFeladat
{
    private Data[] _datas;

    public BFeladat(Data[] datas)
    {
        _datas = datas;
        LegEszakibbTelepules();
    }
    
    public void LegEszakibbTelepules()
    {
        Data max = _datas[0];
        for (int i = 1; i < _datas.Length; i++)
        {
            if (_datas[i].Szelesseg > max.Szelesseg)
            {
                max = _datas[i];
            }
        }
        Console.WriteLine($"Legészakibb település: {max.TelepulesNev}");
    }
}