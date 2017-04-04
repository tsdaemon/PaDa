using NUnit.Framework;
using PaDa.Lib;
using PaDa.Lib.Generators;

namespace PaDa.Task1.Test
{
    [TestFixture]
    public class PrefixScanParallelTest
    {
        private PrefixScanParallel mScan;
        private PrefixScanSequential mScanCheck;

        [SetUp]
        public void Init()
        {
            mScan = new PrefixScanParallel();
            mScanCheck = new PrefixScanSequential();
        }

        [Test]
        public void OneElementTest()
        {
            var array = new[] { 2 };
            var array2 = mScan.Scan(array);
            Assert.AreEqual(new[] { 0, 2 }, array2);
        }

        [Test]
        public void ThreeElementsTest()
        {
            var array = new[] { 1, 2, 3 };
            var array2 = mScan.Scan(array);
            Assert.AreEqual(new[] { 0, 1, 3, 6 }, array2);
        }

        [Test]
        public void FiveElementsTest()
        {
            var array = new[] { 1, 2, 3, 4, 5 };
            var array2 = mScan.Scan(array);
            Assert.AreEqual(new[] { 0, 1, 3, 6, 10, 15 }, array2);
        }

        [Test]
        public void GeneratedTest()
        {
            var arrays = new ArrayGenerator(10000, 500, 1).GenerateTestArrays();
            foreach (var array in arrays)
            {
                var arrayCopy = (int[])array.Clone();

                var arrayResult = mScan.Scan(array);
                var arrayTest = mScanCheck.Scan(arrayCopy);
                Assert.AreEqual(arrayTest, arrayResult);
            }
        }
    }
}
