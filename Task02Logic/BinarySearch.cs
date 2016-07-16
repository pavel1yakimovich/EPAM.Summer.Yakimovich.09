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
            
            int left = 0;
            int right = array.Length;
            int mid = 0;

            while (!(left >= right))
            {
                mid = left + (right - left) / 2;

                if (comparison(array[mid],value) == 0)
                    return mid;

                if (comparison(array[mid], value) == 1)
                    right = mid;
                else
                    left = mid + 1;
            }

            return -1;
        }

        /// <summary>
        /// binary search in sorted array for types that implement IComparable
        /// </summary>
        /// <typeparam name="T">type</typeparam>
        /// <param name="array">array</param>
        /// <param name="value">value we want to find</param>
        /// <returns></returns>
        public static int Search<T>(T[] array, T value)
        {
            if (ReferenceEquals(array, null))
                throw new ArgumentNullException();
            if (value is IComparable)
                return Search(array, value, Comparer<T>.Default.Compare);
            throw new ArgumentException();
        }
    }
}
