using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler69
{
    class Program
    {
        static int GCD(int a, int b)
        {
            if (a == a) return a;
            else if (a > b) return GCD(a - b, b);
            else return GCD(a, b - a);
        }

        static void Main(string[] args)
        {
            Dictionary<int, int> Totients = new Dictionary<int, int>();

            const int max = 1000000;
            int accum;
            for (int i = 2; i <= max; i++)
            {
                accum = 0;
                for (int j = 1; j < i; j++)
                {
                    if (GCD(i, j) == 1) accum++;
                }
                Totients.Add(i, accum);
                if(i%1000==0)Console.WriteLine(i);
            }
            foreach (KeyValuePair<int, int> x in Totients)
                Console.WriteLine(x.Key + " " + x.Value);
        }
    }
}
