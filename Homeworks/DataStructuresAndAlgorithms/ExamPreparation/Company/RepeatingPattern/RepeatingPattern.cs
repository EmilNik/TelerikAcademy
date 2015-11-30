namespace RepeatingPattern
{
    using System;

    class RepeatingPattern
    {
        static void Main()
        {
            var str = Console.ReadLine();
            var length = str.Length;
            var flag = false;
            for (int i = 1; i < length / 2; i++)
            {
                if (length % i > 0)
                {
                    continue;
                }

                flag = true;
                var subStr = str.Substring(0, i);
                for (int j = i; j + i <= length; j += i)
                {
                    if (subStr != str.Substring(j, i))
                    {
                        flag = false;
                        break;
                    }
                }

                if (flag)
                {
                    Console.WriteLine(subStr);
                    return;
                }
            }

            Console.WriteLine(str);
        }
    }
}
