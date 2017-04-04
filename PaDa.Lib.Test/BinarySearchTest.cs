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
            var position = BinarySearchHelper.Search(array, 0, array.Length, 7);
            Assert.AreEqual(1, position);
        }

        [Test]
        public void TestFindRight()
        {
            var array = new[] { 5, 7, 10, 12, 19, 20 };
            var position = BinarySearchHelper.Search(array, 0, array.Length, 19);
            Assert.AreEqual(4, position);
        }

        [Test]
        public void TestNotFind()
        {
            var array = new[] { 5, 7, 10, 12, 19, 20 };
            var position = BinarySearchHelper.Search(array, 0, array.Length, 0);
            Assert.AreEqual(-1, position);
        }

        [Test]
        [TestCase(new[] { 5, 7, 10, 12, 19, 20 }, 9, 2)]
        [TestCase(new[] { 5, 7, 10, 12, 19, 20 }, 21, 6)]
        [TestCase(new[] { 5, 7, 10, 12, 12, 12, 19, 20 }, 12, 3)]
        [TestCase(new[] { 5, 7, 10, 12, 19, 20, 22, 22, 23, 23 }, 22, 6)]
        [TestCase(new[] { -9, 1 }, 1, 1)]
        public void TestFindLess(int[] array, int value, int expected)
        {
            var position = BinarySearchHelper.FindLess(array, value);
            Assert.AreEqual(expected, position);
        }

        [Test]
        [TestCase(new[] { 5, 7, 10, 12, 19, 20 }, 9, 2)]
        [TestCase(new[] { 5, 7, 10, 12, 19, 20 }, 21, 6)]
        [TestCase(new[] { 5, 7, 10, 12, 12, 12, 19, 20 }, 12, 6)]
        [TestCase(new[] { 5, 7, 10, 12, 19, 20, 22, 22, 23, 23 }, 22, 8)]
        [TestCase(new[] { -9, 1 }, 1, 2)]
        public void TestFindLess2(int[] array, int value, int expected)
        {
            var position = BinarySearchHelper.FindLessOrEqual(array, value);
            Assert.AreEqual(expected, position);
        }

        [Test]
        public void TestFindLessWithStart()
        {
            var array = new[] {9, 28, 44, 47, 47, 47, 90};
            var less = BinarySearchHelper.FindLess(array, 48, 4);
            Assert.AreEqual(2, less);
        }

        [Test]
        public void TestFindLessOrEqualWithStart()
        {
            var array = new[] { 9, 28, 44, 47, 47, 47, 90 };
            var less = BinarySearchHelper.FindLessOrEqual(array, 47, 4);
            Assert.AreEqual(2, less);
        }

        [Test]
        public void TestFindLessWithStart2()
        {
            var array = new[] { -9, 1, 2 };
            var less = BinarySearchHelper.FindLess(array, -9, 2, 3);
            Assert.AreEqual(0, less);
        }
    }
}
