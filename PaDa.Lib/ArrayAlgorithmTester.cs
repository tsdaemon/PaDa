using System;
using System.Diagnostics;
using System.Linq;

namespace PaDa.Lib
{
    public class ArrayAlgorithmTester
    {
        private int _maxElements;
        private int _repeats;
        private ArrayGenerator _generator;

        public ArrayAlgorithmTester(int maxElements, int repeats, ArrayGenerator generator)
        {
            _maxElements = maxElements;
            _repeats = repeats;
            _generator = generator;
        }

        public Tuple<int, TimeSpan>[] Test(IAlgorithm<int[],int[]> algo)
        {
            return _generator.GenerateTestArrays(1000, _maxElements, 1000, _repeats).Select(array =>
            {
                var watch = Stopwatch.StartNew();
                algo.Process(array);
                watch.Stop();
                return new Tuple<int, TimeSpan>(array.Length, watch.Elapsed);
            }).ToArray();
        }
    }
}
