using System;

namespace PaDa.Task4.MapReduce.RDD
{
    public abstract class RDD<T> : RDD
    {
        public RDD<TOut> Map<TOut>(Func<T, TOut> map)
        {
            return new MapRDD<TOut, T>(this, map);
        }

        public PairRDD<TOutKey, TOutValue> MapToPair<TOutKey, TOutValue>(Func<T, Tuple<TOutKey, TOutValue>> map)
        {
            return new MapPairRDD<TOutKey, TOutValue, T>(this, map);
        }
    }

    public abstract class RDD
    {
        internal abstract RDD GetPrevious();
    }
}
