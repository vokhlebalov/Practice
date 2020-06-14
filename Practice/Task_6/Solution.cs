using System;

namespace Task_6
{
    internal class Solution
    {
        static double[] a = new double[3];
        
        public static void Main(string[] args)
        {
            Console.Write("Введите a1: ");
            a[0] = double.Parse(Console.ReadLine());
            Console.Write("Введите a2: ");
            a[1] = double.Parse(Console.ReadLine());
            Console.Write("Введите a3: ");
            a[2] = double.Parse(Console.ReadLine());
            Console.Write("Введите M: ");
            int m = int.Parse(Console.ReadLine());
            Console.Write("Введите N: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Введите L: ");
            double l = int.Parse(Console.ReadLine());
            
            int counter = 0;
            string firstNNums = $"{a[0]} {a[1]} {a[2]} ";
            string moreThanLNums = "";

            for (int i = 0; i < 3 && counter < m; i++)
            {
                if (a[i] > l)
                {
                    moreThanLNums += a[i] + " ";
                    counter++;
                }
            }

            if (counter == m)
            {
                Console.WriteLine(moreThanLNums);
                Console.WriteLine($"Причина остановки: нашлись первые M = {m} членов последовательности, которые больше, чем L = {l}");
            }
            else
            {
                int i;
                for (i = 3; i < n && counter < m; i++)
                {
                    double next = Rec(i + 1);
                    firstNNums += next + " ";
                    if (next > l)
                    {
                        moreThanLNums += next + " ";
                        counter++;
                    }
                }
                
                if (counter == m)
                {
                    Console.WriteLine(moreThanLNums);
                    Console.WriteLine($"Причина остановки: нашлись первые M = {m} членов последовательности, которые больше, чем L = {l}");
                }
                else
                {
                    Console.WriteLine(firstNNums);
                    Console.WriteLine($"Причина остановки: найдены первые N = {n} членов последовательности");
                }
            }
            
            
        }

        static double Rec(int n)
        {
            switch (n)
            {
                case 1:
                    return a[0];
                case 2:
                    return a[1];
                case 3:
                    return a[2];
            }

            return Rec(n - 3) * (7.0 / 3.0 * Rec(n - 1) + Rec(n - 2)) / 2.0;
        }
    }
}