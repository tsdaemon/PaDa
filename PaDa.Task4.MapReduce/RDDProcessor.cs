using PaDa.Task4.MapReduce.RDD;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaDa.Task4.MapReduce
{
    public class RDDProcessor<TInput, TOutput>  
    {
        public IEnumerable<TOutput> Process(RDD<TOutput> lastRdd) 
        {
            var actions = PrepareActionsList(lastRdd);
            CheckStartType(actions[0]);
            var currentObjects = ((IDataSource)actions[0]).GetData();
            foreach (var rdd in actions.Skip(1))
            {
                var mapper = rdd as IMapper;
                if (mapper != null)
                {
                    IEnumerable<object> mapResult;
                    do // repeat until all data will be ok
                    {
                        mapResult = MapObjects(mapper, currentObjects);
                    } while (mapResult.Any(c => c == null) && mapResult.Count() != currentObjects.Count());
                    currentObjects = mapResult;
                    continue;
                }

                var reducer = rdd as IPairReducer;
                if (reducer != null)
                {
                    currentObjects = ReduceByKeyObjects(reducer, currentObjects);
                }
            }
            return currentObjects.Cast<TOutput>();
        }

        private IEnumerable<object> ReduceByKeyObjects(IPairReducer reducer, IEnumerable<object> currentObjects)
        {
            var resultsByKey = new ConcurrentDictionary<object, List<object>>();
            Parallel.ForEach(currentObjects, o => GroupByKey(o, resultsByKey));
            var results = new List<object>();
            Parallel.ForEach(resultsByKey, o => ReduceByKey(reducer, o, results));
            return results;
        }

        private void ReduceByKey(IPairReducer reducer, KeyValuePair<object, List<object>> item, List<object> results)
        {
            var type = reducer.GetType();
            var inputType = item.Value[0].GetType();
            var reduceFunction = type.GetMethod("Reduce", new[]{ inputType, inputType });
            var accumulator = Activator.CreateInstance(inputType);
            foreach (var value in item.Value)
            {
                accumulator = reduceFunction.Invoke(reducer, new[] {value, accumulator});
            }
            results.Add(CreateTuple(item.Key, accumulator));
        }

        private void GroupByKey(object o, ConcurrentDictionary<object, List<object>> results)
        {
            var tupleType = o.GetType();
            var item1 = tupleType.GetProperty("Item1").GetValue(o);
            var item2 = tupleType.GetProperty("Item2").GetValue(o);
            results.AddOrUpdate(item1, new List<object> {item2}, (key, value) =>
            {
                value.Add(item2);
                return value;
            });
        }

        private Type GetTupleType(object item1, object item2)
        {
            var t = typeof(Tuple<,>);
            return t.MakeGenericType(item1.GetType(), item2.GetType());
        }

        private object CreateTuple(object item1, object item2)
        {
            var t = GetTupleType(item1, item2);
            var constructor = t.GetConstructor(new[]{ item1.GetType(), item2.GetType() });
            return constructor.Invoke(new[] {item1, item2});
        }

        private IEnumerable<object> MapObjects(IMapper mapper, IEnumerable<object> currentObjects)
        {
            var results = new List<object>();
            Parallel.ForEach(currentObjects, o => MapObject(mapper, o, results));
            return results;
        }

        private void MapObject(IMapper mapper, object o, List<object> results)
        {
            var type = mapper.GetType();
            var function = type.GetMethod("Map", new[]{ o.GetType() });
            var result = function.Invoke(mapper, new[]{ o });
            results.Add(result);
        }

        private void CheckStartType(RDD.RDD rdd)
        {
            var type = rdd.GetType();
            do
            {
                type = type.BaseType;
            } while (type.GetGenericTypeDefinition() != typeof(RDD<>));
            var genericArgument = type.GetGenericArguments()[0];
            if (genericArgument != typeof(TInput))
                throw new Exception(
                    $"Start RDD type has type ${genericArgument.Name}, but processor has input type ${typeof(TInput)}");
        }

        private List<RDD.RDD> PrepareActionsList(RDD<TOutput> lastRdd)
        {
            var rdds = new List<RDD.RDD>();
            RDD.RDD rdd = lastRdd;
            while (rdd != null)
            {
                rdds.Add(rdd);
                rdd = rdd.GetPrevious();
            }
            rdds.Reverse();
            return rdds;
        }
    }
}
