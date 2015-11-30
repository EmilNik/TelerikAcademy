namespace Elections
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;

    class Elections
    {
        static void Main()
        {
            var k = int.Parse(Console.ReadLine());
            var n = int.Parse(Console.ReadLine());
            var parties = new List<int>();
            for (int i = 0; i < n; i++)
            {
                parties.Add(int.Parse(Console.ReadLine()));
            }

            var answer = Solve(parties);
            Console.WriteLine(answer);
        }

        private static BigInteger Solve(List<int> parties)
        {
            var sums = new int[parties.Sum() + 1];
            sums[0] = 1;
            var maxSum = 0;

            for (int i = 0; i < parties.Count; i++)
            {
                var num = parties[i];
                for (int j = parties.Sum(); j >= 0; j--)
                {
                    if (sums[j] > 0)
                    {
                        sums[j + num] += sums[j];
                        maxSum = Math.Max(maxSum, j + num);
                    }
                }
            }

            var combinations = 0;
            for (int i = k; i < parties.Sum(); i++)
            {
                
            }

            return 0;
        }
    }
}
