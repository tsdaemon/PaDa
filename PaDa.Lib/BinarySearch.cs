using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaDa.Lib
{
    public class Search
    {
        public static int BinarySearch<T>(T[] array, int start, int end, T value) where T : IComparable
        {
            var center = start + (end - start) / 2;

            var centerValue = array[center];
            var compare = centerValue.CompareTo(value);
            if (start == end)
            {
                return compare == 0 ? center : -1;
            }
            if (compare == 0)
            {
                return center;
            }
            if (compare > 0)
            {
                return BinarySearch(array, start, center, value);
            }
            return BinarySearch(array, center, end, value);
        }
    }
}
