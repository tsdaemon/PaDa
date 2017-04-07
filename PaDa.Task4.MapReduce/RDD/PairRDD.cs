using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaDa.Task4.MapReduce.RDD
{
    public abstract class PairRDD<TKey, TValue> : RDD<Tuple<TKey, TValue>>
    {
        public PairRDD<TKey, TValue> ReduceByKey(Func<TValue, TValue, TValue> reduce)
        {
            return new ReducePairRDD<TKey, TValue>(this, reduce);
        }
    }
}
