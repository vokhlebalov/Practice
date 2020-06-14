using System;

namespace Task_5
{
    internal class Solution
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] max = new int[n];
            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine().Split(' ');
                max[i] = int.Parse(line[0]);
                for (int j = 0; j < n; j++)
                {
                    max[i] = Math.Max(int.Parse(line[j]), max[i]);
                }
            }

            int result = 0;
            for (int i = 0; i < n / 2; i++)
            {
                result += max[i] * max[n - i - 1] * 2;
            }
            
            if (n % 2 != 0) result += max[n / 2] * max[n / 2];
            
            Console.WriteLine(result);
        }
    }
}