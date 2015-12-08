namespace LongestPattern
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    class LongestPattern
    {
        static void MockInput()
        {
            var input = @"=iasdasdasdnput=-
asdasd-=42;";
            Console.SetIn(new StringReader(input));
        }

        static void Main()
        {
            MockInput();
            var str1 = Console.ReadLine();
            var str2 = Console.ReadLine();

            var maxLength = Solve(str1, str2);
            Console.WriteLine(maxLength);
        }

        private static int Solve(string str1, string str2)
        {
            int left = 0;
            int right = Math.Min(str1.Length, str2.Length);

            Hash.ComputePowers(right);

            while (left < right)
            {
                var middle = (left + right) / 2;
                bool hasFoundMatch = Check(str1, str2, middle);

                if (hasFoundMatch)
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle;
                }
            }

            return right - 1;
        }

        private static bool Check(string str1, string str2, int length)
        {
            var hash1 = new Hash(str1.Substring(0, length));

            var hashes = new HashSet<ulong>();
            hashes.Add(hash1.Value1);

            var hashes2 = new HashSet<ulong>();
            hashes2.Add(hash1.Value2);

            for (int i = 0; i < str1.Length - length; i++)
            {
                hash1.Add(str1[length + i]);
                hash1.Remove(str1[i], length);

                hashes.Add(hash1.Value1);
                hashes2.Add(hash1.Value2);
            }

            var hash2 = new Hash(str2.Substring(0, length));
            if (hashes.Contains(hash2.Value1) && hashes2.Contains(hash2.Value2))
            {
                return true;
            }

            for (int i = 0; i < str2.Length - length; i++)
            {
                hash2.Add(str2[length + i]);
                hash2.Remove(str2[i], length);
                if (hashes.Contains(hash2.Value1) && hashes2.Contains(hash2.Value2))
                {
                    return true;
                }
            }

            return false;
        }
    }

    public class Hash
    {
        private const ulong BASE1 = 127;
        private const ulong BASE2 = 257;
        private const ulong MOD = 1000000033;

        private static ulong[] powers;
        private static ulong[] powers2;

        public static void ComputePowers(int n)
        {
            powers = new ulong[n + 1];
            powers2 = new ulong[n + 1];
            powers[0] = 1;
            powers2[0] = 1;

            for (int i = 0; i < n; i++)
            {
                powers[i + 1] = powers[i] * BASE1 % MOD;
                powers2[i + 1] = powers[i] * BASE2 % MOD;
            }
        }

        public ulong Value1 { get; private set; }
        public ulong Value2 { get; private set; }

        public Hash(string str)
        {
            this.Value1 = 0;
            this.Value2 = 0;

            foreach (char c in str)
            {
                this.Add(c);
            }
        }

        public void Add(char c)
        {
            this.Value1 = (this.Value1 * BASE1 + c) % MOD;
            this.Value2 = (this.Value2 * BASE2 + c) % MOD;
        }

        public void Remove(char c, int n)
        {
            this.Value1 = (MOD + this.Value1 - powers[n] * c % MOD) % MOD;
            this.Value2 = (MOD + this.Value2 - powers2[n] * c % MOD) % MOD;
        }
    }
}
