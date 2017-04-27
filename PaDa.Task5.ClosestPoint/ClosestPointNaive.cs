using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaDa.Task5.ClosestPoint
{
    public class ClosestPointNaive
    {
        public ClosestPointSearchResult FindClosestPoints(IPoint[] points)
        {
            var result = new ClosestPointSearchResult {Distance = Double.MaxValue};
            for (var i = 0; i < points.Length; i++)
            {
                for (var j = i + 1; j < points.Length; j++)
                {
                    var distance = points[i].CalculateDistance(points[j]);
                    if (distance < result.Distance)
                    {
                        result.Distance = distance;
                        result.Point1 = points[i];
                        result.Point2 = points[j];
                    }
                }
            }
            return result;
        }
    }
}
