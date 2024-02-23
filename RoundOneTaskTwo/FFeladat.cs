namespace RoundOneTaskTwo;

public class FFeladat
{
    public Data[] _datas { get; set; }
    public string?[] cleanDatas { get; set; }
    public List<char[]> filteredNames = new List<char[]>();
    public char[] compareChars = {'a', 'e', 't'};

    public FFeladat(Data[] datas)
    {
        _datas = datas;
        countTelepulesnevek();
    }

    void countTelepulesnevek()
    {
        List<char[]> cleanDataList = new List<char[]>();
        foreach (Data data in _datas)
        {
            cleanDataList.Add(
                data.TelepulesNev.ToLower().ToCharArray()
                );
        }
        
        int counter = 0;
        foreach (var asd in cleanDataList)
        {
            if (IsSubsequenceWithGaps(asd))
            {
                counter++;
            }
        }
        
        Console.WriteLine($"Településnevek: {counter} db");
    }
    
    public static bool Contains<T>(IEnumerable<T> data, IEnumerable<T> otherdata) {
        var datalength = data.Count();
        var otherdatalength = otherdata.Count();

        if (datalength < otherdatalength)
            return false;

        return Enumerable.Range(0, datalength - otherdatalength + 1)
            .Any(skip => data.Skip(skip).Take(otherdatalength).SequenceEqual(otherdata));
    }
    
    public bool IsSubsequenceWithGaps(char[] chars)
    {
        for (int i = 0; i < chars.Length; i++)
        {
            if (chars[i] == compareChars[0])
            {
                for (int j = i + 1; j < chars.Length; j++)
                {
                    if (chars[j] == compareChars[1])
                    {
                        for (int k = j + 1; k < chars.Length; k++)
                        {
                            if (chars[k] == compareChars[2])
                            {
                                return true;
                            }
                        }
                    }
                }
            }
        }
        return false;
    }
}
