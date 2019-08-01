using System;
using System.Collections.Generic;

namespace taxicabproblem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----------Taxi-Cab Number problem----------------");
            Console.WriteLine("Please enter a number - comparison will be done till many those digits - 10-To-Power-Of-That-Number");
            Int16.TryParse(Console.ReadLine().ToString(), out short s);
            Console.WriteLine($"Selected Power is {s}");

            int n = Convert.ToInt32(Math.Pow(10, s));

            Console.WriteLine("Displaying Results");
            Console.WriteLine("-------------------------------");
            printTaxiCabNumbers(n);
        }

        private static void printTaxiCabNumbers(int n)
        {
            var map = new Dictionary<long, Pair>();
            //int a = 0, b = 0;
            //var tmp = new Pair(a, b);
            //tmp = null;

            for (int i = 1; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
#if DEBUG
                    if (i == 9)
                        System.Diagnostics.Debugger.Break();
#endif

                    long m = Convert.ToInt64((Math.Pow(i, 3) + Math.Pow(j, 3)));
                    if (map.ContainsKey(m))
                    {
                        Console.WriteLine($"Pairs {map.GetValueOrDefault(m).toString()} & {new Pair(i, j).toString()} are equal to sum: {m}");
                    }
                    else
                    {
                        map.Add(m, new Pair(i, j));
                    }
                }
            }
        }
    }

    public class Pair
    {
        int a, b;
        public Pair(int a, int b)
        {
            this.a = a;
            this.b = b;
        }
        public String toString()
        {
            return "(" + this.a + ", " + this.b + ")";
        }
    }
}