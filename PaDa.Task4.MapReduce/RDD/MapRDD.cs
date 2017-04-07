using System;

namespace PaDa.Task4.MapReduce.RDD
{
    public class MapRDD<T, TInput>: RDD<T>, IMapper<TInput, T>
    {
        internal RDD<TInput> _input;
        internal Func<TInput, T> _map;

        public MapRDD(RDD<TInput> input, Func<TInput, T> map)
        {
            _input = input;
            _map = map;
        }

        internal override RDD GetPrevious()
        {
            return _input;
        }

        public T Map(TInput input)
        {
            return _map(input);
        }
    }
}
