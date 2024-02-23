namespace RoundOneTaskTwo;

public class DFeladat
{
    private Data[] _datas;
    private Data[] _cleanDatas;
    private List<DifferenceData> _differenceDatas = new List<DifferenceData>();

    public DFeladat(Data[] datas)
    {
        _datas = datas;
        CleanDatas();
        FindLargestAreaDifference();
    }
    
    void CleanDatas()
    {
        List<Data> cleanDataList = new List<Data>();
        foreach (Data data in _datas)
        {
            if (data.Szelesseg is (>= 47.3f and <= 47.4f))
            {
                cleanDataList.Add(data);
            }
        }
        
        cleanDataList.Sort((x, y) => x.Hosszusag.CompareTo(y.Hosszusag));
        _cleanDatas = cleanDataList.ToArray();
    }

    void FindLargestAreaDifference()
    {
        for (var i = 0; i < _cleanDatas.Length - 1; i++)
        {
            var data = _cleanDatas[i];
            _differenceDatas.Add(new DifferenceData
            {
                ElsoVaros = data.TelepulesNev,
                MasodikVaros = _cleanDatas[i + 1].TelepulesNev,
                TeruletKulonbseg = Math.Abs(data.Terulet - _cleanDatas[i + 1].Terulet)
            });
        }
        
        _differenceDatas.Sort((x, y) => y.TeruletKulonbseg.CompareTo(x.TeruletKulonbseg));
        Console.WriteLine($"Legnagyobb területkülönbség: {_differenceDatas[0].ElsoVaros}-{_differenceDatas[0].MasodikVaros}-{_differenceDatas[0].TeruletKulonbseg}");
    }
    
}

class DifferenceData
{
    public string ElsoVaros { get; set; }
    public string MasodikVaros { get; set; }
    public float TeruletKulonbseg { get; set; }
}
