using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaDa.Lib.Generators;
using PaDa.Task4.MapReduce.RDD;

namespace PaDa.Task4.MapReduce
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new ArrayGenerator(1024, 1024, 1, 0, 10).GenerateTestArrays().First();
            var inputRdd = new FromMemoryRdd<int>(array);
            var mapRdd = inputRdd.MapToPair(i => new Tuple<int, int>(i, 1));
            var reduceRdd = mapRdd.ReduceByKey((i1, i2) => i1 + i2);

            var result = new RDDProcessor<int, Tuple<int, int>>().Process(reduceRdd).ToArray();
        }
    }
}
