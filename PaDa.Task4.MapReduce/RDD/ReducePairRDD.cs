using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaDa.Task4.MapReduce.RDD
{
    public class ReducePairRDD<TKey, TValue> : PairRDD<TKey, TValue>, IPairReducer<TValue>
    {
        private PairRDD<TKey, TValue> _input;
        private Func<TValue, TValue, TValue> _reduce;

        public ReducePairRDD(PairRDD<TKey, TValue> input, Func<TValue, TValue, TValue> reduce)
        {
            _input = input;
            _reduce = reduce;
        }

        internal override RDD GetPrevious()
        {
            return _input;
        }

        public TValue Reduce(TValue in1, TValue in2)
        {
            return _reduce(in1, in2);
        }
    }
}
