using System.Linq;
using PaDa.Lib;
using System;
using PaDa.Lib.Helpers;

namespace PaDa.Task3.MergeSort
{
    public class NaiveThreadPoolParallelMergeMergeSort : MergeSort
    {
        protected override void Merge(int[] array, int[] arrayResult, int start, int pivot, int end)
        {
            // collect separate action arrays for each individual operation
            var firstPart = Enumerable.Range(start, pivot - start).Select(index => new Action(() =>
            {
                var value = array[index];
                var less = BinarySearchHelper.FindLess(array, value, pivot, end);
                arrayResult[index + less] = value;
            }));

            var secondPart = Enumerable.Range(pivot, end - pivot).Select(index => new Action(() =>
            {
                var value = array[index];
                var less = BinarySearchHelper.FindLessOrEqual(array, value, start, pivot);
                arrayResult[start + index - pivot + less] = value;
            }));

            // combine into 4 big actions
            var actions = new Action[4];
            var i = 0;
            foreach (var action in firstPart)
            {
                actions[i] += action;
                i++;
                if (i == actions.Length) i = 0;
            }
            foreach (var action in secondPart)
            {
                actions[i] += action;
                i++;
                if (i == actions.Length) i = 0;
            }
            ThreadPoolHelper.SpawnAndWait(actions);
        }
    }
}
