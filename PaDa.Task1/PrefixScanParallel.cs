using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaDa.Task1
{
    public class PrefixScanParallel : PrefixScanBase
    {
        public override int[] Scan(int[] input)
        {
            // forward step
            var iterations = 0;
            var split = 1;
            while(split < input.Length)
            {
                Parallel.ForEach(PairEnumerator(Tree(split, input.Length)), new ParallelOptions { MaxDegreeOfParallelism = 4 }, t =>
                {
                    var i1 = t.Item1;
                    var i2 = t.Item2;
                    input[i2] = input[i1] + input[i2];
                });
                split *= 2;
                iterations++;
            } 

            // intermediate step
            var last = input[input.Length - 1];
            input[input.Length - 1] = 0;

            // backward step
            split = (int)Math.Pow(2, iterations - 1);
            while (split > 0)
            {
                Parallel.ForEach(PairEnumerator(Tree(split, input.Length)), new ParallelOptions {MaxDegreeOfParallelism=4}, t =>
                {
                    var i1 = t.Item1;
                    var i2 = t.Item2;
                    var prev = input[i2];
                    input[i2] = input[i1] + input[i2];
                    input[i1] = prev;
                });
                split /= 2;
            }
            return input.Union(new[] {last}).ToArray();
        }

        private IEnumerable<int> Tree(int split, int length)
        {
            var originalSplit = split;
            while (length > split)
            {
                yield return split-1;
                split += originalSplit;
            }
            if (length % originalSplit != 0)
            {
                yield return length -1;
            }
        }

        private IEnumerable<Tuple<int,int>> PairEnumerator(IEnumerable<int> range)
        {
            using (var enumerator = range.GetEnumerator())
            {
                enumerator.MoveNext();
                do
                {
                    var i1 = enumerator.Current;
                    if (enumerator.MoveNext())
                    {
                        var i2 = enumerator.Current;
                        yield return new Tuple<int, int>(i1, i2);
                    }
                    else break; 
                } while (enumerator.MoveNext());
            }
        }
    }
}
