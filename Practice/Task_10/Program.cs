using System;
using System.Collections;
using System.Collections.Generic;

namespace Task_10
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Введите элементы дерева в строчку через пробел:\n");
            string[] sNums = Console.ReadLine().Split(' ');
            int[] nums = new int[sNums.Length];
            for (int i = 0; i < nums.Length; i++)
                nums[i] = int.Parse(sNums[i]);

            if (nums.Length > 0)
            {
                Tree tree = new Tree(nums);
                for (int i = 1; i <= tree.MaxLevel; i++)
                {
                    List<Node> nodes = GetLevel(tree, i);
                    Console.Write($"Элементы {i}-го яруса: ");
                    foreach (Node node in nodes)
                    {
                        Console.Write(node.Data + " ");
                    }
                    Console.WriteLine();
                }
            }
        }

        static List<Node> GetLevel(Tree tree, int level)
        {
            List<Node> elements = new List<Node>();
            foreach (Node node in tree)
            {
                if (node.Level == level)
                    elements.Add(node);
            }

            return elements;
        }
    }

    class Tree : IEnumerable<Node>
    {
        public int MaxLevel { get; set; } = 1;
        public Node Root { get; }

        public Tree(int[] arr)
        {
            Root = new Node(arr[0]);
            for (int i = 1; i < arr.Length; i++)
            {
                Add(Root, arr[i]);
            }
        }
        
        void Add(Node root, int data)
        {
            Node current = root;
            Node parent = null;
            bool ok = false;

            while (current != null && !ok)
            {
                parent = current;
                if (data == current.Data) ok = true;
                else if (data < current.Data) current = current.Left;
                else current = current.Right;
            }

            if (ok) return;
            Node newNode = new Node(data, parent);
            MaxLevel = Math.Max(MaxLevel, newNode.Level);
            if (data < parent.Data) parent.Left = newNode;
            else parent.Right = newNode;
        }
        public IEnumerator<Node> InOrderTraversal()
        {
            if (Root != null)
            {
                Stack<Node> stack = new Stack<Node>();
                Node current = Root;
                bool goLeftNext = true;
                stack.Push(current);

                while (stack.Count > 0)
                {
                    if (goLeftNext)
                    {
                        while (current.Left != null)
                        {
                            stack.Push(current);
                            current = current.Left;
                        }
                    }

                    yield return current;

                    if (current.Right != null)
                    {
                        current = current.Right;

                        goLeftNext = true;
                    }
                    else
                    {
                        current = stack.Pop();
                        goLeftNext = false;
                    }
                }
            }
        }

        public IEnumerator<Node> GetEnumerator()
        {
            return InOrderTraversal();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    class Node
    {
        public int Level { get; set; } = 1;
        public Node Parent { get; }

        public Node Left { get; set; }

        public Node Right { get; set; }
        public int Data { get; }

        public Node(int data, Node parent)
        {
            Data = data;
            Level = GetLevel(parent);
            Left = null;
            Right = null;
            Parent = parent;
        }

        public Node(int data)
        {
            Data = data;
        }

        int GetLevel(Node parent)
        {
            int counter = 1;
            Node current = parent;
            while (current != null)
            {
                counter++;
                current = current.Parent;
            }

            return counter;
        }
    }
}