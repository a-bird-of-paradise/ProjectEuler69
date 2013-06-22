using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler69
{
    class Program
    {
        static List<long> GetPrimes(long cap)
        {
            bool[] Numbers = new bool[cap];
            long i, j;
            List<long> Answer = new List<long>();
            for (i = 0; i < cap; ++i)
                Numbers[i] = true;
            Numbers[0] = false; // 1 is not prime
            for (i = 2; i <= System.Math.Sqrt(cap); i++)
            {
                if (Numbers[i - 1] == true)
                {
                    j = 2;
                    while (i * j <= cap)
                    {
                        Numbers[i * j - 1] = false;
                        j++;
                    }
                }
            }
            for (i = 0; i < cap; ++i)
                if (Numbers[i] == true)
                    Answer.Add(i + 1);

            Answer.Sort();
            return Answer;
        }


        static int GCD(int a, int b)
        {
            if (a == b) return a;
            else if (a > b) return GCD(a - b, b);
            else return GCD(a, b - a);
        }

        static void Main(string[] args)
        {
            SortedDictionary<int, int> Totients = new SortedDictionary<int, int>();
            List<long> Factors;

            System.Diagnostics.Stopwatch Timer = new System.Diagnostics.Stopwatch();
            Timer.Start();

            const int max = 1000000;
            Factors = GetPrimes(max);

            long x, p, accum;
            int j, n = Factors.Count();
            double longest;

            foreach (long a in Factors) Totients.Add((int)a, (int)a - 1);

            for (int i = max; i >= 2; i--)
            {
                if (Factors.BinarySearch(i) >= 0) continue;
                x = i;
                accum = 1;
                for (j = 0; j < n; j++)
                {
                    p = Factors[j];
                    if (x==1) break;
                    if (x % p != 0) continue;
                    accum *= Totients[(int)p];
                    x /= p;
                    while (x % p == 0)
                    {
                        accum *= p;
                        x /= p;
                    }
                }

                Totients.Add(i, (int)accum);
            }
            longest = Totients.Select(s => (double)s.Key / (double)s.Value).Max();
            Console.WriteLine(Totients.Where(s => (double)s.Key / (double)s.Value == longest).Select(s => s.Key).First());
            Console.WriteLine(Timer.ElapsedMilliseconds);
        }
    }
}
