using System;
using PaDa.Lib;

namespace PaDa.Task3.MergeSort
{
    public class MergeSort : IAlgorithm<int[], int[]>
    {
        public virtual int[] Sort(int[] array)
        {
            var result = new int[array.Length];
            var pivot = array.Length / 2;
            var workArray = (int[])array.Clone();

            SortInternal(workArray, result, 0, pivot);
            SortInternal(workArray, result, pivot, array.Length);
            Merge(workArray, result, 0, pivot, array.Length);
            return result;
        }

        protected virtual void Merge(int[] array, int[] arrayResult, int start, int pivot, int end)
        {
            var i1 = start;
            var i2 = pivot;
            for (var i = 0; i < end - start; i++)
            {
                if (i1 >= pivot)
                {
                    arrayResult[start + i] = array[i2];
                    i2++;
                }
                else if (i2 >= end)
                {
                    arrayResult[start + i] = array[i1];
                    i1++;
                }
                else
                {
                    if (array[i1] < array[i2])
                    {
                        arrayResult[start + i] = array[i1];
                        i1++;
                    }
                    else
                    {
                        arrayResult[start + i] = array[i2];
                        i2++;
                    }
                }
            }
        }

        protected virtual void SortInternal(int[] array, int[] result, int start, int end)
        {
            if (start >= end-1) return;

            var pivot = start + (end - start) / 2;
            SortInternal(array, result, start, pivot);
            SortInternal(array, result, pivot, end);
            Merge(array, result, start, pivot, end);
            Array.Copy(result, start, array, start, end - start);
        }

        public int[] Process(int[] input)
        {
            return Sort(input);
        }
    }
}
