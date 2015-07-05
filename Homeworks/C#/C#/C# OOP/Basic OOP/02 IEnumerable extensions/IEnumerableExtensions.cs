namespace _02_IEnumerable_extensions
{
    using System;
    using System.Collections.Generic;

    class IEnumerableExtensions
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>{ 1, 2, 3, 4, 5, 6, };
            list.Average();
            list.Sum();
            list.Product();
            list.Min();
            list.Max();
        }
    }
}
