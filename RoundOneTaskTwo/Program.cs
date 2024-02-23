namespace RoundOneTaskTwo 
{
    class Program
    {
        private Data[] dataArray;
        static void Main(string[] args)
        {
            Program program = new Program();
            program.ParseData();
            
            aFeladat();
            new BFeladat(program.dataArray);
            cFeladat(); 
            new DFeladat(program.dataArray);
            eFeladat();
            new FFeladat(program.dataArray);
            Console.ReadLine();
        }
        
        static void aFeladat()
        {
            List<string> telepulesek = new List<string>();
            string line = "";
            StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + "/../../../telepules.txt");
            line = sr.ReadLine();
            while (line != null)
            {
                telepulesek.Add(line);
                line = sr.ReadLine();
            }
            sr.Close();

            Dictionary<string, double> megyek_neppesege = new Dictionary<string, double>();
            megyek_neppesege.Add("BK", 0);
            megyek_neppesege.Add("BE", 0);
            megyek_neppesege.Add("BA", 0);
            megyek_neppesege.Add("BU", 0);
            megyek_neppesege.Add("CS", 0);
            megyek_neppesege.Add("FE", 0);
            megyek_neppesege.Add("GS", 0);
            megyek_neppesege.Add("HB", 0);
            megyek_neppesege.Add("HE", 0);
            megyek_neppesege.Add("JN", 0);
            megyek_neppesege.Add("KE", 0);
            megyek_neppesege.Add("NO", 0);
            megyek_neppesege.Add("PE", 0);
            megyek_neppesege.Add("SO", 0);
            megyek_neppesege.Add("SZ", 0);
            megyek_neppesege.Add("TO", 0);
            megyek_neppesege.Add("VA", 0);
            megyek_neppesege.Add("VE", 0);
            megyek_neppesege.Add("ZA", 0);

            for (int i = 0; i < telepulesek.Count(); i++)
            {
                string[] SplittedTelepules = telepulesek[i].Split(" ");
                string key = SplittedTelepules[1];
                if (megyek_neppesege.ContainsKey(key))
                {
                    megyek_neppesege[key] += Convert.ToDouble(SplittedTelepules[5]);
                }
            }
            var sortedDict = megyek_neppesege.OrderBy(kvp => kvp.Value).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            foreach (KeyValuePair<string, double> kvp in sortedDict)
            {
                Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
            }
            Console.WriteLine(" ");
        }
        static void cFeladat()
        {
            List<string> telepulesek = new List<string>();
            string line = "";
            StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + "/../../../telepules.txt");
            line = sr.ReadLine();
            while (line != null)
            {
                telepulesek.Add(line);
                line = sr.ReadLine();
            }
            sr.Close();
            int megfeleloek = 0;
            foreach(string row in telepulesek)
            {
                string[] RowSP = row.Split(" ");
                int kecstav = Convert.ToInt32(RowSP[7]);
                int szegtav = Convert.ToInt32(RowSP[8]);
                if(kecstav <= 50 && szegtav <= 50)
                {
                    megfeleloek++;
                }
            }
            Console.WriteLine("A körökön belüli vároksok: " + megfeleloek);
            Console.WriteLine(" ");
        }
        static void eFeladat()
        {
            List<string> telepulesek = new List<string>();
            string line = "";
            StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + "/../../../telepules.txt");
            line = sr.ReadLine();
            while (line != null)
            {
                telepulesek.Add(line);
                line = sr.ReadLine();
            }
            sr.Close();
            Dictionary<string, double> kvp = new Dictionary<string, double>();
            for(int i = 0; i < telepulesek.Count(); i++)
            {
                string row = telepulesek[i];
                string[] rowSP = row.Split(" ");
                string telepulesnev = rowSP[6];
                telepulesnev = telepulesnev.ToLower();
                string[] telepPos = rowSP[3].Split(".");
                double teleposFirstHalf = Convert.ToDouble(telepPos[0]);
                double dividebypos1 = 1;
                foreach (char s in telepPos[1])
                {
                    dividebypos1 = dividebypos1 * 10;
                }
                double teleposSecondHalf = Convert.ToDouble(telepPos[1]) / dividebypos1;
                double telePosTrue = teleposFirstHalf + teleposSecondHalf;
                if (telepulesnev.Contains("buda"))
                {
                    kvp.Add(rowSP[6], telePosTrue);
                }
            }
            var sortedDict = kvp.OrderBy(kvp => kvp.Value).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            foreach (KeyValuePair<string, double> kv in sortedDict)
            {
                Console.WriteLine("Key = {0}, Value = {1}", kv.Key, kv.Value);
            }
        }
        
        void ParseData()
        {
            List<Data> dataList = new List<Data>();
            String line;
            StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + "/../../../telepules.txt");
            line = sr.ReadLine();
            while (line != null)
            {
                var data = line.Split(' ');
                dataList.Add(new Data
                {
                    IranyitoSzam = int.Parse(data[0]),
                    Megye = data[1],
                    Szelesseg = float.Parse(data[2]),
                    Hosszusag = float.Parse(data[3]),
                    Terulet = float.Parse(data[4]),
                    Lakossag = double.Parse(data[5]),
                    TelepulesNev = data[6],
                    TavolsagKecskemettol = double.Parse(data[7]),
                    TavolsagSzegedtol = double.Parse(data[8])
                });
                line = sr.ReadLine();
            }
            sr.Close();
            dataArray = dataList.ToArray();
        }
    }
}

