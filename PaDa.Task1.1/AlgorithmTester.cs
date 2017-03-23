using System;
using System.Diagnostics;
using System.Linq;

namespace PaDa.Task1
{
    public class AlgorithmTester
    {
        private int _maxElements;
        private int _repeats;
        private DataGenerator _generator;

        public AlgorithmTester(int maxElements, int repeats, DataGenerator generator)
        {
            _maxElements = maxElements;
            _repeats = repeats;
            _generator = generator;
        }

        public Tuple<int, TimeSpan>[] Test(PrefixScanBase prefixScan)
        {
            return _generator.GenerateTestArrays(1000, _maxElements, 1000, _repeats).Select(array =>
            {
                var watch = Stopwatch.StartNew();
                prefixScan.Scan(array);
                watch.Stop();
                return new Tuple<int, TimeSpan>(array.Length, watch.Elapsed);
            }).ToArray();
        }
    }
}
