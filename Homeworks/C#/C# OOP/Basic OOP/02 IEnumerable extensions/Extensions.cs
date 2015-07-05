//Implement a set of extension methods for IEnumerable<T> that implement the following group functions: 
//sum, product, min, max, average.

namespace _02_IEnumerable_extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Extensions
    {
        public static T Sum<T>(this IEnumerable<T> collection)
            where T : struct
        {
            T result = (dynamic)0;

            foreach (T item in collection)
            {
                result += (dynamic)item;
            }

            return result;
        }

        public static T Product<T>(this IEnumerable<T> collection)
            where T : struct
        {
            T product = (dynamic)1;

            foreach (T item in collection)
            {
                product *= (dynamic)item;
            }

            return product;
        }

        public static T Min<T>(this IEnumerable<T> collection)
            where T : struct
        {
            return collection.Min();
        }

        public static T Max<T>(this IEnumerable<T> collection)
            where T : struct
        {
            return collection.Max();
        }

        public static T Average<T>(this IEnumerable<T> collection)
            where T : struct
        {
            return collection.Average();
        }
    }
}
