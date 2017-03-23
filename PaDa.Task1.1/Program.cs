 using System;
using System.IO;

namespace PaDa.Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            var sequentialAlgo = new PrefixScanSequential();
            var tester = new AlgorithmTester(100000, 20, new DataGenerator());

            var result = tester.Test(sequentialAlgo);

            using (var sw = new StreamWriter(File.OpenWrite("sequential.txt")))
            {
                foreach (var s in result)
                {
                    sw.Write($"{s.Item1}, {s.Item2.TotalMilliseconds}");
                }
            }
        }
    }
}