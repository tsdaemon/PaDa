using System;
using System.Collections.Generic;
using System.Text;
using PaDa.Lib;

namespace PaDa.Task1
{
    public abstract class PrefixScanBase : IAlgorithm<int[], int[]>
    {
        public abstract int[] Scan(int[] elements);

        public int[] Process(int[] input)
        {
            return Scan(input);
        }
    }
}
