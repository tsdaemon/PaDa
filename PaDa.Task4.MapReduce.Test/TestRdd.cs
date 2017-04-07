using System;
using System.Linq;
using NUnit.Framework;
using PaDa.Lib.Generators;
using PaDa.Task4.MapReduce.RDD;


namespace PaDa.Task4.MapReduce.Test
{
    [TestFixture]
    public class TestRdd
    {
        [Test]
        public void TestZeros()
        {
            var input = new[] { 0, 0, 0, 1, 1, 1 };
            var expectedResult = new[] { new Tuple<int, int>(1, 3), new Tuple<int, int>(0, 3) };
            var inputRdd = new FromMemoryRdd<int>(input);
            var mapRdd = inputRdd.MapToPair((i) => new Tuple<int, int>(i, 1));
            var reduceRdd = mapRdd.ReduceByKey((i1, i2) => i1 + i2);

            var result = new RDDProcessor<int, Tuple<int, int>>().Process(reduceRdd).ToArray();

            CollectionAssert.AreEquivalent(expectedResult, result);
        }

        [Test]
        public void TestArray3()
        {
            var input = new[] {1, 1, 1};
            var expectedResult = new[] {new Tuple<int, int>(1, 3)};
            var inputRdd = new FromMemoryRdd<int>(input);
            var mapRdd = inputRdd.MapToPair((i) => new Tuple<int, int>(i, 1));
            var reduceRdd = mapRdd.ReduceByKey((i1, i2) => i1 + i2);

            var result = new RDDProcessor<int, Tuple<int, int>>().Process(reduceRdd).ToArray();

            CollectionAssert.AreEquivalent(expectedResult, result);
        }

        [Test]
        public void TestArray7()
        {
            var input = new[] { 1, 1, 1, 2, 2, 3, 3 };
            var expectedResult = new[] { new Tuple<int, int>(1, 3), new Tuple<int, int>(2, 2), new Tuple<int, int>(3, 2) };
            var inputRdd = new FromMemoryRdd<int>(input);
            var mapRdd = inputRdd.MapToPair((i) => new Tuple<int, int>(i, 1));
            var reduceRdd = mapRdd.ReduceByKey((i1, i2) => i1 + i2);

            var result = new RDDProcessor<int, Tuple<int, int>>().Process(reduceRdd).ToArray();

            CollectionAssert.AreEquivalent(expectedResult, result);
        }

        [Test]
        public void TestRandomArray()
        {
            var dataGenerator = new ArrayGenerator(100, 1000, 1, 0, 10);
            foreach (var array in dataGenerator.GenerateTestArrays())
            {
                var expectedResult = array.GroupBy(i => i).Select(gb => new Tuple<int, int>(gb.Key, gb.Count())).ToArray();

                var inputRdd = new FromMemoryRdd<int>(array);
                var mapRdd = inputRdd.MapToPair((i) => new Tuple<int, int>(i, 1));
                var reduceRdd = mapRdd.ReduceByKey((i1, i2) => i1 + i2);

                var result = new RDDProcessor<int, Tuple<int, int>>().Process(reduceRdd).ToArray();

                CollectionAssert.AreEquivalent(expectedResult, result);
            }
        }
    }
}
