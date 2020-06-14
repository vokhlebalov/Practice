using System;
using System.Collections;
using System.Collections.Generic;

namespace Task_12
{
    public class Solution
    {
        public static void Main(string[] args)
        {
            int[] ShuffledArr = {31, 24, 141, 1, 231, 2, 37, 45, 47, 11};
            int[] SortedToUpperArr = {1, 2, 11, 24, 31, 37, 45, 47, 141, 231};
            int[] SortedToLowerArr = {231, 141, 47, 45, 37, 31, 24, 11, 2, 1};
            
            

            TreeSort(ShuffledArr);
            Console.WriteLine("\nНесортированный массив\nКоличество сравнений и пересылок: " + TreeNode.ActionsCounter);
            TreeNode.ActionsCounter = 0;
            TreeSort(SortedToUpperArr);
            Console.WriteLine("\nОтсортированный по возрастанию массив\nКоличество сравнений и пересылок: " + TreeNode.ActionsCounter);
            TreeNode.ActionsCounter = 0;
            TreeSort(SortedToLowerArr);
            Console.WriteLine("\nОтсортированный по убыванию массив\nКоличество сравнений и пересылок: " + TreeNode.ActionsCounter);
            
            Console.WriteLine();
            
            
            Shell.Sort(ShuffledArr);
            Console.WriteLine("\nНесортированный массив\nКоличество сравнений и пересылок: " + Shell.ActionCounter);
            
            Shell.ActionCounter = 0;
            Shell.Sort(SortedToUpperArr);       
            Console.WriteLine("\nОтсортированный по возрастанию массив\nКоличество сравнений и пересылок: " + Shell.ActionCounter);
            
            Shell.ActionCounter = 0;
            Shell.Sort(SortedToLowerArr);
            Console.WriteLine("\nОтсортированный по убыванию массив\nКоличество сравнений и пересылок: " + Shell.ActionCounter);
        }
        
        static int[] TreeSort(int[] arr)
        {
            var treeNode = new TreeNode(arr[0]);
            for (int i = 1; i < arr.Length; i++)
            {
                treeNode.Insert(new TreeNode(arr[i]));
            }

            return treeNode.Transform();
        }
    }

    public class Shell
    {
        public static int ActionCounter = 0;
        
        public static void Sort (int[] arr)
        {
            for (int inc = arr.Length / 2; inc >= 1; inc /= 2)
                for (int step = 0; step < inc; step++)
                    InsertionSort (arr, step, inc);
        }

        private static void InsertionSort (int[] arr, int start, int inc)
        {
            for (int i = start; i < arr.Length - 1; i += inc)
                for (int j = Math.Min(i+inc, arr.Length-1); j-inc >= 0; j -= inc)
                {
                    ActionCounter++;
                    if (arr[j - inc] > arr[j])
                    {
                        ActionCounter += 3;
                        int tmp = arr[j];
                        arr[j] = arr[j - inc];
                        arr[j - inc] = tmp;
                    }
                    else break;
                }
        }
    }
    
    public class TreeNode
    {
         
        public TreeNode(int data)
        {
            Data = data;
        }

        public static int ActionsCounter = 0;
        public int Data { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }
        public void Insert(TreeNode node)
        {
            ActionsCounter += 2;
            if (node.Data < Data)
            {
                if (Left == null)
                {
                    ActionsCounter++;
                    Left = node;
                }
                else
                {
                    Left.Insert(node);
                }
            }
            else
            {
                if (Right == null)
                {
                    ActionsCounter++;
                    Right = node;
                }
                else
                {
                    Right.Insert(node);
                }
            }
        }
        public int[] Transform(List<int> elements = null)
        {
            if (elements == null)
            {
                elements = new List<int>();
            }

            if (Left != null)
            {
                Left.Transform(elements);   
            }

            elements.Add(Data);

            if (Right != null)
            {              
                Right.Transform(elements);
            }

            ActionsCounter += 4;
            return elements.ToArray();
        }
    }
}