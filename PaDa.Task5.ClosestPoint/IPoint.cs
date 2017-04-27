using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaDa.Task5.ClosestPoint
{
    public interface IPoint
    {
        double FirstCoordinate { get; }
        double CalculateDistance(IPoint p);
    }

    public class PointComparerByFirstCoordinate : IComparer<IPoint>
    {
        public int Compare(IPoint x, IPoint y)
        {
            if (x.FirstCoordinate < y.FirstCoordinate) return -1;
            return Math.Abs(x.FirstCoordinate - y.FirstCoordinate) < 0.000001 ? 0 : 1;
        }
    }
}
