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
            Console.SetIn(new StringReader(@"3
4 8 16
0
0
1 2"));
        }

        public static List<Task> tasks;
        public static int minMin;
        public static HashSet<Task> alreadySummed;

        static void Main()
        {
            ConsoleMock();
            Console.ReadLine();
            var arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            tasks = new List<Task>();
            alreadySummed = new HashSet<Task>();
            for (int i = 0; i < arr.Length; i++)
            {
                var depencencies = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                tasks.Add(new Task(arr[i]));
                foreach (var item in depencencies)
                {
                    tasks[i].DependenciesArr.Add(item);
                }
            }

            var currentMin = 0;
            foreach (var task in tasks)
            {
                if (task.DependenciesArr[0] == 0)
                {
                    task.MinMin = task.Value;
                }
                else
                {
                    currentMin = FindMinimunMinutes(task, new HashSet<Task>()); // TODO
                    if (currentMin > task.MinMin)
                    {
                        task.MinMin = currentMin;
                    }
                }

                if (currentMin == -1)
                {
                    Console.WriteLine(currentMin);
                    return;
                }

                if (task.MinMin > minMin)
                {
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
            foreach (var item in task.DependenciesArr)
            {
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

                    if (task.MinMin + currentMin > minMin)
                    {
                        minMin = task.MinMin + currentMin;
                    }
                }
                else
                {
                    minMin = task.Value;
                }

                task.MinMin = minMin;
            }

            return minMin;
        }
    }

    public class Task
    {
        public Task(int value)
        {
            this.Value = value;
            this.summed = new HashSet<Task>();
            this.DependenciesArr = new List<int>();
            this.steppedOn = new HashSet<Task>();
        }

        public int Value { get; set; }

        public HashSet<Task> summed { get; set; }

        public List<int> DependenciesArr { get; set; }

        public int MinMin { get; set; }

        public HashSet<Task> steppedOn { get; set; }
    }
}
