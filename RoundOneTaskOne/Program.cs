using System.Collections.Generic;
using System.IO;
using System;
using System.Linq;

namespace RoundOneTaskOne
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] szamok = ReadFile();

            AFeladat aFeladat = new(szamok);
            OneB();
            CFeladat cFeladat = new(szamok);

            Console.ReadLine();
        }

        static double[] ReadFile()
        {
            List<double> szamok = new List<double>();

            String line;
            StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + "/../../../szamok.txt");
            line = sr.ReadLine();
            while (line != null)
            {
                szamok.Add(double.Parse(line));
                line = sr.ReadLine();
            }
            sr.Close();

            return szamok.ToArray();
        }
        static void OneB()
        {
            List<double> szamok = new List<double>();
            String line;
            StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + "/../../../szamok.txt");
            line = sr.ReadLine();
            while (line != null)
            {
                szamok.Add(double.Parse(line));
                line = sr.ReadLine();
            }

            sr.Close();

            double number = 2354211341;
            string numberString = number.ToString(); // Convert double to string
            int[] firstnumberContains = new int[10];
            int i = 0;
            foreach (char digit in numberString) // Puts the numbers into a int[]
            {
                int digitValue = int.Parse(digit.ToString());
                firstnumberContains[i] = digitValue;
                i++;
            }

            List<double> annagrams = new List<double>(); //List for all the numbers that match the requirements
            int primaryOne =
                firstnumberContains.Count(num =>
                    num == 1); //Checks how many of these numbers does the priamry number contains
            int primaryTwo = firstnumberContains.Count(num => num == 2);
            int primaryThree = firstnumberContains.Count(num => num == 3);
            int primaryFour = firstnumberContains.Count(num => num == 4);
            int primaryFive = firstnumberContains.Count(num => num == 5);
            foreach (double szam in szamok)
            {
                int[] disposible = new int[10];
                int j = 0;
                string numbtostr = szam.ToString();
                foreach (char digit in numbtostr) // Parses the numbers into disposible
                {
                    int digitValue = int.Parse(digit.ToString());
                    disposible[j] = digitValue;
                    j++;
                }

                int desposibleOne = disposible.Count(num => num == 1); // Checks the numbers of the disposible
                int desposibleTwo = disposible.Count(num => num == 2);
                int desposibleThree = disposible.Count(num => num == 3);
                int desposibleFour = disposible.Count(num => num == 4);
                int desposibleFive = disposible.Count(num => num == 5);
                if (desposibleOne == primaryOne && desposibleTwo == primaryTwo && desposibleThree == primaryThree &&
                    desposibleFour == primaryFour && desposibleFive == primaryFive)
                {
                    //Makes the number back to its original form and puts it into the list
                    string concatenatedString = string.Join("", disposible);
                    double concatenatedInteger = double.Parse(concatenatedString);
                    annagrams.Add(concatenatedInteger);
                }
            }

            Console.WriteLine("The matching annagrams: " + annagrams.Count());
        }
    }
}