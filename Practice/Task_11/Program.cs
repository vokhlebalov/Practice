using System;
using System.Linq;

namespace Task_11
{
    internal class Program
    {
        static readonly char [] symbolsLower = {
            'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й',
            'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф',
            'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я'
        };

        static readonly char[] symbolsUpper =
        {
            'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И', 'Й',
            'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф',
            'Х', 'Ц', 'Ч', 'Ш', 'Ш', 'Ъ', 'Ы', 'Ь', 'Э', 'Ю', 'Я'
        };
        
        public static void Main(string[] args)
        {
            Console.Write("Введите натуральное число N (количество сдвигов): ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Введите исходный текст: ");
            string text = Console.ReadLine();
            string encodedText = "";
            
            foreach (char symbol in text)
                encodedText += Encode(symbol, n);
            
            Console.WriteLine($"Закодированный текст: {encodedText}");
        }

        static char Encode(char symbol, int n)
        {
            if (symbolsLower.Contains(symbol))
                return symbolsLower[(Array.IndexOf(symbolsLower, symbol) + n) % symbolsLower.Length];
            if (symbolsUpper.Contains(symbol))
                return symbolsUpper[(Array.IndexOf(symbolsUpper, symbol) + n) % symbolsUpper.Length];
            return symbol;
        }
        
        
    }
}