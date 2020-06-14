using System;

namespace Task_3
{
    internal class Solution
    {
        public static void Main(string[] args)
        {
            double x = double.Parse(Console.ReadLine()),
                   y = double.Parse(Console.ReadLine());

            double result = IsInD(x, y) ? x - y : x * y + 7;

            Console.Write(result);
        }

        static bool IsInD(double x, double y)
        {
            return x * x + (y - 1) * (y - 1) <= 1 && 
                   y <= 1 - x * x;
        }
    }
}