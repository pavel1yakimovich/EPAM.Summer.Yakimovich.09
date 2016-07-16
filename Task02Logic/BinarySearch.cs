using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02Logic
{
    public static class BinarySearch
    {
        /// <summary>
        /// binary search in sorted array
        /// </summary>
        /// <typeparam name="T">type</typeparam>
        /// <param name="array">array</param>
        /// <param name="value">value we want to find</param>
        /// <param name="comparison">method for comparison of 2 objects</param>
        /// <returns></returns>
        public static int Search<T>(T[] array, T value, Comparison<T> comparison)
        {
            if (ReferenceEquals(array, null) || ReferenceEquals(comparison, null))
                throw new ArgumentNullException();

            int i = -1;
            int low = 0, high = array.Length, mid;
            while (low < high)
            {
                mid = (low + high) / 2;
                if (comparison(value, array[mid]) == 0)
                {
                    return i;
                }
                if (comparison(value, array[mid]) == -1)
                {
                    high = mid;
                }
                else
                {
                    low = mid + 1;
                }
            }

            return i;
        }

        /// <summary>
        /// binary search in sorted array for types that implement IComparable
        /// </summary>
        /// <typeparam name="T">type</typeparam>
        /// <param name="array">array</param>
        /// <param name="value">value we want to find</param>
        /// <returns></returns>
        private static int Search<T>(T[] array, T value)
        {
            if (ReferenceEquals(array, null))
                throw new ArgumentNullException();
            if (value is IComparable)
                return Search(array, value, Comparer<T>.Default.Compare);
            throw new ArgumentException();
        }
    }
}
