using System;
using System.Collections.Generic;
using System.Linq;

namespace PaDa.Lib.Generators
{
    public class ArrayGenerator
    {
        private int _maxValue;
        private int _minValue;
        private int _repeats;

        public ArrayGenerator(int minValue, int maxValue, int repeats)
        {
            if (minValue > maxValue) throw new Exception("Wrong generator arguments!");
            _maxValue = maxValue;
            _minValue = minValue;
            _repeats = repeats;
        }

        public IEnumerable<int[]> GenerateTestArrays()
        {
            for (var n = _minValue; n <= _maxValue; n += GetZeros(n))
            {
                var Min = int.MinValue / n;
                var Max = int.MaxValue / n;
                var randNum = new Random();
                for (var i = 0; i < _repeats; i++)
                {
                    yield return Enumerable
                        .Repeat(0, n)
                        .Select(_ => randNum.Next(Min, Max))
                        .ToArray();
                }
            }
        }

        private int GetZeros(int n, int zeros = 0)
        {
            var rem = n % 10;
            if (rem != 0)
            {
                var answer = 1;
                while (zeros > 0)
                {
                    answer *= 10;
                    zeros--;
                }
                return answer;
            }
            return GetZeros(n/10, zeros + 1);
        }
    }
}
