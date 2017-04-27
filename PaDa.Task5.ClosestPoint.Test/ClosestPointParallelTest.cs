using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PaDa.Task5.ClosestPoint.Test
{
    [TestClass]
    public class ClosestPointParallelTest
    {
        [TestMethod]
        public void Test3()
        {
            var p1 = new PlanarPoint(1, 1);
            var p2 = new PlanarPoint(1, 2);

            IPoint[] array = {p1, new PlanarPoint(1, 2), new PlanarPoint(3, 3)};
            var algo = new ClosestPointParallel();
            var result = algo.FindClosestPoints(array);

            Assert.AreEqual(1, result.Distance);
            Assert.AreEqual(p1, result.Point1);
            Assert.AreEqual(p2, result.Point2);
        }

        [TestMethod]
        public void Test1000Random()
        {
            for (var i = 0; i < 20; i++)
            {
                var rnd = new Random();
                var points = Enumerable.Repeat(1, 1000)
                    .Select(
                        i1 =>
                            new PlanarPoint((rnd.NextDouble() - 0.5) * Double.MaxValue,
                                (rnd.NextDouble() - 0.5) * Double.MaxValue))
                    .Cast<IPoint>()
                    .ToArray();


                var naiveAlgo = new ClosestPointNaive();
                var expected = naiveAlgo.FindClosestPoints(points);

                var algo = new ClosestPointParallel();
                var actual = algo.FindClosestPoints(points);

                Assert.AreEqual(expected.Distance, actual.Distance);
                Assert.AreEqual(expected.Point1, actual.Point1);
                Assert.AreEqual(expected.Point2, actual.Point2);
            }
        }
    }
}
