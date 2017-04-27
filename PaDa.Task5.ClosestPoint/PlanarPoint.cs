using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaDa.Task5.ClosestPoint
{
    public struct PlanarPoint : IPoint
    {
        public double X { get; }
        public double Y { get; }

        public override bool Equals(object obj)
        {
            var point = (PlanarPoint)obj;
            return Math.Abs(point.X - X) < 0.000001 && Math.Abs(point.Y - Y) < 0.000001;
        }

        public PlanarPoint(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double CalculateDistance(IPoint p)
        {
            var point = (PlanarPoint)p;
            return Math.Sqrt(Math.Pow(point.X - X, 2) + Math.Pow(point.Y - Y, 2));
        }

        public double FirstCoordinate => X;
    }
}
