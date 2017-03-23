using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PaDa.Task1
{
    public class DataGenerator
    {
        public IEnumerable<int[]> GenerateTestArrays(int from, int to, int step, int repeats)
        {
            for (var n = from; n <= to; n += step)
            {
                var Min = int.MinValue / n;
                var Max = int.MaxValue / n;
                var randNum = new Random();
                for (var i = 0; i < repeats; i++)
                {
                    yield return Enumerable
                        .Repeat(0, n)
                        .Select(_ => randNum.Next(Min, Max))
                        .ToArray();
                }
            }
        }
    }
}
