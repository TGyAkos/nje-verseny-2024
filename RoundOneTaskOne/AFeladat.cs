namespace RoundOneTaskOne;

class AFeladat
{
    public AFeladat(double[] mindenSzam)
    {
        double aszam = 1310438493;
        double[] originalPrime = primeFactors(aszam);
        double[] szamok = mindenSzam;

        List<double> relativePrimek = new List<double>();

        //Console.WriteLine(szamok.Length);

        for (int i = 0; i < szamok.Length; i++)
        {
            double szam = szamok[i];
            if (primeFactors(szam).Intersect(originalPrime).Count() == 0)
            {
                relativePrimek.Add(szam);
            }
            //Console.WriteLine($"Relativ primek szama: {relativePrimek.Count()}");
            //Console.WriteLine($"{i}/{szamok.Length}");
        }

        Console.WriteLine("Relative primek: " + relativePrimek.Count());
    }

    double[] primeFactors(double n)
    {
        List<double> primes = new List<double>();

        // Prdouble the number of 2s that divide n 
        while (n % 2 == 0)
        {
            primes.Add(2);
            n = n / 2;
        }

        // n must be odd at this podouble. So we can skip 
        // one element (Note i = i +2) 
        for (double i = 3; i <= Math.Sqrt(n); i = i + 2)
        {
            // While i divides n, prdouble i and divide n 
            while (n % i == 0)
            {
                primes.Add(i);
                n = n / i;
            }
        }

        // This condition is to handle the case when n 
        // is a prime number greater than 2 
        if (n > 2)
        {
            primes.Add(n);
        }

        return primes.ToArray().Distinct().ToArray();
    }


    void printPrimes(double[] primes)
    {
        foreach (double i in primes)
        {
            Console.Write(i + " ");
        }

        Console.WriteLine();
    }
}