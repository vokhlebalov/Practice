using System.Collections.Generic;
using System.Linq;

namespace Task_8
{
    internal class Program
    {
        public static void Main(string[] args)
        {
        }
    }

    public class Graph
    {
        public string Name { get; set; }
        public List<Node> Nodes { get; set; } = new List<Node>();

        public Graph(string name, List<Node> nodes)
        {
            Name = name;
            Nodes = nodes;
        }

        public Graph(string name)
        {
            Name = name;
        }
        
        public override string ToString()
        {
            string nodes = Nodes.Aggregate("", (current, node) => current + (node + "\n"));
            return Name + "\n" + nodes;
        }
    }
    
    public class Node
    {
        public List<Node> Ribs { get; set; } = new List<Node>();
        public string Name { get; set; }

        public Node(string name, List<Node> ribs)
        {
            Name = name;
            Ribs = ribs;
        }

        public Node(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            string ribs = Ribs.Aggregate("", (current, node) => current + (node.Name + " "));
            return $"{Name}: {ribs}";
        }
    }
}