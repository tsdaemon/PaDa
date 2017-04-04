using System.Linq;
using System.Threading.Tasks;
using PaDa.Lib;

namespace PaDa.Task3.MergeSort
{
    public class NaiveTplParallelMergeMergeSort : MergeSort
    {
        protected override void Merge(int[] array, int[] arrayResult, int start, int pivot, int end)
        {
            Parallel.Invoke(() => Parallel.ForEach(Enumerable.Range(start, pivot - start), index =>
            {
                var value = array[index];
                var less = BinarySearchHelper.FindLess(array, value, pivot, end);
                arrayResult[index + less] = value;
            }),
            () => Parallel.ForEach(Enumerable.Range(pivot, end - pivot), index =>
            {
                var value = array[index];
                var less = BinarySearchHelper.FindLessOrEqual(array, value, start, pivot);
                arrayResult[start + index - pivot + less] = value;
            }));
        }
    }
}
