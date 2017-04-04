using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaDa.Lib
{
    public class BinarySearchHelper
    {
        public static int Search<T>(T[] array, int start, int end, T value) where T : IComparable
        {
            var center = start + (end - start) / 2;

            var centerValue = array[center];
            var compare = centerValue.CompareTo(value);
            if (start == end-1)
            {
                return compare == 0 ? center : -1;
            }
            if (compare == 0)
            {
                return center;
            }
            if (compare > 0)
            {
                return Search(array, start, center, value);
            }
            return Search(array, center, end, value);
        }

        public static int FindLess<T>(T[] array, T value, int? arrayStart = null, int? arrayFinish = null)
            where T : IComparable
        {
            if (!arrayStart.HasValue) arrayStart = 0;
            if (!arrayFinish.HasValue) arrayFinish = array.Length;

            return FindLess(array, arrayStart.Value, arrayFinish.Value, value, arrayStart.Value);
        }

        private static int FindLess<T>(T[] array, int start, int end, T value, int arrayStart) where T: IComparable
        {
            if (start >= end) return Math.Min(start, end) - arrayStart;

            var center = (start+end)/2;

            var centerValue = array[center];
            var compare = centerValue.CompareTo(value);
            if (compare == 0)
            {
                do
                {
                    center--;
                } while (center > arrayStart-1 && array[center].CompareTo(value) == 0);

                return center + 1 - arrayStart;
            }
            if (compare > 0)
            {
                return FindLess(array, start, center, value, arrayStart);
            }
            return FindLess(array, center + 1, end, value, arrayStart);
        }

        public static int FindLessOrEqual<T>(T[] array, T value, int? arrayStart = null, int? arrayFinish = null)
            where T : IComparable
        {
            if (!arrayStart.HasValue) arrayStart = 0;
            if (!arrayFinish.HasValue) arrayFinish = array.Length;

            return FindLessOrEqual(array, arrayStart.Value, arrayFinish.Value, value, arrayStart.Value, arrayFinish.Value);
        }

        public static int FindLessOrEqual<T>(T[] array, int start, int end, T value, int arrayStart, int arrayFinish) where T : IComparable
        {
            if (start >= end) return Math.Min(start, end) - arrayStart;

            var center = (start + end) / 2;

            var centerValue = array[center];
            var compare = centerValue.CompareTo(value);
            if (compare == 0)
            {
                do
                {
                    center++;
                } while (center < arrayFinish && array[center].CompareTo(value) == 0);

                return center - arrayStart;
            }
            if (compare > 0)
            {
                return FindLessOrEqual(array, start, center, value, arrayStart, arrayFinish);
            }
            return FindLessOrEqual(array, center + 1, end, value, arrayStart, arrayFinish);
        }
    }
}
