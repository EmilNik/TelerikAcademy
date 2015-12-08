namespace OfficeSpace
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class Program
    {
        public static void ConsoleMock()
        {
            Console.SetIn(new StringReader(@"10
1 2 3 4 5 6 7 8 9 10
2 3
4 5
7
9
8 9
8
10
0
0
0"));
        }

        public static List<Task> tasks;
        public static int minMin;

        static void Main()
        {
            //ConsoleMock();
            Console.ReadLine();
            var arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            tasks = new List<Task>();
            for (int i = 0; i < arr.Length; i++)
            {
                var depencencies = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                tasks.Add(new Task(arr[i]));
                foreach (var item in depencencies)
                {
                    tasks[i].DependenciesArr.Add(item);
                }
            }

            foreach (var task in tasks)
            {
                var currentMin = 0;
                if (task.DependenciesArr[0] == 0)
                {
                    currentMin = task.Value;
                }
                else
                {
                    currentMin = FindMinimunMinutes(task, new HashSet<Task>()); // TODO
                }

                if (currentMin == -1)
                {
                    Console.WriteLine(currentMin);
                    return;
                }

                if (currentMin > minMin)
                {
                    task.MinMin = currentMin;
                    minMin = task.MinMin;
                }
            }

            Console.WriteLine(minMin);
        }

        public static int FindMinimunMinutes(Task task, HashSet<Task> steppedOn)
        {
            task.MinMin = task.Value;
            task.steppedOn = steppedOn;
            task.steppedOn.Add(task);
            var currentMin = 0;
            var currentMax = 0;
            foreach (var item in task.DependenciesArr)
            {
                currentMin = 0;
                if (item != 0)
                {
                    if (task.steppedOn.Contains(tasks[item - 1]))
                    {
                        minMin = -1;
                        return minMin;
                    }

                    if (tasks[item - 1].MinMin != 0)
                    {
                        currentMin = tasks[item - 1].MinMin;
                    }
                    else
                    {
                        currentMin = FindMinimunMinutes(tasks[item - 1], new HashSet<Task>(task.steppedOn));
                    }
                    if (currentMin == -1)
                    {
                        return currentMin;
                    }

                    if (task.Value + currentMin > currentMax)
                    {
                        currentMax = task.Value + currentMin;
                        task.MinMin = currentMax;
                    }
                }
                else
                {
                    task.MinMin = task.Value;
                    return task.Value;
                }
            }

            task.MinMin = currentMax;
            return currentMax;
        }
    }

    public class Task
    {
        public Task(int value)
        {
            this.Value = value;
            this.Dependencies = new HashSet<Task>();
            this.DependenciesArr = new List<int>();
            this.steppedOn = new HashSet<Task>();
        }

        public int Value { get; set; }

        public HashSet<Task> Dependencies { get; set; }

        public List<int> DependenciesArr { get; set; }

        public int MinMin { get; set; }

        public HashSet<Task> steppedOn { get; set; }
    }
}
