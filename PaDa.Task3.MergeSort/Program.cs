using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaDa.Lib;
using PaDa.Lib.Generators;

namespace PaDa.Task3.MergeSort
{
    class Program
    {
        public static void Main(string[] args)
        {
            var tester = new ArrayAlgorithmTester(new ArrayGenerator(1000, 1000000 , 2));

            var result = tester.Test(new MergeSort());

            using (var sw = new StreamWriter(File.OpenWrite("sequential.csv")))
            {
                foreach (var s in result)
                {
                    sw.Write($"{s.Item1}, {s.Item2.TotalMilliseconds}\n");
                }
            }

            var result2 = tester.Test(new NaiveThreadPoolParallelMergeMergeSort());

            using (var sw = new StreamWriter(File.OpenWrite("parallel-naive-threadpool-merge.csv")))
            {
                foreach (var s in result2)
                {
                    sw.Write($"{s.Item1}, {s.Item2.TotalMilliseconds}\n");
                }
            }

            var result3 = tester.Test(new NaiveTplParallelMergeMergeSort());

            using (var sw = new StreamWriter(File.OpenWrite("parallel-naive-paralle-merge.csv")))
            {
                foreach (var s in result3)
                {
                    sw.Write($"{s.Item1}, {s.Item2.TotalMilliseconds}\n");
                }
            }
        }
    }
}
