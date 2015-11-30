namespace Sorting
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Sorting
    {
        static void Main()
        {
            var n = Console.ReadLine();
            var numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            var k = int.Parse(Console.ReadLine());

            var answer = Solve(numbers, k);
            Console.WriteLine(answer);
        }

        private static int Solve(int[] numbers, int k)
        {
            var visited = new Dictionary<int, int>();

            var queue = new Queue<int[]>();
            queue.Enqueue(numbers);
            visited.Add(GetHashCode(numbers), 0);

            while (queue.Count > 0)
            {
                var currentPerm = queue.Dequeue();
                var currentPath = visited[GetHashCode(currentPerm)];
                if (IsSorted(currentPerm))
                {
                    return currentPath;
                }

                for (int i = 0; i < numbers.Length - k + 1; i++)
                {
                    var desc = currentPerm.Clone() as int[];
                    Array.Reverse(desc, i, k);
                    if (!visited.ContainsKey(GetHashCode(desc)))
                    {
                        visited.Add(GetHashCode(desc), currentPath + 1);
                        queue.Enqueue(desc);
                    }
                }
            }

            return -1;
        }

        static bool IsSorted(int[] perm)
        {
            for (int i = 1; i < perm.Length; i++)
            {
                if (perm[i] < perm[i - 1])
                {
                    return false;
                }
            }

            return true;
        }

        static int GetHashCode(int[] values)
        {
            int hash = 0;
            foreach (var item in values)
            {
                hash *= 8;
                hash += item;
            }

            return hash;
        }
    }
}
