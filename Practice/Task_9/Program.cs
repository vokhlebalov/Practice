using System;
using System.Collections;
using System.Collections.Generic;
namespace Task_9
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Введите натуральное число N, равное количеству элементов в списке: ");
            int n = int.Parse(Console.ReadLine());
            List list = new List(n);
            Console.Write("\nЭлементы списка: ");
            foreach (int element in list)
            {
                Console.Write($"{element} ");
            }
            
            Console.Write("\nВведите элемент, который нужно удалить: ");
            int delete = int.Parse(Console.ReadLine());
            list.Remove(delete);
            
            Console.Write("Элементы списка после удаления: ");
            foreach (int element in list)
            {
                Console.Write($"{element} ");
            }
            
            Console.Write("\nВведите элемент, который нужно найти: ");
            int find = int.Parse(Console.ReadLine());
            if (list.Contains(find))
            {
                Console.WriteLine("\nСписок содержит данный элемент");
            }
            else
            {
                Console.WriteLine("\nСписок не содержит данный элемент");
            }
        }
    }

    class Node
    {
        public Node Next { get; set; }
        public int Data { get; set; }

        public Node(int data)
        {
            Data = data;
        }
    }

    class List : IEnumerable<int>
    {
        public Node Head { get; set; }

        public int Count
        {
            get
            {
                int counter = 0;
                foreach (int element in this)
                {
                    counter++;
                }

                return counter;
            }
        }

        public List(int size)
        {
            Head = new Node(1);
            Head.Next = Head;
            Node current = Head;
            for (int i = 2; i <= size; i++)
            {
                current.Next = new Node(i);
                current = current.Next;
                current.Next = Head;
            }
        }

        public void Remove(int data)
        {
            if (Count == 0)
            {
                return;
            }

            if (Count == 1 && Head.Data == data)
            {
                Head = null;
                return;
            }

            if (Count == 1 && Head.Data != data)
            {
                Console.WriteLine("Элемента нет в списке");
            }

            if (Head.Data == data)
            {
                Head = Head.Next;
            }

            Node node = Head;
            while (node.Next.Next != null && node.Next.Data != data)
                node = node.Next;

            if (node.Next.Data != data)
            {
                Console.WriteLine("Элемента нет в списке");
                return;
            }

            node.Next = node.Next.Next;
            Console.WriteLine("Элемент успешно удален!");
        }

        public bool Contains(int data)
        {
            foreach (int element in this)
            {
                if (element == data)
                    return true;
            }

            return false;
        }

        public IEnumerator<int> GetEnumerator()
        {
            Node current = Head;
            do
            {
                yield return current.Data;
                current = current.Next;
            } while (current != Head);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}