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
            Dictionary<int, int> Totients = new Dictionary<int, int>();
            List<long> Factors;
      
            const int max = 1000000;
            Factors = GetPrimes(max);

            long numer, denom;
            int j;

            for (int i = 2; i <= max; i++)
            {
                numer = 1;
                j = 0;
                while (Factors[j] < i) if (i % Factors[++j] == 0) numer *= Factors[j - 1] - 1;
                
                denom= 1;
                j = 0;
                while (Factors[j] < i) if (i % Factors[++j] == 0) denom *= Factors[j - 1];

                Totients.Add(i, (int)(((long)i * numer) / denom));
                if(i%1000==0)Console.WriteLine(i);
            }
            foreach (KeyValuePair<int, int> x in Totients)
                Console.WriteLine(x.Key + " " + x.Value);
        }
    }
}
