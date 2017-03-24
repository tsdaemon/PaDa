using System;
using NUnit.Framework;

namespace PaDa.Lib.Test
{
    [TestFixture]
    public class BinarySearchTest
    {
        [Test]
        public void TestFindLeft()
        {
            var array = new[] {5, 7, 10, 12, 19, 20};
            var position = Search.BinarySearch(array, 0, array.Length, 7);
            Assert.AreEqual(1, position);
        }

        [Test]
        public void TestFindRight()
        {
            var array = new[] { 5, 7, 10, 12, 19, 20 };
            var position = Search.BinarySearch(array, 0, array.Length, 19);
            Assert.AreEqual(4, position);
        }

        [Test]
        public void TestNotFind()
        {
            var array = new[] { 5, 7, 10, 12, 19, 20 };
            var position = Search.BinarySearch(array, 0, array.Length, 0);
            Assert.AreEqual(-1, position);
        }
    }
}
