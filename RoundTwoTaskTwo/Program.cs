using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Data;

namespace RoundTwoTaskTwo;

class Program
{
    static void Main(string[] args)
    {
        string[][] jatszmak = readParseFile();
        //aFeladat();
        new BFeladat(jatszmak);
        //cFeladat();
        new DFeladat(jatszmak);
        //eFeladat();
        new FFeladat(jatszmak);
        // Console.ReadLine();
    }
    static string[][] readParseFile()
    {
        List<string[]> jatszmak = new List<string[]>();
        string line = "";
        StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + "/../../../jatszmak.txt");
        line = sr.ReadLine();
        while (line != null)
        {
            jatszmak.Add(line.Split("\t").ToArray());
            line = sr.ReadLine();
        }
        sr.Close();
        return jatszmak.ToArray();
    }
    static void aFeladat()
    {

        List<string> jatszmak = new List<string>();
        string line = "";
        StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + "/../../../../jatszmak.txt");
        line = sr.ReadLine();
        while (line != null)
        {
            jatszmak.Add(line);
            line = sr.ReadLine();
        }
        sr.Close();
        int items = 0;
        string winners = "";
        foreach(string row in jatszmak)
        {
            string[] moves = jatszmak[items].Split("/");
            int won = moves.Length;
            if (won % 2 == 0)
            {
                winners += "s";
            }
            else
                winners += "v";

            items++;
        }
        Console.WriteLine(winners);
        Console.ReadLine();
    }
    static void cFeladat()
    {

        List<string> jatszmak = new List<string>();
        string line = "";
        StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + "/../../../../jatszmak.txt");
        line = sr.ReadLine();
        while (line != null)
        {
            jatszmak.Add(line);
            line = sr.ReadLine();
        }
        sr.Close();
        string posOfWhiteQueen = "d1";
        string posOfBlackQueen = "d8";
        bool turn = true;
        int items = 0;
        List<int> thegame = new List<int>();
        foreach (string row in jatszmak)
        {
            string[] moves = jatszmak[items].Split("/");
            items++;
            for (int j = 0; j < moves.Length; j++)
            {
                if (ContainsUppercaseV(moves[j]))
                {

                    if(turn == true)
                    {
                        string newpos = RemoveCharacter(moves[j], 'V');
                        newpos = RemoveCharacter(newpos, 'x');
                        posOfWhiteQueen = newpos;
                            
                    }
                    if(turn == false)
                    {
                        string newpos = RemoveCharacter(moves[j], 'V');
                        newpos = RemoveCharacter(newpos, 'x');
                        posOfBlackQueen = newpos;
                    }
                        
                }
                else if (ContainsLowercasex(moves[j]))
                {
                    foreach(char agyrák in moves[j]) 
                    {
                        string takespos = GetLastTwoCharacters(moves[j]);
                        if(takespos == posOfWhiteQueen)
                        {
                            thegame.Add(items);
                            break;
                        }
                        else if(takespos == posOfBlackQueen)
                        {
                            thegame.Add(items);
                            break ;
                        }
                    }
                }
                if(turn == true)
                    turn = false;
                else if (turn == false)
                    turn = true;
            }
        }
        int[] alreadyindcluded = new int[35];
        for(int j = 0; thegame.Count() > j; j++)
        {
            if (!alreadyindcluded.Contains(thegame[j]))
                Console.Write(thegame[j] + " ");
            alreadyindcluded[j] = thegame[j];

        }
        Console.ReadLine();
    }
    static void eFeladat()
    {
        List<string> jatszmak = new List<string>();
        string line = "";
        StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + "/../../../../jatszmak.txt");
        line = sr.ReadLine();
        while (line != null)
        {
            jatszmak.Add(line);
            line = sr.ReadLine();
        }
        sr.Close();
        int items = 0;
        int whiteKingNotmoved = 0;
        bool turn = true;
        foreach (string row in jatszmak)
        {
            bool movedOrNO = false;
            string[] moves = jatszmak[items].Split("/");
            items++;
            foreach(string move in moves)
            {
                if(movedOrNO == false && turn == true)
                {
                    if(ContainsUppercaseK(move))
                        movedOrNO = true;
                    if(move == "O-O")
                    {
                        movedOrNO = true;
                    }
                    if (move == "O-O-O")
                    {
                        movedOrNO = true;
                    }
                }
                if (turn == true)
                {
                    turn = false;
                }
                else if (turn == false)
                {
                    turn = true;
                }
            }
            if(movedOrNO == false)
                whiteKingNotmoved++;   
        }
        Console.WriteLine(whiteKingNotmoved + " white king in this many games");
    }



    static bool ContainsUppercaseK(string text)
    {
        return text.Contains("K", StringComparison.Ordinal);
    }
    static bool ContainsUppercaseV(string text)
    {
        return text.Contains("V", StringComparison.Ordinal);
    }
    static bool ContainsLowercasex(string text)
    {
        return text.Contains("x", StringComparison.Ordinal);
    }
    static string RemoveCharacter(string input, char character)
    {
        return input.Replace(character.ToString(), string.Empty);
    }
    static string GetLastTwoCharacters(string input)
    {
        return input.Length >= 2 ? input.Substring(input.Length - 2) : input;
    }
}