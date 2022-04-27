using System;

namespace MyApp
{
    internal class Program
    {
        static class Pocitadlo
        {
            public static long pocet = 0;
            public static long[,] cache;
        }

        static void young(long kolik, long maximum)
        {
            if (Pocitadlo.cache[kolik, maximum] != 0)
            {
                Pocitadlo.pocet += Pocitadlo.cache[kolik, maximum];
            }
            else
            {
                long nazacatku = Pocitadlo.pocet;
                if (kolik == 0)
                    Pocitadlo.pocet++;
                else
                    for (long i = maximum; i > 0; i--)
                    {
                        if (kolik - i >= 0)
                            young(kolik - i, i);
                    }
                Pocitadlo.cache[kolik, maximum] = Pocitadlo.pocet - nazacatku;
            }
        }
        static void Main(string[] args)
        {
            long vstup = Convert.ToInt64(Console.ReadLine());
            Pocitadlo.cache = new long[vstup + 1, vstup + 1];
            young(vstup, vstup);
            Console.WriteLine(Pocitadlo.pocet);
        }
    }
}