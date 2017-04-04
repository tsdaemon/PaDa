using System;
using System.Collections.Generic;
using System.Diagnostics;
using PaDa.Lib.Generators;

namespace PaDa.Lib
{
    public class ArrayAlgorithmTester
    {
        private ArrayGenerator _generator;

        public ArrayAlgorithmTester(ArrayGenerator generator)
        {
            _generator = generator;
        }

        public IEnumerable<Tuple<int, TimeSpan>> Test(IAlgorithm<int[],int[]> algo)
        {
            foreach (var array in _generator.GenerateTestArrays())
            {
                var watch = Stopwatch.StartNew();
                algo.Process(array);
                watch.Stop();
                yield return new Tuple<int, TimeSpan>(array.Length, watch.Elapsed);
            }
        }
    }
}
