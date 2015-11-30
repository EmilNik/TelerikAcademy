using System;
using System.Collections.Generic;

namespace Company
{
    class Salaries
    {
        static Dictionary<string, Node> nodes;
        static int allSalaries;

        static void Main(string[] args)
        {
            nodes = new Dictionary<string, Node>();

            int numberOfNames = int.Parse(Console.ReadLine());
            int numberOfConnections = int.Parse(Console.ReadLine());
            
            var bossName = Console.ReadLine();
            var theBoss = new Node(bossName);
            nodes.Add(bossName, theBoss);

            for (int i = 1; i < numberOfNames; i++)
            {
                var name = Console.ReadLine();
                var node = new Node(name);
                nodes.Add(name, node);
            }

            for (int i = 0; i < numberOfConnections; i++)
            {
                var names = Console.ReadLine().Split(' ');
                var node = nodes[names[0]];

                for (int j = 1; j < names.Length; j++)
                {
                    var childNode = nodes[names[j]];
                    node.Childs.Add(childNode);
                }
            }
            DFS(theBoss);

            Console.WriteLine(allSalaries);
        }

        public static void DFS(Node root)
        {
            if (root.Childs.Count == 0)
            {
                allSalaries += root.Salary;
                return;
            }

            int salary = 0;
            foreach (var child in root.Childs)
            {
                DFS(child);
                salary += child.Salary;
            }

            root.Salary = salary;
            allSalaries += root.Salary;
        }
    }

    public class Node
    {
        public Node(string name)
        {
            this.Name = name;
            this.Childs = new List<Node>();
            this.Salary = 1;
        }

        public List<Node> Childs { get; private set; }

        public string Name { get; set; }

        public int Salary { get; set; }
    }
}
