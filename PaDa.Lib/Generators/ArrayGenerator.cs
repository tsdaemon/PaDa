using System;
using System.Collections.Generic;
using System.Linq;

namespace PaDa.Lib.Generators
{
    public class ArrayGenerator
    {
        private int _maxLength;
        private int _minLength;
        private int _repeats;
        private int _minValue;
        private int _maxValue;

        public ArrayGenerator(int minLength, int maxLength, int repeats, int minValue = int.MinValue, int maxValue = int.MaxValue)
        {
            if (minLength > maxLength) throw new Exception("Wrong generator arguments!");
            _maxLength = maxLength;
            _minLength = minLength;
            _minValue = minValue;
            _maxValue = maxValue;
            _repeats = repeats;
        }

        public IEnumerable<int[]> GenerateTestArrays()
        {
            for (var n = _minLength; n <= _maxLength; n += GetZeros(n))
            {
                var randNum = new Random();
                for (var i = 0; i < _repeats; i++)
                {
                    yield return Enumerable
                        .Repeat(0, n)
                        .Select(_ => randNum.Next(_minValue, _maxValue))
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
