using System;

namespace OlympicTasks
{
    internal class Solution
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] numStrings = Console.ReadLine().Split(' ');
            int[] nums = new int[n];
            for (int i = 0; i < n; i++)
            {
                nums[i] = int.Parse(numStrings[i]);
            }

            if (n == 1) Console.WriteLine(nums[0]);
            else if (n % 2 == 0) Console.WriteLine(Math.Max(nums[n / 2 - 1], nums[n / 2]));
            else Console.WriteLine(Math.Max(Math.Min(nums[n / 2 - 1], nums[n / 2]), Math.Min(nums[n / 2], nums[n / 2 + 1])));
        }
    }
}