using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaDa.Task4.MapReduce.RDD
{
    public class MapPairRDD<TKey, TValue, TInput> : PairRDD<TKey, TValue>, IMapper<TInput, Tuple<TKey, TValue>>
    {
        private RDD<TInput> _input;
        private Func<TInput, Tuple<TKey, TValue>> _map;

        public MapPairRDD(RDD<TInput> input, Func<TInput, Tuple<TKey, TValue>> map)
        {
            _input = input;
            _map = map;
        }

        public Tuple<TKey, TValue> Map(TInput input)
        {
            return _map(input);
        }

        internal override RDD GetPrevious()
        {
            return _input;
        }
    }
}
