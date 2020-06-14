using System;

namespace OlympicTask2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string[] vals = Console.ReadLine().Split(' ');
            long k = int.Parse(vals[0]), n = int.Parse(vals[1]) - 1;
            long zero = k, one = 0, two = 0;
            for (int i = 0; i < n; i++)
            {
                two = one;
                one = zero;
                switch (k % 5)
                {
                    case 0:
                        zero = 9 * k / 5;
                        break;
                    case 1:
                        if (k >= 6)
                            zero = (k - 6) * 9 / 5 + 10;
                        else
                            zero = 0;
                        break;
                    case 2:
                        if (k >= 12)
                            zero = (k - 12) * 9 / 5 + 20;
                        else if (k == 7)
                            zero = 10;
                        else
                            zero = 0;
                        break;
                    case 3:
                        zero = (k - 3) * 9 / 5 + 5;
                        break;
                    case 4:
                        if (k >= 9)
                            zero = (k - 9) * 9 / 5 + 15;
                        else
                            zero = 5;
                        break;
                }
                k = zero + one + two;
            }
            
            Console.WriteLine(k);
        }
    }
}