using System;

namespace Task_4
{
    internal class Solution
    {
        private const double L = 0.0, R = 1.0;
        
        public static void Main(string[] args)
        {
            double e = double.Parse(Console.ReadLine());
            double left = L, right = R;
            double middle = left + (right - left) / 2.0;

            while (Math.Abs(right - left) > e)
            {   
                if (Sign(F(left)) != Sign(F(right)))
                {
                    if (Sign(F(middle)) == Sign(F(left)))
                        left = middle;
                    else
                        right = middle;
                }
                else
                {
                    left = middle;
                }
                
                middle = left + (right - left) / 2.0;
            }

            Console.WriteLine(middle);
        }

        static double F(double x)
        {
            return Math.Pow(x, 4) + 2.0 * Math.Pow(x, 3) - x * 1.0 - 1.0;
        }

        static int Sign(double x)
        {
            if (x < 0) return -1;
            if (x > 0) return 1;
            return 0;
        }
    }
}