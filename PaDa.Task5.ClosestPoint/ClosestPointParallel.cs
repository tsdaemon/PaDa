using System;
using System.Threading.Tasks;

namespace PaDa.Task5.ClosestPoint
{
    public class ClosestPointParallel
    {
        public ClosestPointSearchResult FindClosestPoints(IPoint[] array)
        {
            Array.Sort(array, new PointComparerByFirstCoordinate());
            var result = new ClosestPointSearchResult();
            FindClosestPointsInternal(array, 0, array.Length, result);
            return result;
        }

        private void FindClosestPointsInternal(IPoint[] array, int begin, int end, ClosestPointSearchResult result)
        {
            if (end-begin < 2)
            {
                result.Distance = Double.MaxValue;
                return;
            }

            var median = begin + (end - begin) / 2;
            var result1 = new ClosestPointSearchResult();
            var result2 = new ClosestPointSearchResult();
            Parallel.Invoke(() => FindClosestPointsInternal(array, begin, median, result1),
                () => FindClosestPointsInternal(array, median, end, result2));

            BoundaryMerge(array, begin, end, result1, result2, result);
        }

        private void BoundaryMerge(IPoint[] array, int begin, int end, ClosestPointSearchResult r1, ClosestPointSearchResult r2, ClosestPointSearchResult rOut)
        {
            // find minimal result
            var minimal = r1.Distance > r2.Distance ? r2 : r1;
            var minDistance = minimal.Distance;
            rOut.Distance = minDistance;
            rOut.Point1 = minimal.Point1;
            rOut.Point2 = minimal.Point2;

            // find possible smaller distance on boundary
            var median = begin + (end - begin) / 2;
            var b1 = median;
            while (b1 > begin && array[b1].FirstCoordinate > array[median].FirstCoordinate - minDistance) b1--;
            var b2 = median;
            while (b2 < end && array[b2].FirstCoordinate < array[median].FirstCoordinate + minDistance) b2++;

            for (var i = b1; i < b2; i++)
            {
                for (var j = i+1; j < b2; j++)
                {
                    var distance = array[i].CalculateDistance(array[j]);
                    if (distance < rOut.Distance)
                    {
                        rOut.Distance = distance;
                        rOut.Point1 = array[i];
                        rOut.Point2 = array[j];
                    }
                }
            }
        }
    }
}
