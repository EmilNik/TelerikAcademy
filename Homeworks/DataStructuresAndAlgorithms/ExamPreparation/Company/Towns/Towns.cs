namespace Towns
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class Towns
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var numbers = new List<int>();
            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine();
                var lineParts = line.Split(' ');
                var number = int.Parse(lineParts[0]);
                numbers.Add(number);
            }

            var asnwer = Solve(numbers);
            Console.WriteLine(asnwer);
        }

        public static int Solve(List<int> numbers)
        {
            var leftToRight = new int[numbers.Count];
            var rightToLeft = new int[numbers.Count];
            for (int i = 0; i < numbers.Count; i++)
            {
                var maxLength = 0;
                for (int j = 0; j < i; j++)
                {
                    if (numbers[j] < numbers[i])
                    {
                        maxLength = Math.Max(maxLength, leftToRight[j]);
                    }
                }

                leftToRight[i] = maxLength + 1;
            }

            for (int i = numbers.Count - 1; i >= 0; i--)
            {
                var maxLength = 0;
                for (int j = numbers.Count - 1; j > i; j--)
                {
                    if (numbers[j] < numbers[i])
                    {
                        maxLength = Math.Max(maxLength, rightToLeft[j]);
                    }
                }

                rightToLeft[i] = maxLength + 1;
            }

            var maxNum = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                var path = leftToRight[i] + rightToLeft[i] - 1;
                maxNum = Math.Max(maxNum, path);
            }
            return maxNum;
        }
    }
}
