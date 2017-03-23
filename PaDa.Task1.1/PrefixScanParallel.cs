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
            var indexes = Enumerable.Range(0, input.Length).ToList();
            var iterations = 0;
            do
            {
                if (indexes.Count == 1) break;
                
                var toRemove = new List<int>();
                Parallel.ForEach(PairEnumerator(indexes), t =>
                {
                    var i1 = t.Item1;
                    var i2 = t.Item2;
                    input[i2] = input[i1] + input[i2];
                    toRemove.Add(i1);
                });
                foreach (var remove in toRemove)
                {
                    indexes.Remove(remove);
                }

                iterations++;
            } while (true);

            // intermediate step
            var last = input[input.Length - 1];
            input[input.Length - 1] = 0;

            // backward step
            var split = (int)Math.Pow(2, iterations - 1);
            while (split > 0)
            {
                Parallel.ForEach(PairEnumerator(Tree(split, input.Length)), t =>
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
