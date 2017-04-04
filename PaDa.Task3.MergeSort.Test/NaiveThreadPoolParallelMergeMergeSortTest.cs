using NUnit.Framework;
using System.Linq;
using PaDa.Lib.Generators;

namespace PaDa.Task3.MergeSort.Test
{
    [TestFixture]
    public class NaiveThreadPoolParallelMergeMergeSortTest
    {
        [Test]
        public void Test1()
        {
            var sort = new NaiveThreadPoolParallelMergeMergeSort();
            var array = new[] {1};
            var result = sort.Sort(array);
            Assert.AreEqual(new[] {1}, result);
        }

        [Test]
        public void Test3()
        {
            var sort = new NaiveThreadPoolParallelMergeMergeSort();
            var array = new[] { 2, -9, 1 };
            var result = sort.Sort(array);
            Assert.AreEqual(new[] { -9, 1, 2 }, result);
        }

        [Test]
        public void Test5()
        {
            var sort = new NaiveThreadPoolParallelMergeMergeSort();
            var array = new[] { 4, 3, 0, 4, 2 };
            var result = sort.Sort(array);
            Assert.AreEqual(new[] { 0, 2, 3, 4, 4 }, result);
        }

        [Test]
        public void TestRepeats()
        {
            var sort = new NaiveThreadPoolParallelMergeMergeSort();
            var array = new[] { 7, 7, 7, 7, 7 };
            var result = sort.Sort(array);
            Assert.AreEqual(new[] { 7, 7, 7, 7, 7 }, result);
        }

        [Test]
        public void GeneratedTest()
        {
            var arrays = new ArrayGenerator(1000, 100000, 1).GenerateTestArrays();
            var sort = new NaiveThreadPoolParallelMergeMergeSort();
            foreach(var array in arrays)
            {
                var result = sort.Sort(array);
                var ls = result.ToList();
                ls.Sort();
                var expectedResult = ls.ToArray();
                Assert.AreEqual(expectedResult, result);
            }
        }
    }
}
