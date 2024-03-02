namespace RoundTwoTaskTwo;

public class DFeladat
{
    private string[][] _jatszmak;
    private int _lepesek = 0;
    
    public DFeladat(string[][] allGames)
    {
        _jatszmak = allGames;
        countVezerLepesek();
        Console.WriteLine($"Vezerek lépésszáma: {_lepesek}");
    }

    void countVezerLepesek()
    {
        foreach (string[] game in _jatszmak)
        {
            string whitePrevoiusPos = "d1";
            string blackPrevoiusPos = "d8";
            int currentStep = -1;
            foreach (string move in game)
            {
                currentStep++;
                if (!move.Contains("V")) continue;
                
                string currentPos = move.Substring(move.Length - 2);
                if (currentStep % 2 == 0)
                {
                    if (currentPos[1] == whitePrevoiusPos[1])
                    {
                        string convertedCurrentPos = convertPos(currentPos);
                        string convertedWhitePrevoiusPos = convertPos(whitePrevoiusPos);
                        _lepesek += Math.Abs(Convert.ToInt32(convertedCurrentPos[0].ToString()) -
                                             Convert.ToInt32(convertedWhitePrevoiusPos[0].ToString()));
                    }
                    else
                    {
                        _lepesek += Math.Abs(Convert.ToInt32(currentPos[1].ToString()) - Convert.ToInt32(whitePrevoiusPos[1].ToString()));
                    }

                    whitePrevoiusPos = currentPos;
                }
                else
                {
                    if (currentPos[1] == blackPrevoiusPos[1])
                    {
                        string convertedCurrentPos = convertPos(currentPos);
                        string convertedBlackPrevoiusPos = convertPos(blackPrevoiusPos);
                        _lepesek += Math.Abs(Convert.ToInt32(convertedCurrentPos[0].ToString()) -
                                             Convert.ToInt32(convertedBlackPrevoiusPos[0].ToString()));
                    }
                    else
                    {
                        _lepesek += Math.Abs(Convert.ToInt32(currentPos[1].ToString()) - Convert.ToInt32(blackPrevoiusPos[1].ToString()));
                    }

                    blackPrevoiusPos = currentPos;
                }
            }
        }
    }

    string convertPos(string pos)
    {
        string convertedPos = "";
        switch (pos[0])
        {
            case 'a':
                convertedPos += "1";
                break;
            case 'b':
                convertedPos += "2";
                break;
            case 'c':
                convertedPos += "3";
                break;
            case 'd':
                convertedPos += "4";
                break;
            case 'e':
                convertedPos += "5";
                break;
            case 'f':
                convertedPos += "6";
                break;
            case 'g':
                convertedPos += "7";
                break;
            case 'h':
                convertedPos += "8";
                break;
        }
        return convertedPos + pos[1];
    }
}